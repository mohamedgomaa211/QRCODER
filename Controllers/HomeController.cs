using Microsoft.AspNetCore.Mvc;
using QRCode.Helper.QRCodeGenerator;
using QRCODE.Models;
using System.Diagnostics;

namespace QRCODE.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IQRCodeGeneratorHelper _codeGenerator;

        public HomeController(ILogger<HomeController> logger, IQRCodeGeneratorHelper codeGenerator)
        {
            _logger = logger;
            _codeGenerator= codeGenerator;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string text)

        {
            if (string.IsNullOrEmpty(text))
            {
                return BadRequest(string.Empty);
            }
            byte[] QRCodeAsBytes = _codeGenerator.GenerateQRCode(text);

            string QRCodeAsImageBase64 =
            $"data:image/png;base64,{Convert.ToBase64String(QRCodeAsBytes)}";

            ViewData["QR"] = QRCodeAsImageBase64;
            return View();

        }

       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}