using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ABC_Retail2.Services
{
    public class BlobStorageService
    {
        private readonly BlobContainerClient _containerClient;

        public BlobStorageService(string connectionString, string containerName)
        {
            var blobServiceClient = new BlobServiceClient(connectionString);
            _containerClient = blobServiceClient.GetBlobContainerClient(containerName);
            _containerClient.CreateIfNotExists();
        }

        public async Task UploadBlobAsync(IFormFile file)
        {
            var blobClient = _containerClient.GetBlobClient(file.FileName);
            using var stream = file.OpenReadStream();
            await blobClient.UploadAsync(stream, true);
        }

        public async Task<string[]> ListBlobsAsync()
        {
            var blobs = new List<string>();
            await foreach (var blob in _containerClient.GetBlobsAsync())
                blobs.Add(blob.Name);
            return blobs.ToArray();
        }
    }
}
