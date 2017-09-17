using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace WK.Web.Common
{
    public class UploadFileController : Controller
    {
        //上传图片
        public ActionResult Preview(string baseimg)
        {
            string url = "http://imgu.fang.com/upload/pic?isflash=y&channel=kanli.pic&city=";//低于5M大小的图片 

            string html = PostData3(url, 1000000, "filedata", @"D:\upload\123.jpg", baseimg.Split(',')[1]);

            return this.Json(new { Response = html });
        }


        private string PostData3(string url, int timeOut, string fileKeyName, string filePath, string base64str)
        {
            string responseContent;
            var memStream = new MemoryStream();
            var webRequest = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
            // 边界符
            var boundary = "------------" + DateTime.Now.Ticks.ToString("x");
            // 编码边界符
            var firstBoundary = System.Text.Encoding.ASCII.GetBytes("--" + boundary + "\r\n");//拼接第一个form表单值用到
            var encodingBoundary = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");
            var endBoundary = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");
            MemoryStream fileStream = new MemoryStream(Convert.FromBase64String(base64str)); //base64编码方式         
            // 设置属性
            webRequest.Method = "POST";
            webRequest.Timeout = timeOut;
            webRequest.ContentType = "multipart/form-data; boundary=" + boundary;

            #region file表单值
            const string filePartHeader =
                    "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\n" +
                     "Content-Type: application/octet-stream\r\n\r\n";
            var header = string.Format(filePartHeader, fileKeyName, "123.jpg");
            var headerbytes = System.Text.Encoding.UTF8.GetBytes(header);

            memStream.Write(encodingBoundary, 0, encodingBoundary.Length);
            memStream.Write(headerbytes, 0, headerbytes.Length);

            var buffer = new byte[1024];
            int bytesRead; // =0
            while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
            {
                memStream.Write(buffer, 0, bytesRead);
            }
            #endregion

            // 写入最后的结束边界符
            memStream.Write(endBoundary, 0, endBoundary.Length);

            webRequest.ContentLength = memStream.Length;

            var requestStream = webRequest.GetRequestStream();

            memStream.Position = 0;
            var tempBuffer = new byte[memStream.Length];
            memStream.Read(tempBuffer, 0, tempBuffer.Length);
            memStream.Close();

            requestStream.Write(tempBuffer, 0, tempBuffer.Length);
            requestStream.Close();

            var httpWebResponse = (System.Net.HttpWebResponse)webRequest.GetResponse();

            using (var httpStreamReader = GetWebContent(httpWebResponse))
            {
                responseContent = httpStreamReader.ReadToEnd();
            }

            fileStream.Close();
            httpWebResponse.Close();
            webRequest.Abort();

            return responseContent;
        }

        private static StreamReader GetWebContent(System.Net.HttpWebResponse response)
        {
            Stream desStream;
            if (response.ContentEncoding == "gzip")
            {
                desStream = new System.IO.Compression.GZipStream(response.GetResponseStream(), System.IO.Compression.CompressionMode.Decompress);

            }
            else
            {
                desStream = response.GetResponseStream();
            }

            string strcs = response.CharacterSet;
            StreamReader xmlStream;
            if (strcs == "")
            {
                xmlStream = new System.IO.StreamReader(desStream, System.Text.Encoding.Default);
            }
            else
            {
                strcs = strcs.Trim().ToLower();
                switch (strcs)
                {
                    case "gb2312":
                        xmlStream = new System.IO.StreamReader(desStream, System.Text.Encoding.GetEncoding("gb2312"));
                        break;
                    case "utf-8":
                        xmlStream = new System.IO.StreamReader(desStream, System.Text.Encoding.UTF8);
                        break;
                    default:
                        xmlStream = new System.IO.StreamReader(desStream, System.Text.Encoding.Default);
                        break;
                }

            }
            return xmlStream;
        }



        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="tbFilePath"></param>
        /// <returns></returns>
        public ActionResult UploadFileData(HttpPostedFileBase Filedata)
        {
            var actionResult = default(ContentResult);
            bool flag = false;
            var message = "";
            var fileurl = "";
            try
            {
                // 如果没有上传文件
                if (Filedata == null || string.IsNullOrEmpty(Filedata.FileName) || Filedata.ContentLength == 0)
                {
                    message = "找不到要上传的文件，请重新上传";
                }
                else
                {
                    // 保存到  指定位置
                    string filename = System.IO.Path.GetFileName(Filedata.FileName);
                    string fileExtension = Filedata.FileName.Substring(Filedata.FileName.LastIndexOf('.'));
                    string uploadPath = Server.MapPath("~/Files/Upload/");
                    string fullFileName = fileExtension;
                    // 文件系统不能使用虚拟路径
                    Directory.CreateDirectory(uploadPath);
                    Filedata.SaveAs(uploadPath + fullFileName);
                    fileurl = Request.Url.Host + "/Files/Upload/" + fullFileName;
                    message = "上传成功";
                    flag = true;
                }
            }
            catch (Exception ex)
            {
                message = "上传遇到问题，请重试，问题描述：" + ex.Message;
                flag = false;
            }
            JavaScriptSerializer js = new JavaScriptSerializer();

            actionResult.Content = js.Serialize(new
                {
                    Message = message,
                    Flag = flag ? "Success" : "Error",
                    furl = fileurl,
                });
            return actionResult;
        }

    }
}
