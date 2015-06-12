using System;
using System.Web.Services.Protocols;

// from http://msdn2.microsoft.com/en-us/library/7w06t139(VS.80).aspx

namespace USC.GISResearchLab.Common.Core.WebServices.SoapExtensions
{
    // Create a SoapExtensionAttribute for the SOAP Extension that can be
    // applied to a Web service method.
    [AttributeUsage(AttributeTargets.Method)]
    public class TraceExtensionAttribute : SoapExtensionAttribute
    {

        private string filename = @"E:\Research2\DotNetDevelopment\USC\GISResearchLab\Websites\GeocodingCorrection\TraceLogs\WebserviceLog.txt";
        private int priority;

        public override Type ExtensionType
        {
            get { return typeof(TraceExtension); }
        }

        public override int Priority
        {
            get { return priority; }
            set { priority = value; }
        }

        public string Filename
        {
            get
            {
                return filename;
            }
            set
            {
                filename = value;
            }
        }
    }
}