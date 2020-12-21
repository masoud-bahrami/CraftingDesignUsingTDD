using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;
using Xunit.Sdk;

namespace TestDoubles.Stub
{
    public class FileReaderStub : IFileReader
    {
        private string _content;
        public bool ThrowException { get; set; }
        public static FileReaderStub WhichReturn(string content)
        {
            return new FileReaderStub
            {
                _content = content
            };
        }
        public static FileReaderStub WhichReturnEmpty()
        {
            return new FileReaderStub
            {
                _content = ""
            };
        }


        //Responder stub
        public string ReadAllText(string fileAddress)
        {
            if(ThrowException)
                throw new FileNotFoundException();
            return _content;
        }

        public static IFileReader WithReturnFileNotFoundException()
        {
            return new FileReaderStub
            {
                ThrowException = true
            };
        }

        
    }
    public class CarCsvFileTests
    {
        //Parse csv to car model

        //csv file is empty
        //File does not exists

        //Parse title


        [Fact]
        public void TestCsvFileTitle()
        {
            var sut = new CarsCsvFile(FileReaderStub.WhichReturn($"Year;Make;Model;Length" + Environment.NewLine +
                "1997; Ford; E350; 2,35" + Environment.NewLine +
                "2000; Mercury; Cougar; 2,38"));
            var titles = sut.GetTitles();

            Assert.True(titles.First().Contains("Year"));
            Assert.True(titles.First().Contains("Make"));
            Assert.True(titles.First().Contains("Model"));
            Assert.True(titles.First().Contains("Length"));
        }

        [Fact]
        public void TestFileContentIsEmpty()
        {
            var sut = new CarsCsvFile(FileReaderStub.WhichReturnEmpty());

            var result = Assert.Throws<EmptyException>(() => sut.GetTitles());
            //Assert.Equal("فایل نباید خالی باشد!", result.Message);
        }

        [Fact]
        public void TestFileDoesNotExist()
        {
            var sut = new CarsCsvFile(FileReaderStub.WithReturnFileNotFoundException());

            var result = Assert.Throws<FileNotFoundException>(() => sut.GetTitles());
        }
    }
}
