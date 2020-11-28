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
    public partial class frmClientes : Form
    {
        SqlConnection sqlCon;
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlDataReader dr;
        string strCon;

        public frmClientes()
        {
            InitializeComponent();
        }
       
        public void cadastro()
        {
            string dat;
            try
            {                
                dat = dateTime.Text;



                sqlCon = new SqlConnection(@"Data Source=EXPC\SQLEXPRESS;Initial Catalog=dbSistemaVendas;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                strCon = "INSERT INTO tb_clientes(id_clientes, nome, cpf, telefone, data_nascimento, endereço) values (@id_clientes, @nome, @cpf, @telefone, @data_nascimento, @endereço)";               
                cmd = new SqlCommand(strCon, sqlCon);
                cmd.Parameters.AddWithValue("@id_clientes", textBox1.Text);
                cmd.Parameters.AddWithValue("@nome", textBox2.Text);
                cmd.Parameters.AddWithValue("@cpf", textBox3.Text);
                cmd.Parameters.AddWithValue("@telefone", maskedTextBox1.Text);
                cmd.Parameters.Add("@data_nascimento", SqlDbType.Date).Value = dat;
                cmd.Parameters.AddWithValue("@endereço", textBox5.Text);

                sqlCon.Open();
                cmd.ExecuteNonQuery();

                MessageBox.Show("Cadastrado com sucesso !");
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlCon.Close();
                sqlCon = null;
                cmd = null;
            }
            textBox1.Clear();
            textBox2.Clear();
            maskedTextBox1.Clear();
            textBox3.Clear();
            textBox5.Clear();

        }
        private void excluir()
        {
    
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void dgvupDados()
        {
            try
            {

                sqlCon = new SqlConnection(@"Data Source=EXPC\SQLEXPRESS;Initial Catalog=dbSistemaVendas;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                strCon = "SELECT * FROM tb_clientes";
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

        private void frmFuncionários_Load(object sender, EventArgs e)
        {
            dgvupDados();

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
            
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            cadastro();          
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox45_TextChanged(object sender, EventArgs e)
        {

        }
      
        private void btnConsulta_Click_1(object sender, EventArgs e)
        {
            try
            {

                sqlCon = new SqlConnection(@"Data Source=EXPC\SQLEXPRESS;Initial Catalog=dbSistemaVendas;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                strCon = "SELECT * FROM tb_clientes WHERE id_clientes = @id_clientes ";
                cmd = new SqlCommand(strCon, sqlCon);
                cmd.Parameters.AddWithValue("@id_clientes", textBox1.Text);



                sqlCon.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    textBox2.Text = (string)dr["nome"];
                    textBox3.Text = (string)dr["cpf"];
                    maskedTextBox1.Text = (string)dr["telefone"];
                    dateTime.Text = Convert.ToString(dr["data_nascimento"]);
                    textBox5.Text = (string)dr["endereço"];

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

        private void btnExcluir_Click_1(object sender, EventArgs e)
        {
            try
            {

                sqlCon = new SqlConnection(@"Data Source=EXPC\SQLEXPRESS;Initial Catalog=dbSistemaVendas;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                strCon = "DELETE tb_clientes WHERE id_clientes = @id_clientes ";
                cmd = new SqlCommand(strCon, sqlCon);
                cmd.Parameters.AddWithValue("@id_clientes", textBox1.Text);



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
                maskedTextBox1.Clear();
                textBox3.Clear();
                textBox5.Clear();
            }
        }

        private void lblCPF_Click(object sender, EventArgs e)
        {

        }
    }
}   
