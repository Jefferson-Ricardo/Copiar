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
using System.IO;

namespace Login
{
    public partial class Calculo : Form
    {

        // Classe Dados da OP
        public class Dados
        {
            public int numOP { get; set; }
            public int calculo { get; set; }
            public string tipo { get; set; }
            public string cliente { get; set; }
            public string produto { get; set; }
            public string titulo { get; set; }
        }
        
        // Instância da Conexão
        SqlConnection sqlConn = null;
        private string strConn = "Data Source=GESTAODAINFOR11;Initial Catalog=Pre;Integrated Security=True";
        private string _Sql = String.Empty;


        public Calculo()
        {
            InitializeComponent();
            
        }


        public Calculo(string nomeUsuario)
        {
            InitializeComponent();
            tb_logado.Text = nomeUsuario;
        }
        
        // Busca Dados da OP pelo Numero do Calculo
        private Dados buscaOP(int calculo)
        {
            // Cria Objeto Dados da OP
            Dados dados = new Dados();

            //Cria a Conexão com o banco
            sqlConn = new SqlConnection(strConn);

            try
            {
                // String com o comando de busca do banco
                _Sql = "SELECT * FROM dados WHERE Calculo=@calculo";

                //Instancia do comando recebendo como parâmetro a string do comando e a conexao
                SqlCommand cmd = new SqlCommand(_Sql, sqlConn);

                // Parametro do comando de busca no banco
                cmd.Parameters.AddWithValue("@Calculo", calculo);

                // Abre conexao
                sqlConn.Open();

                // Instancia do leitor dos resultados
                SqlDataReader result = cmd.ExecuteReader();

                // Enquanto lê os resultados
                while (result.Read())
                {
                    // passa os valores para variaveis
                    dados.numOP = Convert.ToInt32(result["NumOP"].ToString());
                    dados.tipo = result["Tipo"].ToString();
                    dados.cliente = result["Cliente"].ToString();
                    dados.produto = result["Produto"].ToString();
                    dados.titulo = result["Titulo"].ToString();
                    dados.calculo = Convert.ToInt32(result["Calculo"].ToString());
                }

                // Insere os valores retornados em textbox do formulario
                tb_numOP.Text = dados.numOP.ToString();
                tb_nomeCliente.Text = dados.cliente;
                tb_tipoOP.Text = dados.tipo;
                tb_produto.Text = dados.produto;
                tb_titulo.Text = dados.titulo;

            }
            catch (SqlException erro)
            {
                // Messagem se der erro
                MessageBox.Show(erro + "Na Busca");
            }

            // Fecha a conexao
            sqlConn.Close();

            // Retorna os dados
            return dados;

        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            // Cria variavel do numero do calculo
            int calculo = int.Parse(tb_numCalculo.Text);

            // Chama o metodo passando o numero do calculo
            buscaOP(calculo);
        }



        private void btn_copiar_Click(object sender, EventArgs e)
        {
            //Caminhos Origem e Destino
            string diretorioOrigem = "C:\\Users\\jricardo\\Documents\\Teste_Triagem\\" + tb_numCalculo.Text;
            string padrao = "C:\\";
            string separador = "\\";
            string mesAtual = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString();
            string traco = " - ";
            string servico = tb_numOP.Text + traco + tb_nomeCliente.Text + traco + tb_produto.Text + traco + tb_titulo.Text + traco + tb_numCalculo.Text;
            string diretorioDestino = padrao + tb_logado.Text + separador + mesAtual + separador + tb_nomeCliente.Text + separador + servico;
            
            CopiarEstrutura(diretorioOrigem, diretorioDestino, true);
        }

        private static void CopiarEstrutura(string diretorioOrigem, string diretorioDestino, bool copySubDirs)
        {
            //Copiar pastas e subpastas
            DirectoryInfo dir = new DirectoryInfo(diretorioOrigem);
            try
            {
                if (!dir.Exists)
                {
                    throw new DirectoryNotFoundException(
                        "Estrutura não Localizada: " + diretorioOrigem
                        );
                }
                
                // Copia Pastas
                DirectoryInfo[] dirs = dir.GetDirectories();
                if (!Directory.Exists(diretorioDestino))
                {
                    Directory.CreateDirectory(diretorioDestino);
                }

                //Copia arquivos
                FileInfo[] files = dir.GetFiles();

                foreach (FileInfo file in files)
                {
                    string temppath = Path.Combine(diretorioDestino, file.Name);
                    file.CopyTo(temppath, false);
                }

                //Copia subpastas se houver
                if (copySubDirs)
                {
                    foreach (DirectoryInfo subdir in dirs)
                    {
                        string temppath = Path.Combine(diretorioDestino, subdir.Name);
                        CopiarEstrutura(subdir.FullName, temppath, copySubDirs);
                    }
                }
            } catch(Exception e)
            {
                MessageBox.Show("Estrutura não localizada!");
            }
            


        }
    }
}

