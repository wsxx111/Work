using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;

namespace WK.Code.Email
{
    public class MailHelper
    {
        /// <summary>
        /// 邮件服务器地址
        /// </summary>
        public string MailServer { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string MailUserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string MailPassword { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string MailName { get; set; }

        /// <summary>
        /// 同步发送邮件
        /// </summary>
        /// <param name="to">收件人邮箱地址</param>
        /// <param name="subject">主题</param>
        /// <param name="body">内容</param>
        /// <param name="encoding">编码</param>
        /// <param name="isBodyHtml">是否Html</param>
        /// <param name="enableSsl">是否SSL加密连接</param>
        /// <returns>是否成功</returns>
        public bool Send(string to, string subject, string body, string encoding = "UTF-8", bool isBodyHtml = true, bool enableSsl = false)
        {
            try
            {
                MailMessage message = new MailMessage();
                // 接收人邮箱地址
                message.To.Add(new MailAddress(to));
                message.From = new MailAddress(MailUserName, MailName);
                message.BodyEncoding = Encoding.GetEncoding(encoding);
                message.Body = body;
                //GB2312
                message.SubjectEncoding = Encoding.GetEncoding(encoding);
                message.Subject = subject;
                message.IsBodyHtml = isBodyHtml;

                SmtpClient smtpclient = new SmtpClient(MailServer, 25);
                smtpclient.Credentials = new System.Net.NetworkCredential(MailUserName, MailPassword);
                //SSL连接
                smtpclient.EnableSsl = enableSsl;
                smtpclient.Send(message);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

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


        /// <summary>
        /// 异步发送邮件 独立线程
        /// </summary>
        /// <param name="to">邮件接收人</param>
        /// <param name="title">邮件标题</param>
        /// <param name="body">邮件内容</param>
        /// <param name="port">端口号</param>
        /// <returns></returns>
        public void SendByThread(string to, string title, string body, int port = 25)
        {
            new Thread(new ThreadStart(delegate()
            {
                try
                {
                    SmtpClient smtp = new SmtpClient();
                    //邮箱的smtp地址
                    smtp.Host = MailServer;
                    //端口号
                    smtp.Port = port;
                    //构建发件人的身份凭据类
                    smtp.Credentials = new NetworkCredential(MailUserName, MailPassword);
                    //构建消息类
                    MailMessage objMailMessage = new MailMessage();
                    //设置优先级
                    objMailMessage.Priority = MailPriority.High;
                    //消息发送人
                    objMailMessage.From = new MailAddress(MailUserName, MailName, System.Text.Encoding.UTF8);
                    //收件人
                    objMailMessage.To.Add(to);
                    //标题
                    objMailMessage.Subject = title.Trim();
                    //标题字符编码
                    objMailMessage.SubjectEncoding = System.Text.Encoding.UTF8;
                    //正文
                    objMailMessage.Body = body.Trim();
                    objMailMessage.IsBodyHtml = true;
                    //内容字符编码
                    objMailMessage.BodyEncoding = System.Text.Encoding.UTF8;
                    //发送
                    smtp.Send(objMailMessage);
                }
                catch (Exception)
                {
                    throw;
                }

            })).Start();
        }      

    }
}
