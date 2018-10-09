using OtpNet;
using System.Text;
using System.Web.Http;

namespace OTP.Controllers
{
    public class OtpController : ApiController
    {
        [HttpGet]
        public string Create()
        {
            return OtpGenerator.Create(1001);
        }

        [HttpGet]
        public int Remaining()
        {
            return OtpGenerator.Remaining(1001);
        }

        [HttpGet]
        public bool Verify(string otp)
        {
            return OtpGenerator.Verify(otp, 1001);
        }
    }
}
