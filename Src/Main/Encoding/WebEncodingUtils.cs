using System;
using System.Web;

namespace USC.GISResearchLab.Common.Utils.Encoding
{
    public class WebEncodingUtils
    {

        

        public static string URLEncode(string s)
        {
            string ret = "";

            if (!String.IsNullOrEmpty(s))
            {
                ret = HttpUtility.UrlEncode(s);
            }

            return ret;
        }

        public static string URLDecode(string s)
        {
            string ret = "";

            if (!String.IsNullOrEmpty(s))
            {
                ret = HttpUtility.UrlDecode(s);
            }

            return ret;
        }
    }
}
