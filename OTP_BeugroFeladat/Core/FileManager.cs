using Microsoft.Extensions.Configuration;
using OTP_BeugroFeladata.Common;
using System;
using System.Collections.Generic;
using System.IO;

namespace OTP_BeugroFeladat.Core
{
    public class FileManager : IFileManager
    {
        private Base64Converter _base64Converter;
        private string _path;
        public FileManager(IConfiguration configuration)
        {
            _base64Converter = new Base64Converter();
            _path = configuration.GetValue<string>("ApplicationFolderPath");
        }
        public void Upload(FileRequestResponse request)
        {
            var saveFileToPath = $"{_path}{request.FileName}";
            var fileBytes = _base64Converter.ConvertBase64StringToBytes(request.Content);

            File.WriteAllBytes(saveFileToPath, fileBytes);
        }

        public FileRequestResponse DownLoad(string fileName)
        {
            try
            {
                var fileAsByteArray = File.ReadAllBytes($"{_path}{fileName}");

                return new FileRequestResponse
                {
                    FileName = fileName,
                    Content = _base64Converter.ConvertBytesToBase64(fileAsByteArray)
                };
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<string> GetFolderContent()
        {
            if (!Directory.Exists(_path))
            {
                return null;
            }
            var fileNames = new List<string>();
            string[] files = Directory.GetFiles(_path);
            foreach (string file in files)
            {
                fileNames.Add(Path.GetFileName(file));
            }

            return fileNames;
        }
    }
}
