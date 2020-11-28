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

namespace SistemaVendas.Formulários
{
    public partial class frmCadastro : Form
    {
        SqlConnection sqlCon;
        SqlCommand cmd;
        string strCon;
        public frmCadastro()
        {
            InitializeComponent();
        }

        public void cadastro()
        {

            try
            {


                strCon = "INSERT INTO tb_usuario(id_usuario, nome, email, telefone, senha) values (@id_usuario, @nome, @email, @telefone, @senha)";
                sqlCon = new SqlConnection(@"Data Source=EXPC\SQLEXPRESS;Initial Catalog=dbSistemaVendas;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                cmd = new SqlCommand(strCon, sqlCon);
                cmd.Parameters.AddWithValue("@id_usuario", textBox1.Text);
                cmd.Parameters.AddWithValue("@nome", textBox2.Text);
                cmd.Parameters.AddWithValue("@email", textBox3.Text);               
                cmd.Parameters.AddWithValue("@telefone", textBox4.Text);
                cmd.Parameters.AddWithValue("@senha", textBox5.Text);


                sqlCon.Open();
                cmd.ExecuteNonQuery();

                MessageBox.Show("Cadastrado com sucesso !");

            }
            catch (SqlException erro)
            {
                MessageBox.Show(erro + "No Banco");
            }
            finally
            {
                sqlCon.Close();

            }
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }
        private void frmCadastro_Load(object sender, EventArgs e)
        {

        }

        private void btnConcluído_Click(object sender, EventArgs e)
        {
            cadastro();
        }
    }
}
