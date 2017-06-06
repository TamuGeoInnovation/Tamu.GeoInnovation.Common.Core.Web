using System;
using System.Net;
using System.Web;
using System.Collections.Generic;

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
            return GetUrlContent(url, userName, password, cookies, userAgent, referrer, false);
        }


        public static string GetUrlContent(string url, string userName, string password, string cookies, string userAgent, string referrer, bool shouldGuessEncoding)
        {
            return GetUrlContent(url, userName, password, cookies, null, userAgent, referrer, shouldGuessEncoding);
        }

        public static string GetUrlContentFromHttpWebResponse(HttpWebResponse response)
        {
            string ret = null;
            System.IO.Stream st = null;
            System.IO.StreamReader sr = null;
            try
            {
                st = response.GetResponseStream();

                string charset = response.CharacterSet;

                sr = new System.IO.StreamReader(st, System.Text.Encoding.GetEncoding(charset));


                if (sr != null)
                {
                    ret = sr.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error in GetUrlContent: " + e.Message);
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

        public static string GetUrlContent(string url, string userName, string password, string cookies, Dictionary<string, string> headers, string userAgent, string referrer, bool shouldGuessEncoding)
        {
            string ret = null;

            try
            {

                HttpWebResponse response = GetUrlResponse(url, userName, password, cookies, headers, userAgent, referrer, shouldGuessEncoding);
                ret = GetUrlContentFromHttpWebResponse(response);

            }
            catch (Exception e)
            {
                throw new Exception("Error in GetUrlContent: " + e.Message);
            }

            return ret;
        }


        public static HttpWebResponse GetUrlResponse(string url, string userName, string password, string cookies, Dictionary<string, string> headers, string userAgent, string referrer, bool shouldGuessEncoding)
        {
            HttpWebResponse ret = null;

            if (shouldGuessEncoding)
            {
                return GetUrlResponseWithCharsetGuessing(url, userName, password, cookies, headers, userAgent, referrer, shouldGuessEncoding);
            }
            else
            {

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

                    ((HttpWebRequest)req).Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
                    ((HttpWebRequest)req).Headers.Add(HttpRequestHeader.AcceptCharset, "ISO-8859-1");

                    if (headers != null)
                    {
                        foreach (KeyValuePair<string, string> entry in headers)
                        {
                            ((HttpWebRequest)req).Headers.Add(entry.Key, entry.Value);
                        }

                    }


                    ret = (HttpWebResponse)req.GetResponse();


                }
                catch (Exception e)
                {
                    throw new Exception("Error in GetUrlResponse: " + e.Message);
                    //return string.Empty;
                }
            }
            return ret;
        }


        public static HttpWebResponse GetUrlResponseWithCharsetGuessing(string url, string userName, string password, string cookies, Dictionary<string, string> headers, string userAgent, string referrer, bool shouldGuessEncoding)
        {
            HttpWebResponse ret = null;
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

                ((HttpWebRequest)req).Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
                ((HttpWebRequest)req).Headers.Add(HttpRequestHeader.AcceptCharset, "ISO-8859-1");

                if (headers != null)
                {
                    foreach (KeyValuePair<string, string> entry in headers)
                    {
                        ((HttpWebRequest)req).Headers.Add(entry.Key, entry.Value);
                    }

                }


                ret = (HttpWebResponse)req.GetResponse();

                string charset = ret.CharacterSet;

                if (shouldGuessEncoding)
                {
                    Ude.CharsetDetector cdet = new Ude.CharsetDetector();
                    cdet.Feed(st);
                    cdet.DataEnd();
                    if (cdet.Charset != null)
                    {
                        Console.WriteLine("Charset: {0}, confidence: {1}", cdet.Charset, cdet.Confidence);
                        charset = cdet.Charset;
                    }
                    else
                    {
                        Console.WriteLine("Detection failed.");
                    }

                    // get the data a second time - the stream has already been read by the charset guesser


                    System.Net.HttpWebRequest req2 = (HttpWebRequest)System.Net.HttpWebRequest.Create(url);

                    if (userName != null && password != null)
                    {
                        req2.Credentials = new System.Net.NetworkCredential(userName, password);
                    }

                    if (!String.IsNullOrEmpty(cookies))
                    {
                        if (req2.CookieContainer == null)
                        {
                            req2.CookieContainer = new CookieContainer();
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
                                    ((HttpWebRequest)req2).CookieContainer.Add(new Cookie(name, val) { Domain = req.Address.DnsSafeHost });
                                }
                            }
                        }
                    }

                    if (!String.IsNullOrEmpty(userAgent))
                    {
                        ((HttpWebRequest)req2).UserAgent = userAgent;
                    }

                    if (!String.IsNullOrEmpty(referrer))
                    {
                        ((HttpWebRequest)req2).Referer = referrer;
                    }

                    ((HttpWebRequest)req2).Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
                    ((HttpWebRequest)req2).Headers.Add(HttpRequestHeader.AcceptCharset, "ISO-8859-1");


                    ret = (HttpWebResponse)req2.GetResponse();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error in GetUrlResponseWithCharsetGuessing: " + e.Message);
                //return string.Empty;
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                }

                //if (st != null)
                //{
                //    st.Close();
                //}
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
