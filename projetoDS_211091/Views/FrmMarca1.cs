using projetoDS_211091.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projetoDS_211091.Views
{
    public partial class FrmMarca1 : Form

    {
        Marca m;
        public FrmMarca1()
        {
            InitializeComponent();
        }
        void limpaControles()
        {
            txtID.Clear();
            txtMarcas.Clear();
            txtPesquisa.Clear();

        }

        void carregarGrid(string pesquisa)
        {
            m = new Marca()
            {
                marca = pesquisa
            };
            dgvMarcas.DataSource = m.Consultar();

        }
        private void FrmMarca1_Load(object sender, EventArgs e)
        {
            limpaControles();
            carregarGrid("");
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMarcas.Text == String.Empty) return;

                m = new Marca()

                {
                    marca = txtMarcas.Text

                };

                m.Incluir();

                limpaControles();
                carregarGrid("");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtID.Text == String.Empty) return;

                m = new Marca()
                {
                    id = int.Parse(txtID.Text),
                    marca = txtMarcas.Text
                };

                m.Alterar();

                limpaControles();
                carregarGrid("");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpaControles();
            carregarGrid("");
            dgvMarcas.SelectedRows.Equals(0);
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtID.Text == String.Empty) return;

                if (MessageBox.Show("Deseja mesmo excluir essa marca do registro?", "Excluir?",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    m = new Marca()
                    {
                        id = int.Parse(txtID.Text),
                    };
                    m.delete();

                    limpaControles();
                    carregarGrid("");
                }

                MessageBox.Show("Marca excluida com sucesso!", "Operação bem sucedida!",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pesquisa_Click(object sender, EventArgs e)
        {
            carregarGrid(txtPesquisa.Text);

        }

        private void dgvMarcas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvMarcas.RowCount > 0)
                {
                    txtID.Text = dgvMarcas.CurrentRow.Cells["id"].Value.ToString();
                    txtMarcas.Text = dgvMarcas.CurrentRow.Cells["marca"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
