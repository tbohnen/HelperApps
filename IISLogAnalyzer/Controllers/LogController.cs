using IISLogReader;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security;
using System.Web;
using System.Web.Mvc;

namespace IISLogAnalyzer.Controllers
{
    public class LogController : Controller
    {
        private ILogReader _logReader;

        public LogController(ILogReader logReader)
        {
            _logReader = logReader;
        }

        public LogController()
        {
            _logReader = new LogReader();
        }

        public ActionResult DisplayLogFile(int top = 100)
        {
            ReadAllLogsFilesFromDirectory();
            ViewBag.Headers = _logReader.Header;

            ViewBag.ErrorLogEntries = _logReader
                .LogEntries
                .Where(c => ((dynamic)c).scstatus == "404" || ((dynamic)c).scstatus == "500")
                .OrderByDescending(entry => Convert.ToDateTime(entry["date"]))
                .Take(top)
                .ToList();

            ViewBag.SuccessLogEntries = _logReader
                .LogEntries
                .Where(c => ((dynamic)c).scstatus == "200")
                .OrderByDescending(entry => Convert.ToDateTime(entry["date"]))
                .Take(top)
                .ToList();


            return View();
        }

        private void ReadAllLogsFilesFromDirectory()
        {
            var files = Directory.GetFiles(ConfigurationManager.AppSettings["LogFileDirectory"]);

            foreach (var file in files)
            {
                _logReader.AddFileToEntries(file);
            }
        }

        public void BlockIp(string ip)
        {
            string command = GetCommandToAddIpToFirewall(ip);
            AddLineToBatchFile(command);
        }

        public void AddLineToBatchFile(string command)
        {
            string firewallDirectory = CheckIfDirectoryExistsAndCreateIfItDoesnt();
            var fullPath = String.Concat(firewallDirectory, "MaliciousIPSFromIISLogs.cmd");

            System.IO.File.AppendAllText(fullPath, command);
        }

        private static string CheckIfDirectoryExistsAndCreateIfItDoesnt()
        {
            string firewallDirectory = ConfigurationManager.AppSettings["FirewallDirectory"];

            if (!Directory.Exists(firewallDirectory))
                Directory.CreateDirectory(firewallDirectory);

            return firewallDirectory;
        }

        public string GetCommandToAddIpToFirewall(string ip)
        {
            return String.Format("netsh.exe advfirewall firewall add rule name=\"disallow {0}\" action=block enable=yes localip=any dir=in remoteip={0}\r\n", ip);
        }

    }
}