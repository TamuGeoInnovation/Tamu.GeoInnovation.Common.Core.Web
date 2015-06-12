using System;
using System.IO;
using System.Web;
using USC.GISResearchLab.Common.Utils.Files;

namespace USC.GISResearchLab.Common.Utils.Web.Streams
{
    public class StreamUtils
    {
        public static void SendFileAsStreamToBrowser(HttpResponse response, string filePath, string fileName, string contentType, bool isInline)
        {
            try
            {
                long fileSize = new FileInfo(filePath).Length;

                response.Clear();
                response.Buffer = false;
                response.BufferOutput = false;

                response.AddHeader("Connection", "keep-alive");
                response.AddHeader("Content-Length", fileSize.ToString());
                response.ContentType = contentType;


                //'Add filename to header if not empty
                if (fileName != null && fileName != "")
                {
                    //'Check if data should be delivered inline or not	
                    if (isInline)
                    {
                        response.AddHeader("Content-Disposition", "inline; filename=" + fileName);
                    }
                    else
                    {
                        //'Force browser to save file		
                        response.AddHeader("Content-Disposition", "attachment; filename=\"" + fileName + "\"");
                    }
                }

                response.ContentType = contentType;

                int bufferSize = 65000;
                int bytesRead = 0;
                int pos = 0;
                byte[] buffer = null;
                do
                {
                    if (response.IsClientConnected)
                    {
                        buffer = new byte[bufferSize];
                        bytesRead = FileUtils.GetBytesAtOffset(ref buffer, filePath, pos, bufferSize);
                        response.BinaryWrite(buffer);
                        pos += bytesRead;
                    }
                    else
                    {
                        return;
                    }

                } while (bytesRead > 0);


                response.Flush();
            }
            catch (Exception e)
            {
                throw new Exception("An error occurred SendFileAsStreamToBrowser: " + e.Message, e);
            }

        }

        public static void SendStreamToBrowser(HttpResponse response, byte[] bytes, string fileName, string contentType, bool isInline)
        {
            try
            {
                int fileSize = bytes.Length;

                response.Clear();


                response.AddHeader("Connection", "keep-alive");
                response.AddHeader("Content-Length", fileSize.ToString());


                //'Add filename to header if not empty
                if (fileName != null && fileName != "")
                {
                    //'Check if data should be delivered inline or not	
                    if (isInline)
                    {
                        response.AddHeader("Content-Disposition", "inline; filename=" + fileName);
                    }
                    else
                    {
                        //'Force browser to save file		
                        response.AddHeader("Content-Disposition", "attachment; filename=\"" + fileName + "\"");
                    }
                }

                response.ContentType = contentType;
                response.BinaryWrite(bytes);
                response.Flush();
            }
            catch (Exception e)
            {
                throw new Exception("An error occurred SendStreamToBrowser: " + e.Message, e);
            }
        }
    }
}
