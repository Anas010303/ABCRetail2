using Microsoft.AspNetCore.Mvc;
using ABC_Retail2.Services;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ABC_Retail2.Controllers
{
    public class MediaController : Controller
    {
        private readonly BlobStorageService _blobService;

        public MediaController(BlobStorageService blobService)
        {
            _blobService = blobService;
        }

        public async Task<IActionResult> Index()
        {
            var blobs = await _blobService.ListBlobsAsync();
            return View(blobs);
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file != null)
                await _blobService.UploadBlobAsync(file);

            return RedirectToAction("Index");
        }
    }
}
