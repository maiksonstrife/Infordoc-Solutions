using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;

namespace ScanPDF
{
    //Essa classe é uma constante, ela instancia um objeto quando chamada automaticamente
    public class AppSettings<T> where T : new()
    {
        private const string DEFAULT_FILENAME = "settings.ini";

        public void Save(string fileName = DEFAULT_FILENAME)
        {
            try
            {
                File.WriteAllText(fileName, (new JavaScriptSerializer()).Serialize(this));
            }
            catch (Exception e)
            {
                Console.WriteLine("## App Setting Saving Failed : " + e.Message);
            }
        }

        public static void Save(T pSettings, string fileName = DEFAULT_FILENAME)
        {
            File.WriteAllText(fileName, (new JavaScriptSerializer()).Serialize(pSettings));
        }

        public static T Load(string fileName = DEFAULT_FILENAME)
        {
            try
            { 
                T t = new T();
                if (File.Exists(fileName))
                    t = (new JavaScriptSerializer()).Deserialize<T>(File.ReadAllText(fileName));
                else
                    return default(T);
                return t;
            }
            catch (Exception e)
            {
                Console.WriteLine("## App Setting Loading Failed : " + e.Message);
                return default(T);
            }
        }
    }

    //Essa classe é instancia a partir de ouras classes
    //Ela recebe AppSettings para propriedades de Save() e Load()
    //Como parametro genérico ela envia ela mesma, pois são esses atributos que desejo salvar
    public class UserSetting : AppSettings<UserSetting>
    {
        //Virtual Scanner Settings

        //Cutter Settings  (v -> vertical, x1-3-7 -> n. de cortes, doc2-3-8 -> resultado)
        public bool isVertical = false;
        public bool vx1doc2 = false;
        public bool vx3doc4 = false;
        public bool vx7doc8 = false;

        public bool isHorizontal = false;
        public bool hx1doc2 = false;
        public bool hx3doc4 = false;
        public bool hx7doc8 = false;

        //Page Settings
        public float doc_height = 29.7f;
        public float header_height = 1.5f;
        public float footer_height = 2.5f;
        public int region_count = 6;
        public int check_interval = 1;
        public int search_depth = 2;
        public int tam_cod = 7;
        public int reg_count = 7; //quantidade de corte
        public float reg_height = 4.1f; //tamanho do corte
        public float region_height = 4.1f; //tamanho do corte (de novo ?)


        
        //Barcode Settings
        public char delimiter = ';';
        public string positions = "1;2;3";

        //Parametros Barcode
        //para retornar text que poderá ser atribuido a algum indice
        public int QuantidadeParametros = 0;

        public int parametro1i = 1;
        public int parametro1e = 2;

        public int parametro2i;
        public int parametro2e;

        public int parametro3i;
        public int parametro3e;

        public int parametro4i;
        public int parametro4e;

        public int parametro5i;
        public int parametro5e;

        public int parametro6i;
        public int parametro6e;

        public int parametro7i;
        public int parametro7e;

        public int parametro8i;
        public int parametro8e;

        public int parametro9i;
        public int parametro9e;

        public int parametro10i;
        public int parametro10e;

        //Indice Settings
        int QuantidadeIndices;
        string indice1 = "";
        string indice2 = "";
        string indice3 = "";
        string indice4 = "";
        string indice5 = "";


        //XML Settings


        //FTP Settings


        //Plan Settings



    }
}
