using USC.GISResearchLab.Common.Utils.Files;

namespace USC.GISResearchLab.Common.Utils.Web.ContentTypes
{
    public class ContentTypeUtils
    {

        public static string GetContentType(string url)
        {
            string ret = "";

            string extension = FileUtils.GetExtension(url.ToUpper(), false);

            switch (extension)
            {
                //Common documents		
                case "TXT":
                case "TEXT":
                case "VBS":
                case "ASP":
                case "CGI":
                case "PL":
                case "NFO":
                case "ME":
                case "DTD":
                    ret = "text/plain";
                    break;
                case "HTM":
                case "HTML":
                case "HTA":
                case "HTX":
                case "MHT":
                    ret = "text/html";
                    break;
                case "CSV":
                    ret = "text/comma-separated-values";
                    break;
                case "JS":
                    ret = "text/javascript";
                    break;
                case "CSS":
                    ret = "text/css";
                    break;
                case "PDF":
                    ret = "application/pdf";
                    break;
                case "RTF":
                    ret = "application/rtf";
                    break;
                case "XML":
                case "XSL":
                case "XSLT":
                    ret = "text/xml";
                    break;
                case "KML":
                    ret = "application/vnd.google-earth.kml+xml";
                    break;
                case "WPD":
                    ret = "application/wordperfect";
                    break;
                case "WRI":
                    ret = "application/mswrite";
                    break;
                case "XLS":
                case "XLS3":
                case "XLS4":
                case "XLS5":
                case "XLW":
                    ret = "application/msexcel";
                    break;
                case "DOC":
                    ret = "application/msword";
                    break;
                case "PPT":
                case "PPS":
                    ret = "application/mspowerpoint";
                    break;

                //'WAP/WML files			
                case "WML":
                    ret = "text/vnd.wap.wml";
                    break;
                case "WMLS":
                    ret = "text/vnd.wap.wmlscript";
                    break;
                case "WBMP":
                    ret = "image/vnd.wap.wbmp";
                    break;
                case "WMLC":
                    ret = "application/vnd.wap.wmlc";
                    break;
                case "WMLSC":
                    ret = "application/vnd.wap.wmlscriptc";
                    break;

                // Images
                case "JPG":
                case "JPEG":
                case "JPE":
                    ret = "image/jpg";
                    break;
                case "PNG":
                    ret = "image/png";
                    break;
                case "GIF":
                    ret = "image/gif";
                    break;
                case "BMP":
                    ret = "image/bmp";
                    break;
                case "TIF":
                case "TIFF":
                    ret = "image/tiff";
                    break;
                case "AI":
                case "EPS":
                case "PS":
                    ret = "application/postscript";
                    break;

                //Sound files		
                case "AU":
                case "SND":
                    ret = "audio/basic";
                    break;
                case "WAV":
                    ret = "audio/wav";
                    break;
                case "RA":
                case "RM":
                case "RAM":
                    ret = "audio/x-pn-realaudio";
                    break;
                case "MID":
                case "MIDI":
                    ret = "audio/x-midi";
                    break;
                case "MP3":
                    ret = "audio/mp3";
                    break;
                case "M3U":
                    ret = "audio/m3u";
                    break;

                //Video/Multimedia files		
                case "ASF":
                    ret = "video/x-ms-asf";
                    break;
                case "AVI":
                    ret = "video/avi";
                    break;
                case "MPG":
                case "MPEG":
                    ret = "video/mpeg";
                    break;
                case "QT":
                case "MOV":
                case "QTVR":
                    ret = "video/quicktime";
                    break;
                case "SWA":
                    ret = "application/x-director";
                    break;
                case "SWF":
                    ret = "application/x-shockwave-flash";
                    break;

                //Compressed/archives		
                case "ZIP":
                    ret = "application/x-zip-compressed";
                    break;
                case "GZ":
                    ret = "application/x-gzip";
                    break;
                case "RAR":
                    ret = "application/x-rar-compressed";
                    break;

                //Database files
                case "MDB":
                    ret = "application/vnd.ms-access";
                    break;

                //Miscellaneous		
                case "COM":
                case "EXE":
                case "DLL":
                case "OCX":
                    ret = "application/octet-stream";
                    break;
                default:
                    ret = "";
                    break;
            }
            return ret;
        }
    }
}
