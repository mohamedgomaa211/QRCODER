using Microsoft.AspNetCore.Mvc;
using QRCODE.Models;
using QRCoder;
using System.Drawing.Imaging;
using System.Drawing;


using System.Reflection.Emit;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace QRCODE.Controllers
{
    public class QRController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            

            return View();
        }
        [HttpPost]
        public IActionResult Index(QRCodeModel qRCode)
        {

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode("The text which should be encoded.", QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);

            return View();
        }


        //private static byte[] BitmapToBytes(Bitmap img)
        //{
        //    using (MemoryStream stream = new MemoryStream())
        //    {
        //        img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
        //        return stream.ToArray();
        //    }
        //}
    }
}
