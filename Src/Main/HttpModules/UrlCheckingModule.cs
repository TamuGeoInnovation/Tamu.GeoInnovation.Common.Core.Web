﻿// this code is from http://www.codeproject.com/KB/aspnet/handledirectory.aspx


using System;
using System.IO;
using System.Web;
using USC.GISResearchLab.Common.Core.IOs.Paths;

namespace USC.GISResearchLab.Common.Core.Web.HttpModules
{
    public class UrlCheckingModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.BeginRequest += new EventHandler(Context_OnBeginRequest);
        }

        private void Context_OnBeginRequest(object sender, EventArgs e)
        {
            // check Request 

            HttpContext context = HttpContext.Current;
            HttpRequest request = context.Request;
            string file = request.FilePath;

            if (!PathUtils.ContainsInvalidFileNameChars(file))
            {

                string ext = Path.GetExtension(file);
                if (string.IsNullOrEmpty(ext) && !file.EndsWith("/"))
                {
                    string q = request.QueryString.ToString();
                    string path = request.FilePath + "/" + (string.IsNullOrEmpty(q) ? "" : q);

                    if (path.EndsWith("/"))
                    {
                        path += "Default.aspx";
                    }

                    context.Response.Redirect(path);
                }
                else
                {
                    if (file.EndsWith("/"))
                    {
                        string path = request.FilePath + "Default.aspx";
                        context.Response.Redirect(path);
                    }
                }
            }

        }

        public void Dispose()
        {

        }
    }
}
