using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWSApp.Common.Interfaces
{
    public interface ICaptchaService
    {
        (string ImageBase64, string CaptchaCode) GenerateCaptcha(int width, int height);
        string GenerateRandomCaptchaCode();
    }
}
