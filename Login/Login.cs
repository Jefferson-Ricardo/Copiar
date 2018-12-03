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

namespace Login
{
    public partial class telaLogin : Form
    {

        public string usuario { get; set; }
        string senha;

        SqlConnection sqlConn = null;
        private string strConn = "Data Source=GESTAODAINFOR11;Initial Catalog=Pre;Integrated Security=True";
        private string _Sql = String.Empty;

        public telaLogin()
        {
            InitializeComponent();
        }

        public void logar()
        {
            sqlConn = new SqlConnection(strConn);
            
            try
            {
                usuario = tb_usuario.Text;
                senha = tb_senha.Text;
                _Sql = "SELECT COUNT(usuario) FROM login WHERE usuario = @usuario AND senha = @senha";

                SqlCommand cmd = new SqlCommand(_Sql, sqlConn);

                cmd.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario;
                cmd.Parameters.Add("@senha", SqlDbType.VarChar).Value = senha;

                sqlConn.Open();

                int v = (int)cmd.ExecuteScalar();

                if (v > 0)
                {
                    
                    Calculo calculo = new Calculo(usuario);
                    calculo.Show();
                    this.Hide();
                } else
                {
                    MessageBox.Show("Verifique seus credenciais!");
                }


            }
            catch (SqlException erro)
            {
                MessageBox.Show(erro + "No banco");

            }
        }

        private void bt_entrar_Click(object sender, EventArgs e)
        {
            logar();
            
            
        }

        private void bt_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void telaLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
