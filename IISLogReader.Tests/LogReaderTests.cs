using System.Linq;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Moq;

namespace IISLogReader.Tests
{
    [TestClass]
    public class LogReaderTests
    {
        private ILogReader _logReader;
        Moq.Mock<IFileReader> _fileReaderMock;
        const string _logFileWith404String = "LogFileWith404";
        const string _logFileWith200String = "LogFileWith200";

        [TestInitialize]
        public void Init()
        {
            _fileReaderMock = new Moq.Mock<IFileReader>();
            _fileReaderMock.Setup(fileReader => fileReader.ReadAllLines(_logFileWith404String)).Returns(TestData.LogFileWith404);
            _fileReaderMock.Setup(fileReader => fileReader.ReadAllLines(_logFileWith200String)).Returns(TestData.LogFileWith200);
            _logReader = new LogReader(_fileReaderMock.Object);
            _logReader.AddFileToEntries(_logFileWith404String);
        }

        [TestMethod]
        public void OpenLogAndEnsureThereAreEntries()
        {
            Assert.IsTrue(_logReader.LogEntries.Count > 0);
        }

        [TestMethod]
        public void OpenLogAndReadHeaderEnsureThatFirstHeaderValueIsDate()
        {
            Assert.AreEqual(_logReader.Header.First(),"date");
        }

        [TestMethod]
        public void TestFirstValueCanConvertToDate()
        {
            var logEntries = _logReader.LogEntries;
            dynamic value = logEntries.First();
            var convertedDate = Convert.ToDateTime(value.date);
        }

        [TestMethod]
        public void MakesSureAllLinesHasValue()
        {
            var headerLine = String.Join("," , _logReader.Header);
            System.Diagnostics.Debug.WriteLine(headerLine);
            foreach (dynamic item in _logReader.LogEntries)
            {
                Assert.IsNotNull(item.date);
            }
        }

        [TestMethod]
        public void GetAllLinesWithNotFoundErrors()
        {
            var notFoundLines = from logEntries in _logReader.LogEntries
                                    where ((dynamic)logEntries).scstatus == "404"
                                    select logEntries;

            foreach (dynamic item in notFoundLines)
            {
                Assert.AreEqual("404", item.scstatus);
            }
            
        }

        [TestMethod]
        public void ReadMultipleFilesIntoLogParser()
        {
            int realLineCount = TestData.LogFileWith404
                .Count(entry => FileIsLogEntryLine(entry));

            realLineCount += TestData.LogFileWith200
                .Count(entry => FileIsLogEntryLine(entry));

            _logReader.AddFileToEntries(_logFileWith200String);

            Assert.IsTrue(_logReader.LogEntries.Count() == realLineCount);
        }

        private bool FileIsLogEntryLine(string entry)
        {
            return !new[] { "#Version:", "#Date:", "#Software:", "#Fields:" }
                        .Contains(entry.Split(' ')[0]);
        }

    }
}
