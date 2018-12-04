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
using MySql.Data.MySqlClient;

namespace Login
{
    public partial class telaLogin : Form
    {
        // Variaveis Globais
        private string conn;
        private MySqlConnection connect;
        public string usuario { get; set; }
        string senha;

        //SqlConnection sqlConn = null;
        //private string strConn = "Data Source=GESTAODAINFOR11;Initial Catalog=Pre;Integrated Security=True";
        //private string _Sql = String.Empty;

        public telaLogin()
        {
            InitializeComponent();
        }

        public void logar()
        {
            //sqlConn = new SqlConnection(strConn);


            try
            {
                //Atribuição das TextBox nas variaveis
                usuario = tb_usuario.Text;
                senha = tb_senha.Text;
                
                //COMANDOS PARA CONEXÃO SQLSERVER

                //_Sql = "SELECT COUNT(usuario) FROM login WHERE usuario = @usuario AND senha = @senha";
                //SqlCommand cmd = new SqlCommand(_Sql, sqlConn);
                //cmd.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario;
                //cmd.Parameters.Add("@senha", SqlDbType.VarChar).Value = senha;
                //sqlConn.Open();
                //int v = (int)cmd.ExecuteScalar();
                //if (v > 0)
                //{
                //    Calculo calculo = new Calculo(usuario);
                //    calculo.Show();
                //    this.Hide();
                //} else
                //{
                //    MessageBox.Show("Verifique seus credenciais!");
                //}

                // Validação campos vazios
                if (usuario == "" || senha == "")
                {
                    MessageBox.Show("Existe campos vazios!!");
                    return;
                }

                // Validação para acesso
                bool result = validaLogin(usuario, senha);
                {
                    if (result)
                    {
                        Calculo calculo = new Calculo(usuario);
                        calculo.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Favor verificar Usuário e Senha!");
                    }
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

        //Função conexao
        private void db_connection()
        {
            try
            {
                conn = "server=localhost; Database=sistPlan;Uid=root;Pwd=123456abc;";
                connect = new MySqlConnection(conn);
                connect.Open();
            }
            catch (MySqlException e)
            {
                throw;
            }
        }

        //Validação com o BD
        private bool validaLogin (string usuario, string senha)
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "Select * from tb_usuario where usuario=@usuario and senha=@senha";
            cmd.Parameters.AddWithValue("@usuario", usuario);
            cmd.Parameters.AddWithValue("@senha", senha);
            cmd.Connection = connect;
            MySqlDataReader login = cmd.ExecuteReader();
            if (login.Read())
            {
                connect.Close();
                return true;
            }
            else
            {
                connect.Close();
                return false;
            }

        }

    }
}
