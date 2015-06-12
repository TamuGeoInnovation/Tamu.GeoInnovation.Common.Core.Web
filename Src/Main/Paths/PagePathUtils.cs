using System;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;

namespace USC.GISResearchLab.Common.Core.Utils.Web.Paths
{
    public class PagePathUtils
    {
        public static string GetPathFromRoot(string pathWithoutRoot)
        {
            //string hostName = "";

            //// first try the http application
            //if (HttpContext.Current.Application != null)
            //{
            //    object objHostName = HttpContext.Current.Application["HTTP_HOST"];
            //    if (objHostName != null)
            //    {
            //        hostName = objHostName.ToString();
            //    }
            //}

            //// then try the http request
            //if (String.IsNullOrEmpty(hostName))
            //{
            //    if (HttpContext.Current.Request != null)
            //    {
            //        hostName = HttpContext.Current.Request.Url.Host;
            //    }
            //}

            string ApplicationPath = HttpContext.Current.Request.ApplicationPath;
            StringBuilder ret = new StringBuilder();

            //if (!String.IsNullOrEmpty(hostName))
            //{
            //    ret.Append(hostName);
            //}

            ret.Append(ApplicationPath);

            if (!pathWithoutRoot.StartsWith("/") && !ApplicationPath.EndsWith("/"))
            {
                ret.Append("/");
            }
            ret.Append(pathWithoutRoot);
            return ret.ToString();
        }

        public static string GetCurrentPageName()
        {
            string ret = "";
            try
            {
                string path = HttpContext.Current.Request.Url.AbsolutePath;
                FileInfo fileInfo = new FileInfo(path);
                ret = fileInfo.Name;
            }
            catch (Exception e)
            {
                throw new Exception("Exception occured GetCurrentPageName: " + e.Message, e);
            }
            return ret;
        }

        public static string GetCurrentUrlWithoutQueryString()
        {
            string ret = "";
            try
            {
                string url = HttpContext.Current.Request.RawUrl;
                string[] parts = url.Split('?');
                ret = parts[0];
            }
            catch (Exception e)
            {
                throw new Exception("Exception occured GetCurrentUrlWithoutQueryString: " + e.Message, e);
            }
            return ret;
        }

        public static string GetFolderPath(HttpRequest request, string basePath)
        {
            return GetFolderPath(null, request, basePath);
        }

        public static string GetFolderPath(Page page, HttpRequest request, string basePath)
        {
            string ret = "";


            Uri basePathUri = new Uri(basePath);
            string[] basePathParts = basePathUri.Segments;

            if (request.Url != null)
            {
                string originalUrl = request.Url.ToString();

                if (request.Url.IsFile)
                {

                }
                else
                {

                    string[] requestParts = request.Url.Segments;

                    int requestPartsLength = requestParts.Length;

                    for (int i = 0; i < requestPartsLength; i++)
                    {
                        string requestPart = requestParts[i];

                        if (!String.IsNullOrEmpty(requestPart))
                        {
                            if (String.Compare(requestPart, "/", true) != 0)
                            {
                                if (i < basePathParts.Length)
                                {
                                    string basePart = basePathParts[i];

                                    if (!requestPart.Contains(".")) // skip all pages "default.aspx"
                                    {
                                        if (String.Compare(requestPart, basePart, true) != 0)
                                        {
                                            if (!String.IsNullOrEmpty(ret))
                                            {
                                                if (!ret.EndsWith("/"))
                                                {
                                                    ret += "/";
                                                }
                                            }
                                            ret += requestPart;
                                        }

                                    }
                                }
                                else
                                {
                                    if (!requestPart.Contains(".")) // skip all pages "default.aspx"
                                    {
                                        if (!String.IsNullOrEmpty(ret))
                                        {
                                            if (!ret.EndsWith("/"))
                                            {
                                                ret += "/";
                                            }
                                        }
                                        ret += requestPart;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return ret;
        }
    }
}
