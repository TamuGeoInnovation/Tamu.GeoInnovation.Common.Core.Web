using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web;

namespace USC.GISResearchLab.Common.Core.Utils.Web.WebRequests
{
    public class WebRequestUtils
    {

        // from http://www.codeproject.com/KB/cs/uploadfileex.aspx#xx972854xx
        public static string SendPostRequest(string url, string contentType, NameValueCollection queryString, CookieContainer cookies)
        {

            string postdata = "?";
            if (queryString != null)
            {
                foreach (string key in queryString.Keys)
                {
                    postdata += key + "=" + queryString.Get(key) + "&";
                }
            }

            Uri uri = new Uri(url + postdata);

            string boundary = "----------" + DateTime.Now.Ticks.ToString("x");
            HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(uri);
            webrequest.CookieContainer = cookies;
            webrequest.ContentType = "multipart/form-data; boundary=" + boundary;
            webrequest.Method = "POST";

            // Build up the post message header

            StringBuilder sb = new StringBuilder();
            sb.Append("--");
            sb.Append(boundary);
            sb.Append("\r\n");
            sb.Append("Content-Disposition: form-data; name=\"");
            //sb.Append(fileFormName);
            //sb.Append("\"; filename=\"");
            //sb.Append(Path.GetFileName(uploadfile));
            sb.Append("\"");
            sb.Append("\r\n");
            sb.Append("Content-Type: ");
            sb.Append(contentType);
            sb.Append("\r\n");
            sb.Append("\r\n");

            string postHeader = sb.ToString();
            byte[] postHeaderBytes = Encoding.UTF8.GetBytes(postHeader);
            byte[] boundaryBytes = Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");

            //FileStream fileStream = new FileStream(uploadfile, FileMode.Open, FileAccess.Read);
            //long length = postHeaderBytes.Length + fileStream.Length + boundaryBytes.Length;
            long length = postHeaderBytes.Length + boundaryBytes.Length;
            webrequest.ContentLength = length;

            Stream requestStream = webrequest.GetRequestStream();

            requestStream.Write(postHeaderBytes, 0, postHeaderBytes.Length);

            // Write out the file contents

            //byte[] buffer = new Byte[checked((uint)Math.Min(4096, (int)fileStream.Length))];
            //int bytesRead = 0;
            //while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0) requestStream.Write(buffer, 0, bytesRead);

            // Write out the trailing boundary

            requestStream.Write(boundaryBytes, 0, boundaryBytes.Length);
            WebResponse responce = webrequest.GetResponse();
            Stream s = responce.GetResponseStream();
            StreamReader sr = new StreamReader(s);

            return sr.ReadToEnd();
        }

        public static string BuildAndSendFromRequestString(string requestString, HttpRequest retryRequest)
        {
            string ret = null;
            try
            {
                HttpWebRequest httpWebRequest = null;
                //CookieContainer cookieContainer = new CookieContainer();
                string cookieHeader = "";
                string postData = "";
                string URL = "";

                string[] lines = requestString.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);



                for (int i = 0; i < lines.Length; i++)
                {
                    string line = lines[i];

                    // 1st line is the get/post
                    if (i == 0)
                    {
                        string[] parts = line.Split(new string[] { " " }, StringSplitOptions.None);

                        URL = "http://" + retryRequest.Url.Host + parts[1];
                        httpWebRequest = (HttpWebRequest)WebRequest.Create(URL);

                        httpWebRequest.Method = parts[0];
                        if (parts[2] == "HTTP/1.1")
                        {
                            httpWebRequest.ProtocolVersion = HttpVersion.Version11;
                        }
                        else
                        {
                            httpWebRequest.ProtocolVersion = HttpVersion.Version10;
                        }
                    }
                    else
                    {
                        // lines with colons are header line
                        if (line.IndexOf(":") != -1)
                        {
                            string[] parts = line.Split(new string[] { ":" }, StringSplitOptions.None);
                            if (parts.Length == 2)
                            {
                                string headerType = parts[0].Trim();
                                string headerValue = parts[1].Trim();

                                if (headerType.ToLower() == "accept")
                                {
                                    httpWebRequest.Accept = headerValue;
                                }
                                else if (headerType.ToLower() == "cookie")
                                {
                                    //httpWebRequest.CookieContainer = cookieContainer;

                                    string[] cookieList = headerValue.Split(';');
                                    {
                                        if (cookieList.Length > 0)
                                        {
                                            for (int j = 0; j < cookieList.Length; j++)
                                            {
                                                string[] cookieParts = cookieList[j].Split('=');
                                                if (cookieParts.Length == 2)
                                                {
                                                    string cookieName = cookieParts[0].Trim();
                                                    string cookieValue = cookieParts[1].Trim();

                                                    if (i > 0)
                                                    {
                                                        cookieHeader += ";";
                                                    }

                                                    // replace the original authentication with that of the retry user
                                                    if (cookieName.ToLower() == "asp.net_sessionid" || cookieName.ToLower() == "authcookie")
                                                    {
                                                        cookieHeader += cookieName + "=" + retryRequest.Cookies[cookieName].Value;
                                                    }
                                                    else
                                                    {
                                                        cookieHeader += cookieList[j];
                                                    }
                                                }

                                            }
                                            httpWebRequest.Headers.Add("Cookie", cookieHeader);
                                        }
                                    }
                                }
                                else if (headerType.ToLower() == "connection")
                                {
                                    if (headerValue.ToLower() == "keep-alive")
                                    {
                                        httpWebRequest.KeepAlive = true;
                                    }
                                }
                                else if (headerType.ToLower() == "connection-groupname")
                                {
                                    httpWebRequest.ConnectionGroupName = headerValue;
                                }
                                else if (headerType.ToLower() == "content-type")
                                {
                                    httpWebRequest.ContentType = headerValue;
                                }
                                else if (headerType.ToLower() == "content-length")
                                {
                                    // do nothing yet, handled later
                                }
                                else if (headerType.ToLower() == "expect")
                                {

                                    // do nothing, can't be modified

                                    //httpWebRequest.Expect = headerValue;
                                }
                                else if (headerType.ToLower() == "host")
                                {
                                    //do nothing, can't be modified
                                }
                                else if (headerType.ToLower() == "keep-alive")
                                {
                                    //do nothing, use default timeout

                                    //httpWebRequest.Timeout = Convert.ToInt32(headerValue);
                                }
                                else if (headerType.ToLower() == "media-type")
                                {
                                    httpWebRequest.MediaType = headerValue;
                                }
                                else if (headerType.ToLower() == "referer")
                                {
                                    httpWebRequest.Referer = headerValue;
                                }
                                else if (headerType.ToLower() == "transfer-encoding")
                                {
                                    httpWebRequest.TransferEncoding = headerValue;
                                }
                                else if (headerType.ToLower() == "user-agent")
                                {
                                    httpWebRequest.UserAgent = headerValue;
                                }

                                else
                                {
                                    httpWebRequest.Headers.Add(headerType, headerValue);
                                }
                            }


                        }
                        // lines without colons are post parameter linea
                        else
                        {
                            // zero length line is the space line
                            if (line.Length == 0)
                            {
                                // do nothing
                            }
                            else
                            {
                                postData = line;
                            }
                        }
                    }

                    //string address;
                    //string postData;



                    //string responseData;
                    //Cookie cookie;

                    //postData = "pageNumber=0&firmName=&postcodeOut=E1&postcodeIn=&searchType=1&currAuthorisedInd=on&ddd=Submit";
                    //address = "http://www.fsa.gov.uk/register/firmMainSearch.do;" + cookie.Name + "=" + cookie.Value;

                    //ret.Method = "POST";

                    //ret.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*";
                    //byte[] bytes = Encoding.ASCII.GetBytes(postData);
                    //ret.ContentLength = bytes.Length;

                    //ret.Referer = "http://www.fsa.gov.uk/register/firmMainSearch.do;";// +cookie.Name + "=" + cookie.Value;
                    //ret.Headers.Add("Cookie", cookie.Name + "=" + cookie.Value);
                    //ret.Headers.Add("Accept-Encoding", "gzip, deflate");
                    //ret.Headers.Add("Accept-Language", "en-us");
                    //ret.Headers.Add("UA-CPU", "x86");
                    //ret.KeepAlive = true;
                    //ret.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; .NET CLR 2.0.50727)";
                    //ret.ContentType = "application/x-www-form-urlencoded";
                    //ret.CachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.NoCacheNoStore);
                }

                if (httpWebRequest.Method != "GET")
                {
                    byte[] bytes = Encoding.ASCII.GetBytes(postData);
                    httpWebRequest.ContentLength = bytes.Length;
                    StreamWriter requestWriter = new StreamWriter(httpWebRequest.GetRequestStream());
                    requestWriter.Write(postData);
                    requestWriter.Close();
                }

                //if (principal != null)
                //{
                //    HttpCookie authCookie = retryRequest.Cookies[FormsAuthentication.FormsCookieName];
                //    if (authCookie != null)
                //    {
                //        FormsAuthenticationTicket authTicket = null;
                //        authTicket = FormsAuthentication.Decrypt(authCookie.Value);

                //        if (authTicket != null)
                //        {
                //            FormsIdentity formsIdentity = new FormsIdentity(authTicket);
                //            httpWebRequest.Credentials = formsIdentity;
                //        }
                //    }

                //    httpWebRequest.Credentials = CredentialCache.DefaultCredentials;
                //}

                HttpWebResponse webResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                StreamReader responseReader = new StreamReader(webResponse.GetResponseStream());
                ret = responseReader.ReadToEnd();
                responseReader.Close();
                webResponse.Close();
            }
            catch (Exception e)
            {
                throw new Exception("En error occured sending http request: " + e.Message);
            }

            return ret;
        }
        public static HttpWebResponse Post(string url, string contentType, NameValueCollection headerProperties, string postData)
        {
            return Post(url, contentType, headerProperties, (new UTF8Encoding()).GetBytes(postData));
        }

        // Kaveh's version
        public static HttpWebResponse Post(string url, string contentType, NameValueCollection headerProperties, byte[] postData)
        {
            HttpWebRequest request = null;

            request = (HttpWebRequest)WebRequest.Create(new Uri(url));
            request.Method = "POST";
            request.ContentType = contentType;
            request.ContentLength = postData.Length;
            request.Headers.Add(headerProperties);

            if (url.StartsWith("https://"))
            {
                X509Certificate xCert = new X509Certificate();

                // xCert = X509Certificate.CreateFromCertFile("");
                // request.ClientCertificates.Add(xCert);

                // Kaveh: the following is a hack to make a secure web request post. Only for dev purpose only.
                // For production we should use the X509Certificate class to create a certification object from a certification file.

                ServicePointManager.ServerCertificateValidationCallback =
                    delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
            }

            using (Stream writeStream = request.GetRequestStream())
            {
                writeStream.Write(postData, 0, postData.Length);
            }
            return (HttpWebResponse)(request.GetResponse());
        }


    }

}
