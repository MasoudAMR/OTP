using OtpNet;
using System.Text;
using System.Web.Http;

namespace OTP.Controllers
{
    public class OtpController : ApiController
    {
        Totp _totp = new Totp(Encoding.ASCII.GetBytes("Pajoohesh"), 60, OtpHashMode.Sha512, 8);
        [HttpGet]
        public string Create()
        {
            return OtpGenerator.Create();
        }

        [HttpGet]
        public int Remaining()
        {
            return OtpGenerator.Remaining();
        }

        [HttpGet]
        public bool Verify(string otp)
        {
            return OtpGenerator.Verify(otp);
        }
    }
}
