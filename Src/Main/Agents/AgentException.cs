using System;

namespace USC.GISResearchLab.Common.Exceptions.Geocoding.Agents
{
    /// <summary>
    /// Summary description for AgentException.
    /// </summary>
    public class AgentException : Exception
    {
        public AgentException(string message) :
            base(message)
        {
        }
    }
}
