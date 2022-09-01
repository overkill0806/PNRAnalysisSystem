using System.Text;

namespace Utility
{
    public class QuickTool
    {

        public string Base64Encode(string AStr)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(AStr));
        }

        public string Base64Decode(string ABase64)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(ABase64));
        }
    }
}
