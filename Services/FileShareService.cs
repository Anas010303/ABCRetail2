using Azure;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ABC_Retail2.Services
{
    public class FileShareService
    {
        private readonly ShareClient _shareClient;

        public FileShareService(string connectionString, string shareName)
        {
            _shareClient = new ShareClient(connectionString, shareName);
            _shareClient.CreateIfNotExists();
        }

        public async Task UploadFileAsync(IFormFile file)
        {
            var directory = _shareClient.GetDirectoryClient("");
            var fileClient = directory.GetFileClient(file.FileName);

            using var stream = file.OpenReadStream();
            await fileClient.CreateAsync(stream.Length);
            await fileClient.UploadRangeAsync(new HttpRange(0, stream.Length), stream);
        }

        public async Task<List<string>> ListFilesAsync()
        {
            var directory = _shareClient.GetDirectoryClient("");
            var files = new List<string>();
            await foreach (ShareFileItem item in directory.GetFilesAndDirectoriesAsync())
            {
                files.Add(item.Name);
            }
            return files;
        }
    }
}
