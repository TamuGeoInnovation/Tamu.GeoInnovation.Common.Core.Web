using System;
using System.Net;
using System.Web;

namespace USC.GISResearchLab.Common.Utils.Web.URLs
{
    public class URLUtils
    {

        public static bool isValidURL(string url)
        {
            return (checkUrl(url) == HttpStatusCode.OK);
        }

        public static HttpStatusCode checkUrl(string url)
        {
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(url);
            HttpStatusCode code = new HttpStatusCode();
            HttpWebResponse myResponse = null;
            try
            {
                myResponse = (HttpWebResponse)myRequest.GetResponse();
                code = myResponse.StatusCode;
            }
            catch (WebException)
            {
                //TODO: Error catching; 
            }
            return code;
        }

        public static string GetUrlContent(string url)
        {
            return GetUrlContent(url, null, null);
        }

        public static string GetUrlContent(string url, string userName, string password)
        {
            return GetUrlContent(url, userName, password, null);
        }

        public static string GetUrlContent(string url, string userName, string password, string cookies)
        {
            return GetUrlContent(url, userName, password, cookies, null, null);
        }

        public static string GetUrlContent(string url, string userName, string password, string cookies, string userAgent, string referrer)
        {
            string ret = null;
            System.IO.Stream st = null;
            System.IO.StreamReader sr = null;
            try
            {
                System.Net.HttpWebRequest req = (HttpWebRequest)System.Net.HttpWebRequest.Create(url);

                if (userName != null && password != null)
                {
                    req.Credentials = new System.Net.NetworkCredential(userName, password);
                }

                if (!String.IsNullOrEmpty(cookies))
                {
                    if (req.CookieContainer == null)
                    {
                        req.CookieContainer = new CookieContainer();
                        //((HttpWebRequest)req).CookieContainer.Add(new Cookie("domain", req.Address.DnsSafeHost));
                    }

                    string[] cookieList = cookies.Split(';');
                    if (cookieList != null)
                    {
                        foreach (string cookiePair in cookieList)
                        {
                            string[] cookieParts = cookiePair.Split(new char[] { '=' }, 2);
                            if (cookieParts != null)
                            {
                                string name = cookieParts[0];
                                if (!String.IsNullOrEmpty(name))
                                {
                                    name = name.Trim();
                                }

                                string val = cookieParts[1];
                                if (!String.IsNullOrEmpty(val))
                                {
                                    val = val.Trim();
                                }

                                val = HttpUtility.UrlEncode(val);
                                ((HttpWebRequest)req).CookieContainer.Add(new Cookie(name, val) { Domain = req.Address.DnsSafeHost });
                            }
                        }
                    }
                }

                if (!String.IsNullOrEmpty(userAgent))
                {
                    ((HttpWebRequest)req).UserAgent = userAgent;
                }

                if (!String.IsNullOrEmpty(referrer))
                {
                    ((HttpWebRequest)req).Referer = referrer;
                }

                // add chrome defaults
                ((HttpWebRequest)req).Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";

                // these ones are giving errors about settign them
                //((HttpWebRequest)req).Connection = "keep-alive";
                //((WebRequest)req).Ho.Add(HttpRequestHeader.Host, req.RequestUri.Host);
                //((HttpWebRequest)req).Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip, deflate, sdch");
                //((HttpWebRequest)req).Headers.Add(HttpRequestHeader.AcceptLanguage, "en-US,en;q=0.8");


                System.Net.WebResponse resp = req.GetResponse();

                st = resp.GetResponseStream();
                sr = new System.IO.StreamReader(st);

                if (sr != null)
                {
                    ret = sr.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error in GetUrlContent: " + e.Message);
                //return string.Empty;
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                }

                if (st != null)
                {
                    st.Close();
                }
            }

            return ret;
        }

        public static string getHostName()
        {
            return Dns.GetHostName();

        }

        public static string HTMLDecode(string s)
        {
            string ret = s;

            if (!String.IsNullOrEmpty(s))
            {
                ret = HttpUtility.HtmlDecode(s);
            }

            return ret;
        }
    }
}
