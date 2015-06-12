using System;
using USC.GISResearchLab.Common.Utils.Files;

namespace USC.GISResearchLab.Common.Utils.HTML
{
    public class HTMLUtils
    {

        public static string HTMLSafe(int i)
        {
            return Convert.ToString(i);
        }

        public static string HTMLSafe(bool b)
        {
            return Convert.ToString(b);
        }

        public static string HTMLSafe(DateTime d)
        {
            return Convert.ToString(d);
        }

        public static string HTMLSafe(double d)
        {
            return Convert.ToString(d);
        }

        public static string HTMLSafe(string s)
        {
            string ret = "";
            if (s != null)
            {
                ret = s;
                if (ret.IndexOf("&") != -1)
                {
                    ret = ret.Replace("&", "&amp;");
                }
                else if (ret.IndexOf("<") != -1)
                {
                    ret = ret.Replace("<", "&lt;");
                }
                if (ret.IndexOf(">") != -1)
                {
                    ret = ret.Replace("<", "&gt;");
                }
                if (ret.IndexOf("\"") != -1)
                {
                    ret = ret.Replace("\"", "&quot;");
                }
            }
            return ret;
        }

        public static string stripHTML(string s)
        {
            string ret = "";
            if (s != null)
            {
                ret = s;
                if (ret.IndexOf("&lt;") != -1)
                {
                    ret = ret.Replace("&lt;", "<");
                }
                if (ret.IndexOf("&gt;") != -1)
                {
                    ret = ret.Replace("&gt;", "<");
                }
                if (ret.IndexOf("&quot;") != -1)
                {
                    ret = ret.Replace("&quot;", "\"");
                }
            }
            return ret;
        }

        public static void prependTags(string fileName, string[] tags, bool checkForExistenceFirst)
        {
            if (FileUtils.FileExists(fileName))
            {
                string contents = FileUtils.AsString(fileName);
                bool changed = false;
                for (int i = tags.Length - 1; i >= 0; i--)
                {
                    string tag = tags[i];
                    if (checkForExistenceFirst)
                    {
                        if (contents.IndexOf(tag, StringComparison.InvariantCultureIgnoreCase) < 0)
                        {
                            changed = true;
                            contents = tags[i] + contents;
                        }
                    }
                    else
                    {
                        changed = true;
                        contents = tags[i] + contents;
                    }
                }

                if (changed)
                {
                    FileUtils.ReplaceContents(fileName, contents);
                }
            }
            else
            {
                throw new Exception("HTMLUtils - File does not exist: " + fileName);
            }
        }
    }
}
