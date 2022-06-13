using AGJProductInventory.Application.Common;
using Microsoft.AspNetCore.Mvc;

namespace AGJProductInventory.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FilesController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UploadedImage uploadedImage)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    return BadRequest(ModelState);
                }

                if (uploadedImage.OldImagePath != string.Empty)
                {
                    if (uploadedImage.OldImagePath != "images/product/placeholder.png")
                    {
                        string oldUploadedImageFileName = uploadedImage.OldImagePath.Split('/').Last();

                        System.IO.File.Delete($"{_webHostEnvironment.ContentRootPath}\\wwwroot\\images\\product\\{oldUploadedImageFileName}");
                    }
                }

                string guid = Guid.NewGuid().ToString();
                string imageFileName = guid + uploadedImage.NewImageFileExtension;

                string fullImageFileSystemPath = $"{_webHostEnvironment.ContentRootPath}\\wwwroot\\images\\product\\{imageFileName}";

                FileStream fileStream = System.IO.File.Create(fullImageFileSystemPath);
                byte[] imageContentAsByteArray = Convert.FromBase64String(uploadedImage.NewImageBase64Content);
                await fileStream.WriteAsync(imageContentAsByteArray, 0, imageContentAsByteArray.Length);
                fileStream.Close();

                string relativeFilePathWithoutTrailingSlashes = $"images/product/{imageFileName}";
                return Created("Create", relativeFilePathWithoutTrailingSlashes);
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Something went wrong on our side. Please contact the administrator. Error message: {e.Message}");
            }
        }
    }
}
