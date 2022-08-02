using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FilesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllFiles()
        {
            var directoryInfo = new DirectoryInfo("./Uploads");
            var file = "";
            List<Object> files = new List<Object>();
            foreach (var item in directoryInfo.GetFiles())
            {
                var model = new
                {
                    dirName = item.DirectoryName,
                    FileName = item.Name,
                    Extension = item.Extension,
                    CreationTime = item.CreationTime,
                    LastAccessTime = item.LastAccessTime
                };
                
                files.Add(model);
                
            }

            return Ok(files);
        }

        [HttpGet("{fileName}")]
        public IActionResult DownloadFile(string fileName)
        {
            var filePath = string.Format("./Uploads/{0}", fileName);
            var bytes = System.IO.File.ReadAllBytes(filePath);
            return File(bytes, "application/pdf", fileName);
        }
        [HttpPost]
        public IActionResult Upload([FromForm(Name ="Files")] List<IFormFile> files)
        {
            var file = files.First();
            var fileName = string.Format("./Uploads/{0}", file.FileName);
            using (var stream = new FileStream(fileName, FileMode.Append))
            {
                file.CopyTo(stream);
            }
            return Ok("File Uploaded");
        }
    }
}
