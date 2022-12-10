using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using projetoDS_211091.Models;


namespace projetoDS_211091.Views
{
    public partial class FrmCidades : Form

    {
        Cidade c;
        public FrmCidades()
        {
            InitializeComponent();
        }

        void limpaControlees()
        {
            txtID.Clear();
            txtNome.Clear();
            txtUF.Clear();
            txtPesquisa.Clear();

        }
        void carregarGrid(string pesquisa)
        {
            c = new Cidade()
            {   
                nome = pesquisa
            };

            dgvCidades.DataSource = c.Consultar();

        }

        private void FrmCidades_Load(object sender, EventArgs e)
        {
            limpaControlees();
            carregarGrid("");

        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == String.Empty) return;
            c = new Cidade()
            {
                nome = txtNome.Text,
                uf = txtUF.Text

            };
            c.Incluir();

            limpaControlees();
            carregarGrid("");

        }

        private void dgvCidades_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCidades.Rows.Count > 0)
            {
                txtID.Text = dgvCidades.CurrentRow.Cells["id"].Value.ToString();
                txtNome.Text = dgvCidades.CurrentRow.Cells["Nome"].Value.ToString();
                txtUF.Text = dgvCidades.CurrentRow.Cells["uf"].Value.ToString();


            }

        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtID.Text == String.Empty) return;
            c = new Cidade()
            {
                id =int.Parse(txtID.Text),
                nome = txtNome.Text,
                uf = txtUF.Text
            };
            c.Alterar();

            limpaControlees();
            carregarGrid("");
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "") return;
            if(MessageBox.Show("Deseja excluir a cidade?", "Exclusão",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            { 
                c = new Cidade()
                {
                    id = int.Parse(txtID.Text)
                };
                c.Excluir();

                limpaControlees();
                carregarGrid("");

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

            limpaControlees();
            carregarGrid("");
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
          Close();
        }

        private void pesquisa_Click(object sender, EventArgs e)
        {
            carregarGrid(txtPesquisa.Text);
        }

        private void FrmCidades_Load_1(object sender, EventArgs e)
        {

        }
    }  
}
