using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlFinder
{
    public class Ferramentas
    {
        /*======================DESCRIÇÃO DAS CLASSES================================
          UI          Acesso UI       OBJETO          DAO                BD
        Design    <= variaveis UI <= Planilha <=  PlanilhaDAO <=     BDConnection
        =============================================================================*/

        #region Page1
        /* IMPORTAÇÃO
         * A pagina 1 importa de um arquivo csv/txt para o banco, esses arquivos possuem linhas, cada linha quebrada em delimitadores (1234;1234;1234)
         * OpenFileDialog é uma classe UI que armazena a escolha do usuario de um arquivo após o mesmo dar OK
         * Entao criamos uma string[] chamada Planilha conteudo que armazenará o conteudo do arquivo
         * damos get na OpenfileDialog com, string[] variavel = OpenfileDialog.filename
         * entao usamos o laço Foreach, é um laço que percorre todos elementos de um array
         * Foreach => LINHA 1 -> SEPARA DELIMITADORES[] -> PREENCHE OBJETO PLANILHA (cada delimitador corresponde a um membro) -> ENVIA PLANILHA AO DAO -> REPETE PROXIMA LINHA
         * o Laço foreach declara uma variavel do tipo do array a ser percorrido => Foreach (string line in lines) => line foi declarado e lines é o array a ser percorrido
         * uma vez dentro do laço de array, criamos outra string[] para armazenar cada parametro dentro dessa linha
         * aproveitamos a variavel declarada foreach para usar a função das classes String para dividir a linha por delimitador
         * parametros[] = line.split(delimitador (;))
         * ainda no mesmo loop preenchemos o objeto planilha (planilha.membro = parametro[0],[1],[2]...)
         * então inserimos o objeto planilha dentro da classe planilhaDAO.inserir()
         * assim acaba a primeira linha do Foreach e passamos para a proxima.
         */






        #endregion

        #region Page2
        /*page2 CONSULTA, FILTRA CONSULTA E EXPORTAÇÃO
         * CONSULTA
         * A pagina 1 usa Datagrid para visualizar a busca, o datagrid precisa ser copulado por um DataTable que é um objeto que representa uma tabela de banco de dados.
         * Para copular o dataTable precisamos usar um objeto sqldatareader, o objeto sqldataReader segura as informações da busca ao banco de dados.
         * datagrid <= datatable <= sqldatareader <=BDC
         * Segundo o padrão criado por mim mesmo
         * BDConnection = classe de conexao ao banco, aceita qualquer e quantos parametros forem necessários
         * DAO = adaptador para objeto acessar o banco
         * Objeto (planilha) = Classe com caracteristicas para objeto
         * FILTRA CONSULTA
         * 
         * 
         * 
         * 
         * EXPORTAÇÃO
         * 
        */
        #endregion
    }
}
