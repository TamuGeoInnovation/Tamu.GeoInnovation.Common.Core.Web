using System;
using System.Web;
using System.Web.UI;

namespace USC.GISResearchLab.Common.Utils.Web.Cookies
{
    public class CookieUtils
    {

        public static void ClearAllCookies(Page page)
        {
            ClearAllCookies(page.Request, page.Response);
        }

        public static void ClearAllCookies(HttpRequest request, HttpResponse response)
        {
            HttpCookieCollection existingCookies = request.Cookies;
            HttpCookieCollection outputCookies = new HttpCookieCollection();

            if (existingCookies != null)
            {
                for (int i = 0; i < existingCookies.Count; i++)
                {
                    HttpCookie cookie = existingCookies[i];
                    cookie.Value = "";
                    cookie.Expires = DateTime.Now.Subtract(new TimeSpan(24, 1, 1));
                    outputCookies.Add(cookie);
                }
            }

            for (int i = 0; i < outputCookies.Count; i++)
            {
                HttpCookie cookie = outputCookies[i];
                response.Cookies.Add(cookie);
            }
        }

        public static void SetCookie(MasterPage page, string name, object value)
        {
            SetCookie(page, name, Convert.ToString(value), Convert.ToDouble(120));
        }

        public static void SetCookie(Page page, string name, object value)
        {
            SetCookie(page, name, Convert.ToString(value), Convert.ToDouble(120)); 
        }

        public static void SetCookie(Page page, string name, string value)
        {
            SetCookie(page, name, value, Convert.ToDouble(120));
        }

        public static void SetCookie(MasterPage page, string name, string value, double expirationMinutes)
        {
            SetCookie(page.Request, page.Response, name, value, expirationMinutes);
        }

        public static void SetCookie(Page page, string name, string value, double expirationMinutes)
        {
            SetCookie(page.Request, page.Response, name, value, expirationMinutes);
        }

        public static void SetCookie(HttpRequest request, HttpResponse response, string name, string value)
        {
            SetCookie(request, response, name, value, Convert.ToDouble(120));
        }

        public static void SetCookie(HttpRequest request, HttpResponse response, string name, string value, double expirationMinutes)
        {
            HttpCookie cookie = request.Cookies[name];
            if (cookie == null)
            {
                cookie = new HttpCookie(name);
            }

            cookie.Value = value;
            cookie.Expires = DateTime.Now.AddMinutes(expirationMinutes);
            response.Cookies.Add(cookie);
        }

        public static void ExpireCookie(MasterPage page, string name)
        {
            ExpireCookie(page.Request, page.Response, name);
        }

        public static void ExpireCookie(Page page, string name)
        {
            ExpireCookie(page.Request, page.Response, name);
        }

        public static void ExpireCookie(HttpRequest request, HttpResponse response, string name)
        {
            HttpCookie cookie = request.Cookies[name];

            if (cookie == null)
            {
                cookie = new HttpCookie(name);
            }

            cookie.Value = "";
            cookie.Expires = DateTime.Now.Subtract(new TimeSpan(24, 1, 1));
            response.Cookies.Add(cookie);
        }

        public static string GetCookie(Page page, string name)
        {
            return GetCookie(page.Request, name);
        }

        public static string GetCookie(HttpRequest request, string name)
        {
            string ret = null;
            HttpCookie cookie = request.Cookies[name];

            if (cookie != null)
            {
                ret = cookie.Value;
            }

            return ret;
        }

    }
}

