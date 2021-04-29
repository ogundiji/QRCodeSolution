﻿using QRCoder;
using System.Drawing;
using System.IO;

namespace netCoreQR
{
    public static class QrCodeGenerator
    {
        public static byte[] GenerateByteArray(string url)
        {
            var image = GenerateImage(url);
            return ImageToByte(image);
        }
        public static Bitmap GenerateImage(string url)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(10);
            return qrCodeImage;
        }

        private static byte[] ImageToByte(Image img)
        {
            using var stream = new MemoryStream();
            img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
            return stream.ToArray();
        }

    }
}
