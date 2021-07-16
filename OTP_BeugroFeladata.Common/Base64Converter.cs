using System;

namespace OTP_BeugroFeladata.Common
{
    public class Base64Converter
    {
        public string ConvertBytesToBase64(byte[] bytes)
        {
            return Convert.ToBase64String(bytes);
        }

        public byte[] ConvertBase64StringToBytes(string base64String)
        {
            return Convert.FromBase64String(base64String);
        }
    }
}
