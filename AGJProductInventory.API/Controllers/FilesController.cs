using Microsoft.AspNetCore.Mvc;

namespace AGJProductInventory.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Upload([FromForm] IFormFile file)
        {
            if (file == null) return BadRequest("File is required");

            var fileName = file.FileName;
            var extension = Path.GetExtension(fileName);
            var newFileName = $"{Path.GetFileNameWithoutExtension(fileName)}-{Guid.NewGuid().ToString()}{extension}";
            var directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "product");
            var fullPath = Path.Combine(directoryPath, newFileName);

            Directory.CreateDirectory(directoryPath);

            using (var fileStream = new FileStream(fullPath, FileMode.Create, FileAccess.Write))
            {
                await file.CopyToAsync(fileStream);
            }

            return Ok($"https://localhost:7165/images/product/{newFileName}");
        }
    }
}
