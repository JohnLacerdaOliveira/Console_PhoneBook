﻿using Console_PhoneBook.DataStorage.FileAccess;
using Console_PhoneBook.Model;

namespace Console_PhoneBook.DataStorage.DataAccess
{
    public abstract class GenericRepository : IGenericRepository
    {
        public abstract IEnumerable<IGenericContact> Parse(string fileData);
        public abstract string Serialize(IEnumerable<IGenericContact> register);

        public IEnumerable<IGenericContact> LoadFromFile(FileMetadata fileMetaData)
        {
            string? fileData = default;

            if (!File.Exists(fileMetaData.FilePath)) return Enumerable.Empty<IGenericContact>();

            try
            {
                fileData = File.ReadAllText(fileMetaData.FilePath);
                if (fileData.Length == 0) return Enumerable.Empty<IGenericContact>();
            }
            catch (Exception)
            {
                throw new IOException($"An error occcured while reading from the file: {fileMetaData.FilePath}");
            }

            return Parse(fileData);
        }

        public void SaveToFile(IEnumerable<IGenericContact> register, FileMetadata fileMetaData)
        {
            File.WriteAllText(fileMetaData.FilePath, Serialize(register));
        }
    }
}