using System.IO;
using System.Linq;
using Xunit.Sdk;

namespace TestDoubles.Stub
{
    public class CarsCsvFile
    {
        private readonly IFileReader _fileReader;

        public CarsCsvFile(IFileReader fileReader)
        {
            _fileReader = fileReader;
        }
        //SUT
        //DOC

        public string[] GetTitles()
        {
            //Indirect-input
            var csvContent = GetContent();
            
            if (csvContent.Length == 0)
                throw new EmptyException("فایل نباید خالی باشد!");

            var csvContentRows = csvContent.Split('\n');

            var csv = from line in csvContentRows
                      select line.Split(',').ToArray();
            
            return csv.First();
        }

        private string GetContent() => _fileReader.ReadAllText("data.csv");
    }

    public interface IFileReader
    {
        string ReadAllText(string fileAddress);
    }
}
