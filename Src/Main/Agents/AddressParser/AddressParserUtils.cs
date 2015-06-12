using System.Web;
using System.Xml.XPath;

namespace USC.GISResearchLab.Common.Utils.Agents.AddressParser
{
	/// <summary>
	/// Summary description for AddressParserUtils.
	/// </summary>
	public class AddressParserUtils
	{

		public static string AGENT_URL_FILE_PATH = "C:\\Inetpub\\wwwroot\\Geocoder\\conf\\AGENT_URL.txt";
		public const string LAYERS = "0,1,0,1,1,1,1,0,1,0,0,0,0,0,0,0";

		public AddressParserUtils()
		{
		}

		public static XPathDocument queryAddressParserAgent(string streetAddress, string agentServerUrl)
		{

			string planPath = "/agent/runner?plan=tokenbasedaddressparser%2Fplans%2Fproduction";
			string parameters = "&StreetAddress=" + HttpUtility.UrlEncode(streetAddress);
			string url = agentServerUrl + planPath + parameters;
			return AgentUtils.query(url);
		}
	}
}
