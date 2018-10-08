using OtpNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace OTP
{
    public static class OtpGenerator
    {
        private static Totp _totp = new Totp(Encoding.ASCII.GetBytes("Pajoohesh"), 60, OtpHashMode.Sha512, 8);
        public static string Create()
        {
            var result = _totp.ComputeTotp(DateTime.UtcNow);
            return result;
        }

        public static int Remaining()
        {
            var result = _totp.RemainingSeconds(DateTime.UtcNow);
            return result;
        }
        public static bool Verify(string otp)
        {
            var result = _totp.VerifyTotp(otp, out long timeWindowUsed, VerificationWindow.RfcSpecifiedNetworkDelay);
            return result;
        }
    }
}