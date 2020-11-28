using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaVendas.Formulários
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }
            
		private void btnConsulta_Click(object sender, EventArgs e)
		{

		}

		private void btnProdutos_Click(object sender, EventArgs e)
		{
			frmProdutos Produtos = new frmProdutos();
			Produtos.ShowDialog();
		}

		private void btnVendas_Click(object sender, EventArgs e)
		{
			frmVendas Vendas = new frmVendas();
			Vendas.ShowDialog();
		}

        private void frmMenu_Load(object sender, EventArgs e)
        {

        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            frmClientes Funcionario = new frmClientes();
            Funcionario.ShowDialog();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
