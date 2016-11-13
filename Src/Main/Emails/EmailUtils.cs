using System;
using System.Net;
using System.Net.Mail;
using System.IO;
using System.Net.Mime;

namespace USC.GISResearchLab.Common.Utils.Web.Emails
{
    public class EmailUtils
    {

        public static bool SendMail(string mailServer, string from, string to, string subject, string body, int port)
        {
            return SendMail(mailServer, from, null, null, to, null, null, subject, body, false, port, true);
        }

        public static bool SendMail(string mailServer, string from, string to, string subject, string body)
        {
            return SendMail(mailServer, from, null, null, to, null, null, subject, body, false, 25, true);
        }

        public static bool SendMail(string mailServer, string from, string username, string password, string to, string subject, string body, int port)
        {
            return SendMail(mailServer, from, username, password, to, null, null, subject, body, false, port, true);
        }

        public static bool SendMail(string mailServer, string from, string username, string password, string to, string subject, string body)
        {
            return SendMail(mailServer, from, username, password, to, null, null, subject, body, false, 25, true);
        }

        public static bool SendMail(string mailServer, string from, string username, string password, string to, string[] cc, string subject, string body, int port)
        {
            return SendMail(mailServer, from, username, password, to, cc, null, subject, body, false, port, true);
        }

        public static bool SendMail(string mailServer, string from, string username, string password, string to, string[] cc, string subject, string body)
        {
            return SendMail(mailServer, from, username, password, to, cc, null, subject, body, false, 25, true);
        }

        public static bool SendMail(string mailServer, string from, string username, string password, string to, string[] cc, string[] bcc, string subject, string body, int port)
        {
            return SendMail(mailServer, from, username, password, to, cc, bcc, subject, body, false, port, true);
        }

        public static bool SendMail(string mailServer, string from, string username, string password, string to, string[] cc, string[] bcc, string subject, string body)
        {
          return SendMail(mailServer, from, username, password, to, cc, bcc, subject, body, false, 25, true);
        }

        public static bool SendMail(string mailServer, string from, string username, string password, string to, string[] cc, string[] bcc, string replyTo, string subject, string body)
        {
            return SendMail(mailServer, from, username, password, to, cc, bcc, replyTo, subject, body, false, 25, true);
        }


        public static bool SendMailSSL(string mailServer, string from, string to, string subject, string body, int port)
        {
            return SendMail(mailServer, from, null, null, to, null, null, subject, body, true, port, true);
        }

        public static bool SendMailSSL(string mailServer, string from, string to, string subject, string body)
        {
            return SendMail(mailServer, from, null, null, to, null, null, subject, body, true, 465, true);
        }

        public static bool SendMailSSL(string mailServer, string from, string username, string password, string to, string subject, string body, int port)
        {
            return SendMail(mailServer, from, username, password, to, null, null, subject, body, true, port, true);
        }

        public static bool SendMailSSL(string mailServer, string from, string username, string password, string to, string subject, string body)
        {
            return SendMail(mailServer, from, username, password, to, null, null, subject, body, true, 465, true);
        }

        public static bool SendMailSSL(string mailServer, string from, string username, string password, string to, string[] cc, string subject, string body, int port)
        {
            return SendMail(mailServer, from, username, password, to, cc, null, subject, body, true, port, true);
        }

        public static bool SendMailSSL(string mailServer, string from, string username, string password, string to, string[] cc, string subject, string body)
        {
            return SendMail(mailServer, from, username, password, to, cc, null, subject, body, true, 465, true);
        }

        public static bool SendMailSSL(string mailServer, string from, string username, string password, string to, string[] cc, string[] bcc, string subject, string body, int port)
        {
            return SendMail(mailServer, from, username, password, to, cc, bcc, subject, body, true, port, true);
        }

        public static bool SendMailSSL(string mailServer, string from, string username, string password, string to, string[] cc, string[] bcc, string subject, string body)
        {
            return SendMail(mailServer, from, username, password, to, cc, bcc, subject, body, true, 465, true);
        }

        public static bool SendMail(string mailServer, string from, string username, string password, string to, string[] cc, string[] bcc, string subject, string body, bool useSSL, int port)
        {
            return SendMail(mailServer, from, username, password, to, cc, bcc, null, subject, body, useSSL, port, true);
        }



        /// <summary>
        /// Sends emails
        /// </summary>
        /// <param name="mailServer"></param>
        /// <param name="from"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="to"></param>
        /// <param name="cc"></param>
        /// <param name="bcc"></param>
        /// <param name="replyTo"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <param name="useSSL"></param>
        /// <param name="port"></param>
        /// <param name="shouldThrowExceptions"></param>
        /// <returns></returns>
        /// 

        public static bool SendMailSSL(string mailServer, string from, string to, string subject, string body, int port, bool shouldThrowException)
        {
            return SendMail(mailServer, from, null, null, to, null, null, subject, body, true, port, null, shouldThrowException);
        }

        public static bool SendMailSSL(string mailServer, string from, string to, string subject, string body, bool shouldThrowException)
        {
            return SendMail(mailServer, from, null, null, to, null, null, subject, body, true, 465, null, shouldThrowException);
        }

        public static bool SendMailSSL(string mailServer, string from, string username, string password, string to, string subject, string body, int port, bool shouldThrowException)
        {
            return SendMail(mailServer, from, username, password, to, null, null, subject, body, true, port, null, shouldThrowException);
        }

        public static bool SendMailSSL(string mailServer, string from, string username, string password, string to, string subject, string body, bool shouldThrowException)
        {
            return SendMail(mailServer, from, username, password, to, null, null, subject, body, true, 465, null, shouldThrowException);
        }

        public static bool SendMailSSL(string mailServer, string from, string username, string password, string to, string[] cc, string subject, string body, int port, bool shouldThrowException)
        {
            return SendMail(mailServer, from, username, password, to, cc, null, subject, body, true, port, null, shouldThrowException);
        }

        public static bool SendMailSSL(string mailServer, string from, string username, string password, string to, string[] cc, string subject, string body, bool shouldThrowException)
        {
            return SendMail(mailServer, from, username, password, to, cc, null, subject, body, true, 465, null, shouldThrowException);
        }

        public static bool SendMailSSL(string mailServer, string from, string username, string password, string to, string[] cc, string[] bcc, string subject, string body, int port, bool shouldThrowException)
        {
            return SendMail(mailServer, from, username, password, to, cc, bcc, subject, body, true, port, null, shouldThrowException);
        }

        public static bool SendMailSSL(string mailServer, string from, string username, string password, string to, string[] cc, string[] bcc, string subject, string body, bool shouldThrowException)
        {
            return SendMail(mailServer, from, username, password, to, cc, bcc, subject, body, true, 465, null, shouldThrowException);
        }

        public static bool SendMail(string mailServer, string from, string username, string password, string to, string[] cc, string[] bcc, string subject, string body, bool useSSL, int port, bool shouldThrowException)
        {
            return SendMail(mailServer, from, username, password, to, cc, bcc, null, subject, body, useSSL, port, null, shouldThrowException);
        }


        public static bool SendMail(string mailServer, string from, string username, string password, string to, string[] cc, string[] bcc, string replyTo, string subject, string body, bool useSSL, int port)
        {
            return SendMail(mailServer, from, username, password, to, cc, bcc, replyTo, subject, body, useSSL, port, null, true);
        }

        public static bool SendMail(string mailServer, string from, string username, string password, string to, string[] cc, string[] bcc, string replyTo, string subject, string body, bool useSSL, int port, bool shouldThrowExceptions)
        {
            return SendMail(mailServer, from, username, password, to, cc, bcc, replyTo, subject, body, useSSL, port, null, shouldThrowExceptions);
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="mailServer"></param>
        /// <param name="from"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="to"></param>
        /// <param name="cc"></param>
        /// <param name="bcc"></param>
        /// <param name="replyTo"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <param name="useSSL"></param>
        /// <param name="port"></param>
        /// <param name="fileAttachments"></param>
        /// <param name="shouldThrowExceptions"></param>
        /// <returns></returns>
        /// 


        public static bool SendMailSSL(string mailServer, string from, string to, string subject, string body, int port, string[] attachmentFiles, bool shouldThrowException)
        {
            return SendMail(mailServer, from, null, null, to, null, null, subject, body, true, port, attachmentFiles, shouldThrowException);
        }

        public static bool SendMailSSL(string mailServer, string from, string to, string subject, string body, string[] attachmentFiles, bool shouldThrowException)
        {
            return SendMail(mailServer, from, null, null, to, null, null, subject, body, true, 465, attachmentFiles, shouldThrowException);
        }

        public static bool SendMailSSL(string mailServer, string from, string username, string password, string to, string subject, string body, int port, string[] attachmentFiles, bool shouldThrowException)
        {
            return SendMail(mailServer, from, username, password, to, null, null, subject, body, true, port, attachmentFiles, shouldThrowException);
        }

        public static bool SendMailSSL(string mailServer, string from, string username, string password, string to, string subject, string body, string[] attachmentFiles, bool shouldThrowException)
        {
            return SendMail(mailServer, from, username, password, to, null, null, subject, body, true, 465, attachmentFiles, shouldThrowException);
        }

        public static bool SendMailSSL(string mailServer, string from, string username, string password, string to, string[] cc, string subject, string body, int port, string[] attachmentFiles, bool shouldThrowException)
        {
            return SendMail(mailServer, from, username, password, to, cc, null, subject, body, true, port, attachmentFiles, shouldThrowException);
        }

        public static bool SendMailSSL(string mailServer, string from, string username, string password, string to, string[] cc, string subject, string body, string[] attachmentFiles, bool shouldThrowException)
        {
            return SendMail(mailServer, from, username, password, to, cc, null, subject, body, true, 465, attachmentFiles, shouldThrowException);
        }

        public static bool SendMailSSL(string mailServer, string from, string username, string password, string to, string[] cc, string[] bcc, string subject, string body, int port, string[] attachmentFiles, bool shouldThrowException)
        {
            return SendMail(mailServer, from, username, password, to, cc, bcc, subject, body, true, port, attachmentFiles, shouldThrowException);
        }

        public static bool SendMailSSL(string mailServer, string from, string username, string password, string to, string[] cc, string[] bcc, string subject, string body, string[] attachmentFiles, bool shouldThrowException)
        {
            return SendMail(mailServer, from, username, password, to, cc, bcc, subject, body, true, 465, attachmentFiles, shouldThrowException);
        }

        public static bool SendMail(string mailServer, string from, string username, string password, string to, string[] cc, string[] bcc, string subject, string body, bool useSSL, int port, string[] attachmentFiles, bool shouldThrowException)
        {
            return SendMail(mailServer, from, username, password, to, cc, bcc, null, subject, body, useSSL, port, attachmentFiles, shouldThrowException);
        }


        public static bool SendMail(string mailServer, string from, string username, string password, string to, string[] cc, string[] bcc, string replyTo, string subject, string body, bool useSSL, string[] attachmentFiles, int port)
        {
            return SendMail(mailServer, from, username, password, to, cc, bcc, replyTo, subject, body, useSSL, port, attachmentFiles, true);
        }

        ///

        public static bool SendMail(string mailServer, string from, string username, string password, string to, string[] cc, string[] bcc, string replyTo, string subject, string body, bool useSSL, int port, string[] fileAttachments, bool shouldThrowExceptions)
        {
            return SendMail( mailServer,  from,  username,  password,  to,  cc,  bcc,  replyTo,  subject,  body,  useSSL,  port,  fileAttachments,  false,  shouldThrowExceptions);
        }

        public static bool SendMail(string mailServer, string from, string username, string password, string to, string[] cc, string[] bcc, string replyTo, string subject, string body, bool useSSL, int port, string[] fileAttachments, bool isHtml, bool shouldThrowExceptions)
        {
            bool ret = true;

            try
            {

                if (!String.IsNullOrEmpty(to))
                {

                    if (to.Contains("@") && to.Contains("."))
                    {

                        MailMessage message = new MailMessage();

                        string[] toParts = null;
                        if (to.Contains(";"))
                        {
                            toParts = to.Split(new string[] { ";", ",", ":", " " }, StringSplitOptions.RemoveEmptyEntries);
                        }

                        if (toParts != null)
                        {
                            message.To.Add(toParts[0]);

                            for (int i = 1; i < toParts.Length; i++)
                            {
                                message.CC.Add(new MailAddress(toParts[i]));
                            }

                        }
                        else
                        {
                            message.To.Add(to);
                        }

                        if (cc != null)
                        {
                            for (int i = 0; i < cc.Length; i++)
                            {
                                if (cc[i] != null && cc[i] != "")
                                {
                                    try
                                    {
                                        message.CC.Add(new MailAddress(cc[i]));
                                    }
                                    catch (Exception)
                                    {

                                    }
                                }
                            }
                        }
                        if (bcc != null)
                        {
                            for (int i = 0; i < bcc.Length; i++)
                            {
                                if (bcc[i] != null && bcc[i] != "")
                                {
                                    try
                                    {
                                        message.Bcc.Add(new MailAddress(bcc[i]));
                                    }
                                    catch (Exception)
                                    {

                                    }
                                }
                            }
                        }

                        message.Subject = subject;
                        message.From = new MailAddress(from);

                        if (!String.IsNullOrEmpty(replyTo))
                        {
                            message.ReplyTo = new MailAddress(replyTo);
                        }


                        if (fileAttachments != null)
                        {
                            if (fileAttachments.Length > 0)
                            {
                                foreach (string fileAttachment in fileAttachments)
                                {
                                    if (!String.IsNullOrEmpty(fileAttachment))
                                    {
                                        if (File.Exists(fileAttachment))
                                        {
                                            // Create  the file attachment for this e-mail message.
                                            Attachment data = new Attachment(fileAttachment, MediaTypeNames.Application.Octet);
                                            // Add time stamp information for the file.
                                            ContentDisposition disposition = data.ContentDisposition;
                                            disposition.CreationDate = System.IO.File.GetCreationTime(fileAttachment);
                                            disposition.ModificationDate = System.IO.File.GetLastWriteTime(fileAttachment);
                                            disposition.ReadDate = System.IO.File.GetLastAccessTime(fileAttachment);
                                            // Add the file attachment to this e-mail message.
                                            message.Attachments.Add(data);

                                        }
                                    }
                                }
                            }
                        }

                        if (isHtml)
                        {
                            message.IsBodyHtml = true;
                        }


                        message.Body = body;
                        SmtpClient smtp = new SmtpClient(mailServer, 25);
                        // smtp.Timeout = 5000;

                        if (username != null && password != null)
                        {
                            smtp.UseDefaultCredentials = false;
                            smtp.Credentials = new NetworkCredential(username, password);
                        }

                        if (useSSL)
                        {
                            smtp.EnableSsl = true;
                            if (port > 0)
                            {
                                smtp.Port = port;
                            }
                            else
                            {
                                //smtp.Port = 587;
                                smtp.Port = 465;
                            }
                        }
                        else
                        {
                            if (port > 0)
                            {
                                smtp.Port = port;
                            }
                            else
                            {
                                smtp.Port = 25;
                            }
                        }

                        smtp.Send(message);
                        ret = true;
                    }
                    else
                    {
                        ret = false;
                    }
                }
            }
            catch (Exception e)
            {
                ret = false;
                if (shouldThrowExceptions)
                {
                    string message = "An error occured sending email: " + e.Message;
                    if (e.InnerException != null)
                    {
                        message += " - " + e.InnerException.Message;
                    }
                    throw new Exception(message, e);
                }
            }

            return ret;
        
        }
    }
}
