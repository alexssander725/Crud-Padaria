using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using SistemaVendas.Formulários;

namespace SistemaVendas
{
    public partial class Login : Form
    {
        SqlConnection sqlCon = null;
        private string strCon = @"Data Source=EXPC\SQLEXPRESS;Initial Catalog=dbSistemaVendas;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private string _Sql = string.Empty;

        public bool logado = false;
        public Login()
        {
            InitializeComponent();
        }

        public void logar()
        {
            sqlCon = new SqlConnection(strCon);
            string usu, pwd;

            try
            {
                usu = textBox1.Text;
                pwd = textBox2.Text;

                _Sql = "SELECT COUNT(id_usuario) FROM tb_usuario WHERE email = @email AND senha = @senha";
                SqlCommand cmd = new SqlCommand(_Sql, sqlCon);

                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = usu;
                cmd.Parameters.Add("@senha", SqlDbType.VarChar).Value = pwd;

                sqlCon.Open();

                int i = (int)cmd.ExecuteScalar();

                if (i > 0)
                {

                    MessageBox.Show("Bem vindo !");
                    logado = true;
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("Login incorreto ! ");
                    logado = false;
                }

            }
            catch (SqlException erro)
            {
                MessageBox.Show(erro + "No Banco");
            }
            sqlCon.Close();
            textBox1.Clear();
            textBox2.Clear();
        }

       

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            logar();
           
        }
        private void btnSair_Click(object sender, EventArgs e)
        {
            frmCadastro Entrar = new frmCadastro();
            Entrar.ShowDialog();

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

       
        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
