using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlFinder
{
    public class Documentos
    {

        public string[] Indice = {" "," "," "," "," "," "};
        public string url { get; set; }
        public string nomeDocumento { get; set; }
        public string data { get; set; }
        public void SetIndice(int number, String value)
        {
            Indice[number] = value;
        }

        public string GetIndice(int number)
        {
            return Indice[number];
        }
    }
}
