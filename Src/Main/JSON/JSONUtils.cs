using System;
using System.Web;
using System.Data;

namespace USC.GISResearchLab.Common.Core.JSON
{
    public class JSONUtils
    {

        public static string CleanUrl(string s)
        {
            string ret = "";
            if (!String.IsNullOrEmpty(s))
            {
                ret = s.Replace("/", "\\/");
            }
            return ret;
        }

        public static string CleanText(string s)
        {
            return CleanText(s, true);
        }

        public static string CleanText(string s, bool shouldHtmlEncode)
        {
            string ret = "";
            if (!String.IsNullOrEmpty(s))
            {
                ret = s;

                if (shouldHtmlEncode)
                {
                    ret = HttpUtility.HtmlEncode(s);
                }

                ret = ret.Replace("\n", "\\n")
                    .Replace("\r", "\\r")
                    .Replace("\b", "\\b")
                    .Replace("\f", "\\f")
                    .Replace("\t", "\\t")
                    .Replace("\\", "\\\\")
                    .Replace("\"", "\\\"")
                    .Replace("/", "\\/");
            }
            return ret;
        }


        public static string CleanText(Exception e)
        {
            string ret = "";
            if (e != null)
            {
                string s = e.ToString();
                ret = CleanText(s);
            }
            return ret;
        }

        public static string CleanText(double d)
        {
            string ret = "";
            string s = Convert.ToString(d);

            ret = CleanText(s);

            return ret;
        }

    }
}
