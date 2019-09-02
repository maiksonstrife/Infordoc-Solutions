using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlFinder
{
    public class Planilha
    {
        private string data1;
        public string Filial { get; set; }
        public string Ano { get; set; }
        public string Caixa { get; set; }
        public string Protocolo { get; set; }

        public string Data
        {
            get => data1;
            set => data1 = value.Substring(6, 4) + "-" + value.Substring(3, 2) + "-" + value.Substring(0, 2);
            
        }
    }
}

