using System;
using System.Web.UI;

namespace USC.GISResearchLab.Common.Utils.Web.ScriptRegistrations
{
    public class ScriptRegistration
    {

        public static void RegisterScripts(ClientScriptManager cs, Type type, string name, string url)
        {
            if (!cs.IsClientScriptIncludeRegistered(type, name))
            {
                cs.RegisterClientScriptInclude(type, name, url);
            }
        }

        public static void RegisterStartupScripts(ClientScriptManager cs, Type type, string name, string scriptValue)
        {
            if (!cs.IsStartupScriptRegistered(type, name))
            {
                cs.RegisterStartupScript(type, name, scriptValue);
            }
        }
    }
}
