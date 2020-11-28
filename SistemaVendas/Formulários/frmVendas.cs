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
    public partial class frmVendas : Form
    {
       
        public frmVendas()
        {
            InitializeComponent();
        }
        SqlConnection sqlCon = null;
        private string strCon = @"Data Source=EXPC\SQLEXPRESS;Initial Catalog=dbSistemaVendas;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private string _Sql = string.Empty;

        decimal total;

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            int id = Convert.ToInt32(textBox1.Text);
            _Sql = "SELECT id_produtos, produtos, quantidade, preço FROM tb_produtos WHERE id_produtos = @id_produtos ";
            sqlCon = new SqlConnection(strCon);

            SqlCommand cmd = new SqlCommand(_Sql, sqlCon);
            cmd.Parameters.Add("@id_produtos", SqlDbType.Int).Value = id;

            try
            {
               
                sqlCon.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();

                lblNome.Text = Convert.ToString(dr["produtos"]);
                lblPreço.Text = Convert.ToString(dr["preço"]);

                int quantidade = int.Parse(textBox2.Text);
                decimal preço = decimal.Parse(lblPreço.Text);
                total = total + (preço * quantidade);

                lblValortotal.Text = total.ToString();

                textBox1.Focus();
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
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            _Sql = ("UPDATE tb_produtos SET id_produtos = id_produtos '" + textBox1.Text + "' WHERE id_produtos = @id_produtos ");
            sqlCon = new SqlConnection(strCon);
            SqlCommand cmd = new SqlCommand(_Sql, sqlCon);
            cmd.Parameters.Add("@id_produtos", SqlDbType.Int).Value = textBox1.Text;

            try
            {
                sqlCon.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Venda efetuada");
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

        private void frmVendas_Load(object sender, EventArgs e)
        {
            dgvupDados();
        }

        private void lblQuantidade_Click(object sender, EventArgs e)
        {

        }

        private void dgvupDados()
        {
            try
            {

                sqlCon = new SqlConnection(@"Data Source=EXPC\SQLEXPRESS;Initial Catalog=dbSistemaVendas;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                _Sql = "SELECT * FROM tb_produtos";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(_Sql, sqlCon);
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

    }
}
