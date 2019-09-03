using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace XmlFinder
{
    class FtpConnection
    { 
        public void UploadFile(FileInfo file, string ftpUrl, string username, string password)
        {
            FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(ftpUrl + "/" + file.Name);
            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.Credentials = new NetworkCredential(username, password);
            request.UsePassive = true;
            request.UseBinary = true;
            request.KeepAlive = true;
            FileStream stream = File.OpenRead(ftpUrl);
            byte[] buffer = new byte[stream.Length];
            stream.Read(buffer, 0, buffer.Length);
            stream.Close();
            Stream reqStream = request.GetRequestStream();
            reqStream.Write(buffer, 0, buffer.Length);
            reqStream.Close();
        }

    }
}
