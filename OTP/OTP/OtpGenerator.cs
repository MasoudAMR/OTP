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
        private static Dictionary<int, Totp> _totps = new Dictionary<int, Totp>();
        private static Totp GetOTP(int regionCode)
        {
            Totp totp;
            if (_totps.Keys.Contains(regionCode))
                totp = _totps[regionCode];
            else
            {
                totp = new Totp(Encoding.ASCII.GetBytes($"Masoud{regionCode}"), 180, OtpHashMode.Sha512, 8);
                _totps.Add(regionCode, totp);
            }
            return totp;
        }
        public static string Create(int regionCode)
        {
            var totp = GetOTP(regionCode);
            var result = totp.ComputeTotp(DateTime.UtcNow);
            return result;
        }

        public static int Remaining(int regionCode)
        {
            var totp = GetOTP(regionCode);
            var result = totp.RemainingSeconds(DateTime.UtcNow);
            return result;
        }
        public static bool Verify(string otp, int regionCode)
        {
            var totp = GetOTP(regionCode);
            var result = totp.VerifyTotp(otp, out long timeWindowUsed, VerificationWindow.RfcSpecifiedNetworkDelay);
            _totps.Remove(regionCode);
            return result;
        }
    }
}