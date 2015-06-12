using System.Web.Security;
using System.Web.UI;
using USC.GISResearchLab.Common.Utils.Web.Cookies;

namespace USC.GISResearchLab.Common.Utils.Web.Sessions
{
    public class SessionUtils
    {

        public static void LogoutSession(Page page)
        {
            FormsAuthentication.SignOut();
            page.Session.Clear();
            page.Session.Abandon();
            //page.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //page.Response.Cache.SetExpires(DateTime.Now);
            //page.Response.Cookies.Clear();
            CookieUtils.ExpireCookie(page, FormsAuthentication.FormsCookieName);
            CookieUtils.ExpireCookie(page, "UserId");
            CookieUtils.SetCookie(page, "ASP.NET_SessionId", "");
        }

        public static void LogoutSession(MasterPage page)
        {
            FormsAuthentication.SignOut();
            page.Session.Clear();
            page.Session.Abandon();
            //page.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //page.Response.Cache.SetExpires(DateTime.Now);
            //page.Response.Cookies.Clear();
            CookieUtils.ExpireCookie(page, FormsAuthentication.FormsCookieName);
            CookieUtils.ExpireCookie(page, "UserId");
            CookieUtils.SetCookie(page, "ASP.NET_SessionId", "");
        }
    }
}
