using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;

namespace XmlFinder
{
    class FtpConnection
    {
        #region  //Readme
        //Formatação esperada


          

        #endregion

        public void UploadFile(string pastaLocal, string pastaNuvem, FileInfo file, string url, string username, string password)
        {
            string FtpAddress = "ftp://" + url + "/" + pastaNuvem;
            FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(FtpAddress + "/" + file.Name);
            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.Credentials = new NetworkCredential(username, password);
            request.UsePassive = true;
            request.UseBinary = true;
            request.KeepAlive = true; 
            FileStream stream = File.OpenRead(pastaLocal + "\\" + file.Name);
            byte[] buffer = new byte[stream.Length];
            stream.Read(buffer, 0, buffer.Length);
            stream.Close();
            Stream reqStream = request.GetRequestStream();
            reqStream.Write(buffer, 0, buffer.Length);
            reqStream.Close();
        }

        public List<string> ListFiles(string url, string listUsername, string ListPassword)
        {
            try
            {
                string FtpAddress = "ftp://" + url + "/";
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
            catch (Exception ex)
            {
                ErrorLogging.ErrorLog(ex);
                throw;
            }
        }

        public bool testFtpConnection (string url, string username, string password)
        {
            try
            {
                string FtpAddress = "ftp://" + url + "/";
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(FtpAddress);
                request.Method = WebRequestMethods.Ftp.ListDirectory;
                request.Credentials = new NetworkCredential(username, password);
                request.UsePassive = true;
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                response.Close();
                return true;
            }
            catch (Exception ex)
            {
                ErrorLogging.ErrorLog(ex);
                return false;
            }
        }

    }
}
