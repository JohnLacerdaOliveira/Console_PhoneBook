﻿using Console_PhoneBook.Model;

namespace Console_PhoneBook.DataAccess
{
    public class LocalFileAccessor : IDataAccessor
    {
        private readonly FileMetaData _fileMetaData;

        public LocalFileAccessor(FileMetaData fileMetaData)
        {
            _fileMetaData = fileMetaData;
        }

        public IEnumerable<IGenericEntry>? Read()
        {
            string? fileData = default;

            if (IsFilePathValid())
            {
                try
                {
                    fileData = File.ReadAllText(_fileMetaData.FilePath);
                }
                catch (Exception)
                {
                    return null;
                }
            }

            if (fileData is null) return null;

            return ParseCSV(fileData);

        }

        public void Save(IEntriesRepository repository)
        {
            if (IsFilePathValid())
            {
                try
                {
                    File.WriteAllText(_fileMetaData.FilePath, "Data");
                }
                catch (Exception)
                {
                    throw new FieldAccessException("cannot access file to write data");
                }

            }

        }

        public bool IsFilePathValid()
        {
            var filePath = _fileMetaData.FilePath;

            if (filePath is null) return false;
            if (filePath.Length == 0) return false;

            foreach (var extension in Enum.GetValues(typeof(SaveFileFormat)))
            {
                string extensionAsString = extension.ToString().ToLower();
                if (!filePath.EndsWith(extensionAsString))
                {
                    return false;
                }
            }
            return true;
        }

        public IEnumerable<IGenericEntry> ParseCSV(string fileData)
        {
            string[] entries = fileData.Split('\n');

            foreach (var entry in entries)
            {
                //string[] data = entries.s
            }
            throw new NotImplementedException();
        }
    }
}