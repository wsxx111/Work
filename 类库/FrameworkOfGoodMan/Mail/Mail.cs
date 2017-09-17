using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace FrameworkOfGoodMan.Tools.Mail
{
    /// <summary>
    /// 邮件发送
    /// </summary>
    public static class Mail
    {
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="isBodyHtml">正文是否是HTML格式</param>
        /// <param name="subject">主题</param>
        /// <param name="body">内容</param>
        /// <param name="account">账号名</param>
        /// <param name="password">密码</param>
        /// <param name="mailServer">服务器</param>
        /// <param name="to">接收者</param>
        /// <param name="cc">抄送者</param>
        /// <param name="bcc">秘送者</param>
        /// <param name="attachFile">附件</param>
        public static bool Send(bool isBodyHtml, string subject, string body, string account, string password, string mailServer, string[] to, string[] cc = null, string[] bcc = null, string[] attachFile = null)
        {
            try
            {
                using (var mailMessage = new MailMessage())
                {
                    mailMessage.Subject = subject;
                    mailMessage.Body = body;
                    mailMessage.From = new MailAddress(account + "@" + mailServer.Substring(5));
                    mailMessage.IsBodyHtml = isBodyHtml;

                    #region 收件者
                    if (to != null && to.Length > 0)
                    {
                        for (int i = 0; i < to.Length; i++)
                        {
                            mailMessage.To.Add(new MailAddress(to[i]));
                        }
                    }

                    if (cc != null && cc.Length > 0)
                    {
                        for (int i = 0; i < cc.Length; i++)
                        {
                            mailMessage.CC.Add(new MailAddress(cc[i]));
                        }
                    }

                    if (bcc != null && bcc.Length > 0)
                    {
                        for (int i = 0; i < bcc.Length; i++)
                        {
                            mailMessage.Bcc.Add(new MailAddress(bcc[i]));
                        }
                    }
                    if (attachFile != null && attachFile.Length > 0)
                    {
                        for (int i = 0; i < attachFile.Length; i++)
                        {
                            if (File.Exists(attachFile[i]))
                            {
                                var attach = new Attachment(attachFile[i]);
                                mailMessage.Attachments.Add(attach);
                            }
                        }
                    }
                    #endregion

                    var smtpClient = new SmtpClient(mailServer, 25);
                    smtpClient.Credentials = new NetworkCredential(account, password);                
                    smtpClient.Send(mailMessage);                  
                }
                return true;
            }
            catch
            {
                return false;
            }
        }      

    }
}
