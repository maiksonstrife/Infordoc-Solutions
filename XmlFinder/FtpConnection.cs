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

        public List<string> ListFiles(string FtpAddress, string listUsername, string ListPassword)
        {
            try
            {
                FtpAddress = "ftp://" + FtpAddress + "/";
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(FtpAddress);
                request.Method = WebRequestMethods.Ftp.ListDirectory;
                request.Credentials = new NetworkCredential(listUsername, ListPassword);
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);
                string names = reader.ReadToEnd();

                reader.Close();
                response.Close();

                return names.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            }
            catch (WebException)
            {
                throw;
            }
        }

        public bool testFtpConnection (string FtpAddress, string listUsername, string ListPassword)
        {
            try
            {
                FtpAddress = "ftp://" + FtpAddress + "/";
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(FtpAddress);
                request.Method = WebRequestMethods.Ftp.ListDirectory;
                request.Credentials = new NetworkCredential(listUsername, ListPassword);
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                response.Close();
                return true;
            }
            catch (WebException ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

    }
}
