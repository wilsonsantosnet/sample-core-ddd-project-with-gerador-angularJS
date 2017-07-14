using Common.API;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Threading.Tasks;
using Sample.Api.Controllers;

namespace Sample.Api.Controllers
{
    [Route("api/document/download")]
    public class DownloadController : Controller
    {

        private readonly ILogger _logger;
        private readonly IHostingEnvironment _env;

        public DownloadController(ILoggerFactory logger, IHostingEnvironment env)
        {
            this._logger = logger.CreateLogger<UplaodController>();
            this._env = env;
        }

      
        [HttpGet("{file}")]
        public async Task<IActionResult> Get(string file)
        {
            var uploads = Path.Combine(this._env.ContentRootPath, "upload");
            var filePath = $"{uploads}\\{file}";
            byte[] bytes;

            if (System.IO.File.Exists(filePath))
            {
                using (FileStream SourceStream = System.IO.File.Open(filePath, FileMode.Open))
                {
                    bytes = new byte[SourceStream.Length];
                    await SourceStream.ReadAsync(bytes, 0, (int)SourceStream.Length);
                }
                return File(bytes, "image/png");
            }

            var fileVazio = $"{uploads}\\vazio.png";

            using (FileStream SourceStream = System.IO.File.Open(fileVazio, FileMode.Open))
            {
                bytes = new byte[SourceStream.Length];
                await SourceStream.ReadAsync(bytes, 0, (int)SourceStream.Length);
            }

            return File(bytes, "image/png");
        }
    }
}