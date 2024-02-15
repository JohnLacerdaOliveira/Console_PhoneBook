using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_PhoneBook.DataAccess
{
    public class FileMetaData
    {
        public string FileName { get; init; }
        public SaveFileFormat SaveFormat { get; init; }

        public FileMetaData(string fileName, SaveFileFormat saveFormat)
        {
            FileName = fileName;
            SaveFormat = saveFormat;
        }

        public string FilePath => $"{FileName}.{SaveFormat}";

    }
}
