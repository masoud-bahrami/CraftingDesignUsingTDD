using System;
using System.Linq;
using Xunit;

namespace XUnitTestProject1
{
    public class PrintReportTests
    {
        [Fact]
        public void TestHtml()
        {
            var sut = new PrintReport();
            sut.GenerateReport("Html");
        }

        [Fact]
        public void TestXml()
        {
            var sut = new PrintReport();
            sut.GenerateReport("Xml");
        }

        [Fact]
        public void TestRaw()
        {
            var sut = new PrintReport();
            sut.GenerateReport("Raw");
        }
    }
    
    public class PrintReport
    {
        public string GenerateReport(string type)
        {

            var methodInfo = typeof(PrintReport).GetMethods()
                .FirstOrDefault(m => m.Name == type);

            var result = methodInfo.Invoke(this, null);
            return result as string;
        }

        private string Xml()
        {
            return "";
        }

        private string Html()
        {
            return "";
        }

        public string Raw()
        {
            return "";
        }
    }
}