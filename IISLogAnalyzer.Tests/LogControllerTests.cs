using IISLogAnalyzer.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IISLogAnalyzer.Tests
{
    [TestClass]
    public class LogControllerTests
    {
        [TestMethod]
        public void TestAddIpToFirewall()
        {
            var logController = new LogController();
            string ip = "1.1.1.1";
            var result = logController.GetCommandToAddIpToFirewall(ip);
            Assert.IsTrue(result.Contains(ip));
        }

        [TestMethod]
        public void TestThatCommandIsAddedToFileWhenBlockIpIsCalled()
        {
            string ip = "10.10.1.1";
            string testPath = "c:\\FirewallRules\\MaliciousIPSFromIISLogs.cmd";
            File.Delete(testPath);

            new LogController().BlockIp(ip);
            new LogController().BlockIp("10.10.1.2");

            var lines = File.ReadAllLines(testPath);
            Assert.IsTrue(lines.Count(c=> c.Contains(ip)) == 1);
        }

    }
}
