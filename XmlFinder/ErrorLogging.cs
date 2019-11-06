using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlFinder
{
    public class ErrorLogging
    {

        public static void ErrorLog(Exception ex)
        {
            string strPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)) + @"\InfordocSolutions\Log\";

            string hourMinute;
            hourMinute = DateTime.Now.ToString("HH-mm");
            strPath += "Log" + hourMinute + ".txt";

            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)) + @"\InfordocSolutions\Log\";

            if (Directory.Exists(path) == false)
            {
                Directory.CreateDirectory(path);
            }


            if (!File.Exists(strPath))
            {
                File.Create(strPath).Dispose();
            }

            using (StreamWriter sw = File.AppendText(strPath))
            {
                sw.WriteLine(" =============Error Logging ===========");
                sw.WriteLine("===========Start============= " + DateTime.Now);
                sw.WriteLine("Error Message: " + ex.Message);
                sw.WriteLine("Stack Trace: " + ex.StackTrace);
                sw.WriteLine("===========End============= " + DateTime.Now);

            }
        }

        public static void ReadError()
        {
            string strPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)) + @"\InfordocSolutions\Log\Log.txt";
            using (StreamReader sr = new StreamReader(strPath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }

    }
}
