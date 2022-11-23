using System.Security.Cryptography;
using System.Text;

namespace Progra2Proyecto.Utils
{
    public static class EncryptString
    {
        public static string GetSHA256(this string str)
        {
            SHA256 sHA256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] bytes = null;
            StringBuilder builder = new StringBuilder();
            bytes = sHA256.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < bytes.Length; i++) builder.AppendFormat("{0:x2}", bytes[i]);
            return builder.ToString();
        }
    }
}
