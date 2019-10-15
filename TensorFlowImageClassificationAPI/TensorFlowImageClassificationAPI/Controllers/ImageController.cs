using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TensorFlowImageClassificationAPI.Service;

namespace TensorFlowImageClassificationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {

        public ImageController()
        {

        }

        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return Content("file not selected");

            string path = @"../../../inputs/images";
            path = GetAbsolutePath(path);

            var pathImage = Path.Combine(Path.Combine(path, $"image1.jpg" ));
            
            using (var stream = new FileStream(pathImage, FileMode.Create))
            {
                await file.CopyToAsync(stream);
                stream.Close();
            }
            
            return Ok(new ImageClassification().Classificate());
        }

        public static string GetAbsolutePath(string relativePath)
        {
            FileInfo _dataRoot = new FileInfo(typeof(Program).Assembly.Location);
            string assemblyFolderPath = _dataRoot.Directory.FullName;
            string fullPath = Path.Combine(assemblyFolderPath, relativePath);
            return fullPath;
        }
    }
}
