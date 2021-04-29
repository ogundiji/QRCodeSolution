using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace netCoreQR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QrCodeController : ControllerBase
    {

        [HttpGet]
        [Route("{encodeValue}")]
        public IActionResult Get(string encodeValue)
        {
            if (string.IsNullOrEmpty(encodeValue))
            {
                encodeValue = "welcome user";
            }
            var image = QrCodeGenerator.GenerateByteArray(encodeValue);
            return File(image, "image/jpeg");
        }
    }
}
