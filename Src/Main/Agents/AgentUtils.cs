using System;
using System.Net;
using System.Xml;
using System.Xml.XPath;
using USC.GISResearchLab.Common.Exceptions.Geocoding.Agents;
using USC.GISResearchLab.Common.Utils.Files;
using USC.GISResearchLab.Common.Utils.Strings;

namespace USC.GISResearchLab.Common.Utils.Agents
{
	/// <summary>
	/// Summary description for AgentUtils.
	/// </summary>
	public class AgentUtils
	{
        public static string AGENT_URL_FILE_PATH = "C:\\Inetpub\\wwwroot\\Geocoder\\AGENT_URL.txt";

		public AgentUtils()
		{
		}

		public static string buildAgentQueryString(string planPath, string parameters){
			return buildAgentQueryString(null, planPath, parameters);
		}

		public static string buildAgentQueryString(string agentServerUrl, string planPath, string parameters)
		{
			string ret = "";

			if (StringUtils.IsEmpty(agentServerUrl))
			{
				agentServerUrl = getAgentServerUrl();
			}

			ret += agentServerUrl;
			ret += planPath;
			ret+= parameters;

			return ret;
		}

		public static XPathDocument query(string planPath, string parameters)
		{
			string url = getAgentServerUrl() + planPath + parameters;
			return query(url);
		}

		public static XPathDocument query(string url)
		{
			XPathDocument xpathDocument = null;

            try
            {

                HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(url);
                objRequest.Credentials = CredentialCache.DefaultCredentials;
                objRequest.Method = "GET";
                objRequest.Timeout = 1000;


                HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();

                XmlTextReader reader = new XmlTextReader(objResponse.GetResponseStream());
                reader.Read();
                xpathDocument = new XPathDocument(reader, XmlSpace.Default); // Default is important to ignore space

            }
            catch (Exception e)
            {
                throw new AssessorException("An error occured querying LA Assessor Site - Check that the agent is running: " + e.Message + " : - URL:" + url);
            }

			return xpathDocument;
		}

		public static string getAgentServerUrl()
		{
			string ret = "";
			ret = FileUtils.AsString(AGENT_URL_FILE_PATH);
			return ret;
		}

	}
}
