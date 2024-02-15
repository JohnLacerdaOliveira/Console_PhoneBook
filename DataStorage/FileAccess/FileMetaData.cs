using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_PhoneBook.DataStorage.FileAccess
{
    public class FileMetaData
    {
        public string FileName { get; init; }
        public FileFormat SaveFormat { get; init; }

        public FileMetaData(string fileName, FileFormat saveFormat)
        {
            FileName = fileName;
            SaveFormat = saveFormat;
        }

        public string FilePath => $"{FileName}.{SaveFormat}";

    }
}
