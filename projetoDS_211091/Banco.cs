using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;
using System.Security.Cryptography.X509Certificates;

namespace projetoDS_211091
{
    public class Banco
    {
        //connection responsavel por ligar ao mysql
        public static MySqlConnection Conexao;
        //command resposavel pelas instrucoes sql a serem executadas 
        public static MySqlCommand Comando;
        //adpter responsavel por inserir dados em uma datatable
        public static MySqlDataAdapter Adaptador;
        //dataTable responsavel por ligar o banco em controles com a propriedade datasource
        public static DataTable DatTable;

        public static void AbrirConexao()
        {
            try
            {
                //Estabelece parametros para a conecao com o banco 
                Conexao = new MySqlConnection("server=localhost;port=3306;uid=root;pwd=etecjau");
                //Abr a conexão com o banco de dados
                Conexao.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        public static void FecharConexao()
        {
            try
            {
                //fecha a conexão com o banco de dados
                Conexao.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        public static void CriarBanco()
        {
            try
            {
                // chama a função para a abertura do banco de dados 
                AbrirConexao();


                //Informa a instrução sql 
                Comando = new MySqlCommand("CREATE DATABASE IF NOT EXISTS vendas; USE vendas", Conexao);
                Comando.ExecuteNonQuery();

                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS Cidades" +
                                           "(id integer auto_increment primary key," +
                                           "nome char(40)," +
                                           "uf char (02))", Conexao);

                Comando.ExecuteNonQuery();

                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS Marcas" +
                                          "(id integer auto_increment primary key," +
                                          "marca char(40))", Conexao);
                Comando.ExecuteNonQuery();

                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS Categorias" +
                                          "(id integer auto_increment primary key," +
                                         "categorias char(40))", Conexao);
                Comando.ExecuteNonQuery();

                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS Clientes" +
                                         "(id integer auto_increment primary key," +
                                         "nome char(40)," +
                                         "idCidade integer," +
                                         "dataNasc date," +
                                         "renda decimal(10,2)," +
                                         "cpf char(100)," +
                                         "venda boolean)", Conexao);
                Comando.ExecuteNonQuery();

                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS Clientes" +
                                          "(id integer auto_increment primary key," +
                                          "nome char(40)," +
                                          "idCidade integer," +
                                          "idMarca integer," +
                                          "estoque decimal (10,3)," +
                                          "valorVenda decimal (10,2)," +
                                          "foto varchar(100))", Conexao);
                Comando.ExecuteNonQuery();

                //chama a função fechar a conexão com o banco
                FecharConexao();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }        

    }
}
