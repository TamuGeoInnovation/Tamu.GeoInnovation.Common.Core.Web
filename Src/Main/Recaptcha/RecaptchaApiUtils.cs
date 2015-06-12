using System;
using System.Web;

namespace USC.GISResearchLab.Common.Utils.Web.Recaptcha
{
    public class RecaptchaApiUtils
    {
        public static string publicKey_webgis = "http://maps.google.com/maps?file=api&v=2&key=ABQIAAAA4Hc23EM61zkL2JsvYYf2VRQHwI74f6zqf1I2q3FUzVQ2yUdhKxRaOah-7W2INIoAR_CLO7wsRsF8gA";
        public static string privateKey_webgis = "http://maps.google.com/maps?file=api&v=2&key=ABQIAAAA4Hc23EM61zkL2JsvYYf2VRQHwI74f6zqf1I2q3FUzVQ2yUdhKxRaOah-7W2INIoAR_CLO7wsRsF8gA";

        public static string publicKey_billboards = "6LfFi7wSAAAAAA3i12LtZDebsAfseIStO9ohy8iJ ";
        public static string privateKey_billboards = "6LfFi7wSAAAAAAxU7mWsCIbNXKVrIlz5HPLrqN1Y ";

        public static string GetPublicKey(HttpRequest Request)
        {
            string ret = "";

            if (Request.Url.Host.ToLower().Equals("webgis.usc.edu"))
            {
                ret = publicKey_webgis;
            }
            else if (Request.Url.Host.ToLower().Equals("billboards.usc.edu"))
            {
                ret = publicKey_billboards;
            }
            else
            {
                throw new Exception("Error getting recaptcha key: unexpected hostname" + Request.Url.Host);
            }
            return ret;
        }

        public static string GetPrivateKey(HttpRequest Request)
        {
            string ret = "";

            if (Request.Url.Host.ToLower().Equals("webgis.usc.edu"))
            {
                ret = privateKey_webgis;
            }
            else if (Request.Url.Host.ToLower().Equals("billboards.usc.edu"))
            {
                ret = privateKey_billboards;
            }
            else
            {
                throw new Exception("Error getting recaptcha key: unexpected hostname" + Request.Url.Host);
            }
            return ret;
        }
    }
}