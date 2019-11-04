using System.Xml.XPath;

namespace USC.GISResearchLab.Common.Utils.Agents.Stores
{
    /// <summary>
    /// Summary description for LAAssessorUtils.
    /// </summary>
    public class StoreUtils
    {

        public static string AGENT_URL_FILE_PATH = "C:\\Inetpub\\wwwroot\\Geocoder\\conf\\AGENT_URL.txt";
        public const string LAYERS = "0,1,0,1,1,1,1,0,1,0,0,0,0,0,0,0";

        public StoreUtils()
        {
        }

        public static XPathDocument queryBordersAgent(string zip, string agentServerUrl)
        {

            string planPath = "/agent/runner?plan=ted%2Fborders%2Fplans%2Fproduction";
            string parameters = "";
            parameters += "&zip=" + zip;
            string url = agentServerUrl + planPath + parameters;
            return AgentUtils.query(url);
        }
    }


}
