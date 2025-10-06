using Microsoft.AspNetCore.Mvc;
using ABC_Retail2.Services;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ABC_Retail2.Controllers
{
    public class FilesController : Controller
    {
        private readonly FileShareService _fileService;

        public FilesController(FileShareService fileService)
        {
            _fileService = fileService;
        }

        public async Task<IActionResult> Index()
        {
            var files = await _fileService.ListFilesAsync();
            return View(files);
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file != null)
                await _fileService.UploadFileAsync(file);

            return RedirectToAction("Index");
        }
    }
}
