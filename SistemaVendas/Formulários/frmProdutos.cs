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
    public partial class frmProdutos : Form
    {
        SqlConnection sqlCon;
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlDataReader dr;
        string strCon;
        public frmProdutos()
        {
            InitializeComponent();
        }

        public void cadastro()
        {

            try
            {


                strCon = "INSERT INTO tb_produtos(id_produtos, produtos, quantidade, categoria, preço) values (@id_produtos, @produtos, @quantidade, @categoria, @preço)";
                sqlCon = new SqlConnection(@"Data Source=EXPC\SQLEXPRESS;Initial Catalog=dbSistemaVendas;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                cmd = new SqlCommand(strCon, sqlCon);
                cmd.Parameters.AddWithValue("@id_produtos", textBox1.Text);
                cmd.Parameters.AddWithValue("@produtos", textBox2.Text);
                cmd.Parameters.AddWithValue("@quantidade", textBox3.Text);
                cmd.Parameters.AddWithValue("@categoria", comboBox1.Text);
                cmd.Parameters.AddWithValue("@preço", textBox4.Text);


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
        }

        private void excluir()
        {


        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            cadastro();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lblCategoria_Click(object sender, EventArgs e)
        {

        }

        private void lblPreço_Click(object sender, EventArgs e)
        {

        }

        private void frmProdutos_Load(object sender, EventArgs e)
        {
            dgvupDados();

        }

        private void dgvupDados()
        {
            try
            {

                sqlCon = new SqlConnection(@"Data Source=EXPC\SQLEXPRESS;Initial Catalog=dbSistemaVendas;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                strCon = "SELECT * FROM tb_produtos";
                DataSet ds = new DataSet();
                da = new SqlDataAdapter(strCon, sqlCon);
                sqlCon.Open();
                da.Fill(ds);
                dgvDados.DataSource = ds.Tables[0];


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlCon.Close();

            }

        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

       
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {

                sqlCon = new SqlConnection(@"Data Source=EXPC\SQLEXPRESS;Initial Catalog=dbSistemaVendas;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                strCon = "DELETE tb_produtos WHERE id_produtos = @id_produtos ";
                cmd = new SqlCommand(strCon, sqlCon);
                cmd.Parameters.AddWithValue("@id_produtos", textBox1.Text);



                sqlCon.Open();
                dr = cmd.ExecuteReader();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlCon.Close();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
            }
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void btnSalvar_Click_1(object sender, EventArgs e)
        {
            cadastro();
        }

        private void btnConsulta_Click_1(object sender, EventArgs e)
        {
            try
            {

                sqlCon = new SqlConnection(@"Data Source=EXPC\SQLEXPRESS;Initial Catalog=dbSistemaVendas;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                strCon = "SELECT * FROM tb_produtos WHERE id_produtos = @id_produtos ";
                cmd = new SqlCommand(strCon, sqlCon);
                cmd.Parameters.AddWithValue("@id_produtos", textBox1.Text);



                sqlCon.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    textBox2.Text = (string)dr["produtos"];
                    textBox3.Text = Convert.ToString(dr["quantidade"]);
                    textBox4.Text = Convert.ToString(dr["preço"]);
                    comboBox1.Text = (string)dr["categoria"];
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlCon.Close();

            }
        }

    }
}
