using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace AlightApp.Infrastructure.External.Files
{
    public class SharedFileHandlerService : IFileHandlerService
    {
        private readonly string _fileSharedHost;
        private readonly ILogger _logger;

        public SharedFileHandlerService(IConfiguration configuration, ILogger logger)
        {
            _fileSharedHost = "C:\\NetworkShare\\XYZFiles\\";           //TODO :  configuration["FileSharedHost"]; 
            _logger = logger;
        }
        public async Task<bool> CreateFile(string content)
        {
            string file_path = @$"{_fileSharedHost}file_{DateTime.Now.Ticks}.txt";

            try
            {
                if (!Directory.Exists(_fileSharedHost))
                    Directory.CreateDirectory(_fileSharedHost);

                // It will create a new file because the ticks are unique
                using (FileStream fs = File.Create(file_path))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(content);
                    fs.Write(info, 0, info.Length);
                }

                // we can retrive the text to confirm the writing but it depends
                // Retrive the content and validate etc
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to create the file: {ex.Message}");
                return false;
            }

            return true;
           
        }
    }
}
