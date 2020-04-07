using System;
using System.Reflection;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using USC.GISResearchLab.Common.Utils.Web.Cookies;

namespace USC.GISResearchLab.Common.Core.Utils.Web.Authentication.Forms
{
    public class FormsAuthenticationUtils
    {

        public static GenericPrincipal AuthenticateAndRenew(HttpRequest Request, HttpResponse Response, int userId, string userName)
        {
            GenericPrincipal ret = null;
            GenericPrincipal oldPrincipal = Authenticate(Request);
            if (oldPrincipal != null)
            {
                ret = Renew(Request, Response, userId, userName);
            }
            return ret;

        }

        public static GenericPrincipal Authenticate(HttpRequest Request)
        {
            GenericPrincipal ret = null;
            try
            {
                FormsAuthenticationTicket authTicket = GetAuthenticationTicket(Request);
                if (authTicket != null)
                {
                    string[] roles = GetAuthenticationRoles(authTicket);
                    FormsIdentity id = new FormsIdentity(authTicket);
                    ret = new GenericPrincipal(id, roles);
                }
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex, MethodBase.GetCurrentMethod().GetType().Name + " - " + MethodBase.GetCurrentMethod().Name + ": " + ex.Message);
                FormsAuthentication.SignOut();
            }

            return ret;
        }

        public static void SetAuthenticated(HttpRequest Request, HttpResponse Response, int userId, string userName, string roles)
        {
            SetAuthenticated(Request, Response, userId, userName, null, roles);
        }

        public static void SetAuthenticated(HttpRequest Request, HttpResponse Response, int userId, string userName, string userGuid, string roles)
        {
            try
            {

                FormsAuthenticationTicket authTicket = new
                                   FormsAuthenticationTicket(
                                                1,
                                                userName,
                                                DateTime.Now,
                                                DateTime.Now.AddMinutes(120),
                                                true,
                                                roles);

                string encryptedTicket = FormsAuthentication.Encrypt(authTicket);

                CookieUtils.SetCookie(Request, Response, FormsAuthentication.FormsCookieName, encryptedTicket);
                CookieUtils.SetCookie(Request, Response, "UserId", Convert.ToString(userId));
                CookieUtils.SetCookie(Request, Response, "HasRegistered", Convert.ToString(true), 525600);

                if (!String.IsNullOrEmpty(userGuid))
                {
                    CookieUtils.SetCookie(Request, Response, "UserGuid", Convert.ToString(userGuid));
                }
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex, MethodBase.GetCurrentMethod().GetType().Name + " - " + MethodBase.GetCurrentMethod().Name + ": " + ex.Message);
                FormsAuthentication.SignOut();
            }
        }

        public static void SetAuthenticated(HttpRequest Request, HttpResponse Response, string userGuid, string userName, string roles)
        {
            try
            {

                FormsAuthenticationTicket authTicket = new
                                   FormsAuthenticationTicket(
                                                1,
                                                userName,
                                                DateTime.Now,
                                                DateTime.Now.AddMinutes(120),
                                                true,
                                                roles);

                string encryptedTicket = FormsAuthentication.Encrypt(authTicket);

                CookieUtils.SetCookie(Request, Response, FormsAuthentication.FormsCookieName, encryptedTicket);
                CookieUtils.SetCookie(Request, Response, "UserGuid", userGuid);
                CookieUtils.SetCookie(Request, Response, "HasRegistered", Convert.ToString(true), 525600);
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex, MethodBase.GetCurrentMethod().GetType().Name + " - " + MethodBase.GetCurrentMethod().Name + ": " + ex.Message);
                FormsAuthentication.SignOut();
            }
        }

        public static GenericPrincipal Renew(HttpRequest Request, HttpResponse Response, int userId, string userName)
        {
            GenericPrincipal ret = null;
            try
            {
                FormsAuthenticationTicket authTicket = GetAuthenticationTicket(Request);
                if (authTicket != null)
                {
                    if (String.Compare(authTicket.Name, userName, true) == 0)
                    {
                        string[] roles = GetAuthenticationRoles(authTicket);
                        FormsAuthenticationTicket newAuthTicket = new
                                           FormsAuthenticationTicket(
                                                        1,
                                                        authTicket.Name,
                                                        DateTime.Now,
                                                        DateTime.Now.AddMinutes(120),
                                                        true,
                                                        authTicket.UserData);

                        FormsIdentity id = new FormsIdentity(newAuthTicket);

                        ret = new GenericPrincipal(id, roles);

                        string encryptedTicket = FormsAuthentication.Encrypt(newAuthTicket);

                        CookieUtils.SetCookie(Request, Response, FormsAuthentication.FormsCookieName, encryptedTicket);
                        CookieUtils.SetCookie(Request, Response, "UserId", Convert.ToString(userId));
                    }
                }
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex, MethodBase.GetCurrentMethod().GetType().Name + " - " + MethodBase.GetCurrentMethod().Name + ": " + ex.Message);
                FormsAuthentication.SignOut();
            }

            return ret;
        }

        public static GenericPrincipal AuthenticateAndRenewGuid(HttpRequest Request, HttpResponse Response, string userGuid, string userName)
        {
            GenericPrincipal ret = null;
            GenericPrincipal oldPrincipal = Authenticate(Request);
            if (oldPrincipal != null)
            {
                ret = RenewGuid(Request, Response, userGuid, userName);
            }
            return ret;

        }

        public static GenericPrincipal RenewGuid(HttpRequest Request, HttpResponse Response, string userGuid, string userName)
        {
            GenericPrincipal ret = null;
            try
            {
                FormsAuthenticationTicket authTicket = GetAuthenticationTicket(Request);
                if (authTicket != null)
                {
                    if (String.Compare(authTicket.Name, userName, true) == 0)
                    {
                        string[] roles = GetAuthenticationRoles(authTicket);
                        FormsAuthenticationTicket newAuthTicket = new
                                           FormsAuthenticationTicket(
                                                        1,
                                                        authTicket.Name,
                                                        DateTime.Now,
                                                        DateTime.Now.AddMinutes(120),
                                                        true,
                                                        authTicket.UserData);

                        FormsIdentity id = new FormsIdentity(newAuthTicket);

                        ret = new GenericPrincipal(id, roles);

                        string encryptedTicket = FormsAuthentication.Encrypt(newAuthTicket);

                        CookieUtils.SetCookie(Request, Response, FormsAuthentication.FormsCookieName, encryptedTicket);
                        CookieUtils.SetCookie(Request, Response, "UserGuid", userGuid);
                    }
                }
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex, MethodBase.GetCurrentMethod().GetType().Name + " - " + MethodBase.GetCurrentMethod().Name + ": " + ex.Message);
                FormsAuthentication.SignOut();
            }

            return ret;
        }

        public static void SetAuthenticatedGuid(HttpRequest Request, HttpResponse Response, string userGuid, string userName, string roles)
        {
            try
            {

                FormsAuthenticationTicket authTicket = new
                                   FormsAuthenticationTicket(
                                                1,
                                                userName,
                                                DateTime.Now,
                                                DateTime.Now.AddMinutes(120),
                                                true,
                                                roles);

                string encryptedTicket = FormsAuthentication.Encrypt(authTicket);

                CookieUtils.SetCookie(Request, Response, FormsAuthentication.FormsCookieName, encryptedTicket);
                CookieUtils.SetCookie(Request, Response, "UserGuid", userGuid);
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex, MethodBase.GetCurrentMethod().GetType().Name + " - " + MethodBase.GetCurrentMethod().Name + ": " + ex.Message);
                FormsAuthentication.SignOut();
            }
        }

        public static GenericPrincipal RenewAuthenticatedGuid(HttpRequest Request, HttpResponse Response, string userGuid, string userName)
        {
            GenericPrincipal ret = null;
            try
            {
                FormsAuthenticationTicket authTicket = GetAuthenticationTicket(Request);
                if (authTicket != null)
                {
                    if (String.Compare(authTicket.Name, userName, true) == 0)
                    {
                        string[] roles = GetAuthenticationRoles(authTicket);
                        FormsAuthenticationTicket newAuthTicket = new
                                           FormsAuthenticationTicket(
                                                        1,
                                                        authTicket.Name,
                                                        DateTime.Now,
                                                        DateTime.Now.AddMinutes(120),
                                                        true,
                                                        authTicket.UserData);

                        FormsIdentity id = new FormsIdentity(newAuthTicket);

                        ret = new GenericPrincipal(id, roles);

                        string encryptedTicket = FormsAuthentication.Encrypt(newAuthTicket);

                        CookieUtils.SetCookie(Request, Response, FormsAuthentication.FormsCookieName, encryptedTicket);
                        CookieUtils.SetCookie(Request, Response, "UserGuid", userGuid);
                    }
                }
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex, MethodBase.GetCurrentMethod().GetType().Name + " - " + MethodBase.GetCurrentMethod().Name + ": " + ex.Message);
                FormsAuthentication.SignOut();
            }

            return ret;
        }

        public static FormsAuthenticationTicket GetAuthenticationTicket(HttpRequest request)
        {
            FormsAuthenticationTicket ret = null;
            try
            {
                string cookieName = FormsAuthentication.FormsCookieName;
                HttpCookie authCookie = request.Cookies[cookieName];
                if (authCookie != null)
                {
                    ret = FormsAuthentication.Decrypt(authCookie.Value);
                }
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex, MethodBase.GetCurrentMethod().GetType().Name + " - " + MethodBase.GetCurrentMethod().Name + ": " + ex.Message);
                FormsAuthentication.SignOut();
            }

            return ret;
        }

        public static string[] GetAuthenticationRoles(FormsAuthenticationTicket authTicket)
        {
            string[] ret = null;
            try
            {
                if (authTicket != null)
                {
                    // When the ticket was created, the UserData property was assigned a pipe delimited string of role names.
                    ret = authTicket.UserData.Split(new char[] { '|' });
                    if (ret != null)
                    {
                        if (ret.Length == 1)
                        {
                            if (ret[0] == "")
                            {
                                ret[0] = "guest";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex, MethodBase.GetCurrentMethod().GetType().Name + " - " + MethodBase.GetCurrentMethod().Name + ": " + ex.Message);
                FormsAuthentication.SignOut();
            }

            return ret;
        }

    }
}
