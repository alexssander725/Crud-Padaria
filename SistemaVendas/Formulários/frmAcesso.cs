using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System;

namespace SistemaVendas.Formulários
{
    
	public partial class frmAcesso : Form
	{
        //SqlConnection Conexão = new SqlConnection (@"Data Source=EXPC/SQLEXPRESS;Initial Catalog=dbSistemaVendas;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        

        public frmAcesso()
		{
			InitializeComponent();
           // textBox2.Select();
		}

		private void label2_Click(object sender, EventArgs e)
		{

		}

		private void textBox2_TextChanged(object sender, EventArgs e)
		{

		}

		private void frmAcesso_Load(object sender, EventArgs e)
		{

		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{

		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void btnCadastrar_Click(object sender, EventArgs e)
		{

		}

		private void btnEntrar_Click(object sender, EventArgs e)
		{
           // SqlConnection Conexão = new SqlConnection(@"Data Source=EXPC/SQLEXPRESS;Initial Catalog=dbSistemaVendas;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

           // Conexão.Open();
           // string query = "SELECT * FROM usuário WHERE senha = '" + textBox1.Text + "' AND senha = '" + textBox2.Text + "'";
           // SqlDataAdapter dp = new SqlDataAdapter(query, Conexão);
           // DataTable dt = new DataTable();
           // dp.Fill(dt);

           // if(dt.Rows.Count == 1)
           // {
               // frmMenu principal = new frmMenu();
               // this.Hide();
               // principal.Show();
               // Conexão.Close();
            //}
            //else
           // {
                //MessageBox.Show("Usuário ou senha incorreto", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
               // textBox1.Text = "";
               // textBox2.Text = "";
           // }
		}

		private void pictureBox1_Click_1(object sender, EventArgs e)
		{

		}
	}
}
