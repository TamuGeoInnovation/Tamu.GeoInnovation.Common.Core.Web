using System;
using System.Diagnostics;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace USC.GISResearchLab.Common.Utils.Web.ExceptionHandlers
{
    public class ExceptionHandlerUtils
    {
        public static void HandleUserInputError(MasterPage master, string statusMessage)
        {
            HandleUserInputError(master, statusMessage, null);
        }

        public static void HandleUserInputError(MasterPage master, string statusMessage, TraceSource traceSource)
        {
            HandleError(master, null, null, null, statusMessage, false, true, traceSource, null);
        }

        public static void HandleError(MasterPage master, Exception e, bool displayErrorMessage)
        {
            HandleError(master, e, displayErrorMessage, null);
        }

        public static void HandleError(MasterPage master, Exception e, bool displayErrorMessage, TraceSource traceSource)
        {
            HandleError(master, e.GetType().ToString(), e.Message, e.StackTrace, null, displayErrorMessage, false, traceSource, null);
        }

        public static void HandleError(MasterPage master, Exception e, bool displayErrorMessage, TraceSource traceSource, HttpRequest request)
        {
            HandleError(master, e.GetType().ToString(), e.Message, e.StackTrace, null, displayErrorMessage, false, traceSource, request);
        }

        public static void HandleError(MasterPage master, string errorType, string errorMessage, string stackTrace, string statusMessage, bool displayErrorMessage, bool displayStatusMessage)
        {
            HandleError(master, errorType, errorMessage, stackTrace, statusMessage, displayErrorMessage, displayStatusMessage, null, null);
        }

        public static void HandleError(MasterPage master, string errorType, string errorMessage, string stackTrace, string statusMessage, bool displayErrorMessage, bool displayStatusMessage, TraceSource traceSource, HttpRequest request)
        {
            string message = "<br>=======================================<br>";

            string requestParameters = "";
            string requestCookies = "";

            if (request != null)
            {
                for (int i = 0; i < request.Params.Count; i++)
                {   
                    requestParameters += "<br>     " + request.Params.Keys[i] + ": " + request[request.Params.Keys[i]];
                }

                for (int i = 0; i < request.Cookies.Count; i++)
                {
                    requestCookies += "<br>     " + request.Cookies.Keys[i] + ": " + request[request.Cookies.Keys[i]];
                }
            }

            if (displayStatusMessage)
            {
                if (statusMessage != null && statusMessage != "")
                {
                    message += statusMessage;
                }
            }

            if (errorMessage != null && errorMessage != "")
            {

                message += "An exception occurred:";

                if (displayErrorMessage)
                {
                    message += "<br>Error Type:" + errorType;
                    message += "<br>Error Message:" + errorMessage;
                    message += "<br>Request Page: " + request.Url.ToString();
                    message += "<br>Request Query String: " + request.QueryString;
                    message += "<br>Request Parameters: " + requestParameters;
                    message += "<br>Request Cookies: " + requestCookies;
                    message += "<br>Stack Trace:" + stackTrace;
                }
            }

            if (master != null)

            {
                Label label = (Label)master.FindControl("LabelError");
                if (label != null)
                {
                    label.Text = message;
                }
            }

            message = message.Replace("<br>", Environment.NewLine);

            if (traceSource != null)
            {
                
                traceSource.TraceEvent(TraceEventType.Error, 0, DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss") + " - " + message);
            }

            // EventLog.WriteEntry("Web Error Handler Utils", message, EventLogEntryType.Error);
        }
    }
}
