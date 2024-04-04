using AWSApp.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWSApp.Common.Services
{
    public class CaptchaService: ICaptchaService
    {
        public (string ImageBase64, string CaptchaCode) GenerateCaptcha(int width, int height)
        {
            using (var bitmap = new Bitmap(width, height))
            using (var graphics = Graphics.FromImage(bitmap))
            using (var font = new Font(FontFamily.GenericMonospace, 30, FontStyle.Bold))
            using (var brush = new SolidBrush(Color.Blue))
            {
                graphics.FillRectangle(new SolidBrush(Color.LightGray), 0, 0, width, height);

                var random = new Random();
                var captchaCode = GenerateRandomCaptchaCode();
                for (var i = 0; i < captchaCode.Length; i++)
                {
                    graphics.DrawString(captchaCode[i].ToString(), font, brush, i * 30, 0);
                }

                using (var stream = new MemoryStream())
                {
                    bitmap.Save(stream, ImageFormat.Png);
                    var imageBase64 = Convert.ToBase64String(stream.ToArray());
                    return (imageBase64, captchaCode);
                }
            }
        }

        public string GenerateRandomCaptchaCode()
        {
            // Generate a random code (e.g., alphanumeric)
            const string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            var captchaCode = new char[6];
            for (var i = 0; i < captchaCode.Length; i++)
            {
                captchaCode[i] = characters[random.Next(characters.Length)];
            }
            return new string(captchaCode);
        }
    }
}
