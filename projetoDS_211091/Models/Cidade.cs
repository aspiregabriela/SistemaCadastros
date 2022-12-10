using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient ;
using System.Drawing.Text;
using System.Windows.Forms;
using System.Security.Cryptography.X509Certificates;

namespace projetoDS_211091.Models
{
    internal class Cidade
    {
        public int id { get; set; }
        public string nome { get; set; }

        public string uf { get; set; }


        public void Incluir()
        {
            try
            {
                //abre a conexão com o banco
                Banco.AbrirConexao();
                //Alimenta o método Comand com a instrução desejada e indica a conexão utilizada
                Banco.Comando = new MySqlCommand("INSERT INTO cidades (nome, uf) VALUES (@nome, @uf)", Banco.Conexao);
                //Cria parametros 
                Banco.Comando.Parameters.AddWithValue("@nome", nome); //parametro string
                Banco.Comando.Parameters.AddWithValue("@uf", uf);
                //executa o comando no mysql
                Banco.Comando.ExecuteNonQuery();
                //fecha conexão
                Banco.FecharConexao();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Excluir()
        {
            try
            {

                //abre a conexão com o banco
                Banco.AbrirConexao();
                //Alimenta o método Comand com a instrução desejada e indica a conexão utilizada
                Banco.Comando = new MySqlCommand("delete from cidades where id=@id", Banco.Conexao);

                Banco.Comando.Parameters.AddWithValue("@id", id); //parametro string
                                                                  //executa o comando no mysql
                Banco.Comando.ExecuteNonQuery();
                //fecha conexão
                Banco.FecharConexao();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public DataTable Consultar()
        {
            try
            {
                Banco.AbrirConexao();
                Banco.Comando = new MySqlCommand("SELECT * FROM Cidades where nome like @nome_cidade order by nome", Banco.Conexao);
                Banco.Comando.Parameters.AddWithValue("@nome_cidade", nome);
                Banco.Adaptador = new MySqlDataAdapter(Banco.Comando);
                Banco.DatTable = new DataTable();
                Banco.Adaptador.Fill(Banco.DatTable);
                Banco.FecharConexao();
                return Banco.DatTable;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }

            public void Alterar()
            {
            try
            {
                Banco.Comando = new MySqlCommand("UPDATE cidades set nome= @nome, uf=@uf WHERE id =@id", Banco.Conexao);
                Banco.Comando.Parameters.AddWithValue("@nome", nome);
                Banco.Comando.Parameters.AddWithValue("@uf", uf);
                Banco.Comando.Parameters.AddWithValue("@id", id);
                Banco.Comando.ExecuteNonQuery();


                Banco.FecharConexao();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);



            }
            
            }











        
    }
}
