using Microsoft.AspNetCore.Mvc;
using OTP_BeugroFeladat.Core;
using OTP_BeugroFeladata.Common;

namespace OTP_BeugroFeladat.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DokumentumokController : ControllerBase
    {
        private readonly IFileManager _fileManager;

        public DokumentumokController(IFileManager fileManager)
        {
            _fileManager = fileManager;
        }

        [HttpGet]
        public IActionResult ListFolderContents()
        {
            var folderContent = _fileManager.GetFolderContent();

            return Ok(folderContent);
        }

        [HttpGet("{fileToGet}")]
        public IActionResult GetFile(string fileToGet)
        {
            var fileInBase64String = _fileManager.DownLoad(fileToGet);

            return Ok(fileInBase64String);
        }

        [HttpPost]
        public IActionResult UploadFile([FromBody] FileRequestResponse file)
        {
            _fileManager.Upload(file);

            return Ok();
        }
    }
}
