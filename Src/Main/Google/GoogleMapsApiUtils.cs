using System;
using System.Web;

namespace USC.GISResearchLab.Common.Utils.Web.Google
{
    public class GoogleMapsApiUtils
    {
        public static string googleAPIKey_410 = "http://maps.google.com/maps?file=api&v=2&key=ABQIAAAA4Hc23EM61zkL2JsvYYf2VRTgiFCKMqCewFy9ArW9O8o30z3SeBQTy6QRGLJ2cuczrWhf2Jqoi4D4tw";
        //public static string googleAPIKey_Localhost = "http://maps.google.com/maps?file=api&v=2&key=ABQIAAAA4Hc23EM61zkL2JsvYYf2VRT2yXp_ZAY8_ufC3CFXhHIE1NvwkxTZwgo6x7e9uzA6-zgG6n8g8rDetA";
        public static string googleAPIKey_Localhost = "http://maps.google.com/maps?file=api&v=2&key=ABQIAAAA4Hc23EM61zkL2JsvYYf2VRT2yXp_ZAY8_ufC3CFXhHIE1NvwkxTZwgo6x7e9uzA6-zgG6n8g8rDetA";
        public static string googleAPIKey_Dwgold = "http://maps.google.com/maps?file=api&v=2&key=ABQIAAAA4Hc23EM61zkL2JsvYYf2VRSADmZaDvmwC3wzjkYPl-LswBEUdRTb1zqQsqBWS7f6UHcLZKdHSSqv-w";
        public static string googleAPIKey_192_168_2_116 = "http://maps.google.com/maps?file=api&v=2&key=ABQIAAAA4Hc23EM61zkL2JsvYYf2VRRkpwsKhofKB_3wYV4iUXYMHZ97uRT_M_eZXxOQKzdby_pqWZnWNrAFsw";
        public static string googleAPIKey_webgisdev = "http://maps.google.com/maps?file=api&v=2&key=ABQIAAAA4Hc23EM61zkL2JsvYYf2VRSvBTMUTzYPSnzVioxejkVtwxAPNRQpbIWBuj46kZExAMyYImCBpbE1mw";
        public static string googleAPIKey_webgis = "http://maps.google.com/maps?file=api&v=2&key=ABQIAAAA4Hc23EM61zkL2JsvYYf2VRQHwI74f6zqf1I2q3FUzVQ2yUdhKxRaOah-7W2INIoAR_CLO7wsRsF8gA";
        public static string googleAPIKey_billboards = "http://maps.google.com/maps?file=api&v=2&key=ABQIAAAA4Hc23EM61zkL2JsvYYf2VRRnpvkmwec4y3q_Vg2FYEW4yCRzAxTnSI15BkYFtUfL46hi_3KCRo-QXQ";
        public static string googleAPIKey_billboardMaps = "http://maps.google.com/maps?file=api&v=2&key=ABQIAAAA4Hc23EM61zkL2JsvYYf2VRTtuce0XZyJ6baG-6o7G52ByGm1AxQs_3G8111RL5M1f9m3sLNq5CgoKw";

        public static string GetApiKey(HttpRequest Request)
        {
            string ret = "";

            if (Request.Url.Host.ToLower().Equals("localhost"))
            {
                ret = googleAPIKey_Localhost;
            }
            else if (Request.Url.Host.ToLower().Equals("ahf410-pc4.usc.edu"))
            {
                ret = googleAPIKey_410;
            }
            else if (Request.Url.Host.ToLower().Equals("dwgold.com"))
            {
                ret = googleAPIKey_Dwgold;
            }
            else if (Request.Url.Host.ToLower().Equals("192.168.2.116"))
            {
                ret = googleAPIKey_192_168_2_116;
            }
            else if (Request.Url.Host.ToLower().Equals("webgisdev.usc.edu"))
            {
                ret = googleAPIKey_webgisdev;
            }
            else if (Request.Url.Host.ToLower().Equals("webgis.usc.edu"))
            {
                ret = googleAPIKey_webgis;
            }
            else if (Request.Url.Host.ToLower().Equals("billboards.usc.edu"))
            {
                ret = googleAPIKey_billboards;
            }
            else if (Request.Url.Host.ToLower().Equals("billboardmap.usc.edu"))
            {
                ret = googleAPIKey_billboardMaps;
            }
            else if (Request.Url.Host.ToLower().Equals("geoservices.tamu.edu"))
            {
                ret = googleAPIKey_billboardMaps;
            }
            else
            {
                throw new Exception("Error getting google maps key: unexpected hostname" + Request.Url.Host);
            }
            return ret;
        }
    }
}