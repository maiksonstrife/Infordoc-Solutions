using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XmlFinder
{
    public class StringFormater
    {

        public static string RemoverZeroAEsquerda(string texto)
        {

            texto = texto.TrimStart('0');
            texto = texto.Length > 0 ? texto : "0";

            return texto;
        }

        public static string RemoverCaracteresEspeciais(string texto)
        {

            texto = Regex.Replace(texto, "[^\\w\\._]", "");

            return texto;
        }

        public static string DelimitarString(string texto, string delimitador, int[,] parametros)
        {
            //tenho que excluir "0" dos parametros
            int tamanhoParametro = parametros.Length / 2;

            switch (tamanhoParametro)
            {
                case 1:
                    texto = texto.Substring(parametros[0, 0], parametros[0, 1]); //1
                    return texto;

                case 2:
                    texto = texto.Substring(parametros[0, 0], parametros[0, 1]) + delimitador + //1
                            texto.Substring(parametros[1, 0], parametros[1, 1]);                //2
                    return texto;

                case 3:
                    texto = texto.Substring(parametros[0, 0], parametros[0, 1]) + delimitador + //1
                            texto.Substring(parametros[1, 0], parametros[1, 1]) + delimitador + //2
                            texto.Substring(parametros[2, 0], parametros[2, 1]);                //3
                    return texto;

                case 4:
                    texto = texto.Substring(parametros[0, 0], parametros[0, 1]) + delimitador + //1
                            texto.Substring(parametros[1, 0], parametros[1, 1]) + delimitador + //2
                            texto.Substring(parametros[2, 0], parametros[2, 1]) + delimitador + //3
                            texto.Substring(parametros[3, 0], parametros[3, 1]);                //4
                    return texto;

                case 5:
                    texto = texto.Substring(parametros[0, 0], parametros[0, 1]) + delimitador + //1
                            texto.Substring(parametros[1, 0], parametros[1, 1]) + delimitador + //2
                            texto.Substring(parametros[2, 0], parametros[2, 1]) + delimitador + //3
                            texto.Substring(parametros[3, 0], parametros[3, 1]) + delimitador + //4
                            texto.Substring(parametros[4, 0], parametros[4, 1]);                //5
                    return texto;

                case 6:
                    texto = texto.Substring(parametros[0, 0], parametros[0, 1]) + delimitador + //1
                            texto.Substring(parametros[1, 0], parametros[1, 1]) + delimitador + //2
                            texto.Substring(parametros[2, 0], parametros[2, 1]) + delimitador + //3
                            texto.Substring(parametros[3, 0], parametros[3, 1]) + delimitador + //4
                            texto.Substring(parametros[4, 0], parametros[4, 1]) + delimitador + //5
                            texto.Substring(parametros[5, 0], parametros[5, 1]);                //6
                    return texto;

                case 7:
                    texto = texto.Substring(parametros[0, 0], parametros[0, 1]) + delimitador + //1
                            texto.Substring(parametros[1, 0], parametros[1, 1]) + delimitador + //2
                            texto.Substring(parametros[2, 0], parametros[2, 1]) + delimitador + //3
                            texto.Substring(parametros[3, 0], parametros[3, 1]) + delimitador + //4
                            texto.Substring(parametros[4, 0], parametros[4, 1]) + delimitador + //5
                            texto.Substring(parametros[5, 0], parametros[5, 1]) + delimitador + //6
                            texto.Substring(parametros[6, 0], parametros[6, 1]);                //7
                    return texto;

                case 8:
                    texto = texto.Substring(parametros[0, 0], parametros[0, 1]) + delimitador + //1
                            texto.Substring(parametros[1, 0], parametros[1, 1]) + delimitador + //2
                            texto.Substring(parametros[2, 0], parametros[2, 1]) + delimitador + //3
                            texto.Substring(parametros[3, 0], parametros[3, 1]) + delimitador + //4
                            texto.Substring(parametros[4, 0], parametros[4, 1]) + delimitador + //5
                            texto.Substring(parametros[5, 0], parametros[5, 1]) + delimitador + //6
                            texto.Substring(parametros[6, 0], parametros[6, 1]) + delimitador + //7
                            texto.Substring(parametros[7, 0], parametros[7, 1]);                //8
                    return texto;

                case 9:
                    texto = texto.Substring(parametros[0, 0], parametros[0, 1]) + delimitador + //1
                            texto.Substring(parametros[1, 0], parametros[1, 1]) + delimitador + //2
                            texto.Substring(parametros[2, 0], parametros[2, 1]) + delimitador + //3
                            texto.Substring(parametros[3, 0], parametros[3, 1]) + delimitador + //4
                            texto.Substring(parametros[4, 0], parametros[4, 1]) + delimitador + //5
                            texto.Substring(parametros[5, 0], parametros[5, 1]) + delimitador + //6
                            texto.Substring(parametros[6, 0], parametros[6, 1]) + delimitador + //7
                            texto.Substring(parametros[7, 0], parametros[7, 1]) + delimitador + //8
                            texto.Substring(parametros[8, 0], parametros[8, 1]);                //9
                    return texto;

                case 10:
                    texto = texto.Substring(parametros[0, 0], parametros[0, 1]) + delimitador + //1
                           texto.Substring(parametros[1, 0], parametros[1, 1]) + delimitador + //2
                           texto.Substring(parametros[2, 0], parametros[2, 1]) + delimitador + //3
                           texto.Substring(parametros[3, 0], parametros[3, 1]) + delimitador + //4
                           texto.Substring(parametros[4, 0], parametros[4, 1]) + delimitador + //5
                           texto.Substring(parametros[5, 0], parametros[5, 1]) + delimitador + //6
                           texto.Substring(parametros[6, 0], parametros[6, 1]) + delimitador + //7
                           texto.Substring(parametros[7, 0], parametros[7, 1]) + delimitador + //8
                           texto.Substring(parametros[8, 0], parametros[8, 1]) + delimitador + //9
                           texto.Substring(parametros[9, 0], parametros[9, 1]);                //10
                    return texto;

            }
            MessageBox.Show("Excedeu limite máximo de posições (10)");
            return texto;
        }   
            
    }
}
