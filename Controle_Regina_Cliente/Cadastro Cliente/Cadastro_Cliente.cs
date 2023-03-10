using Controle_Regina_Cliente.Menu;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controle_Regina_Cliente.Conexao_BD;

namespace Controle_Regina_Cliente.Cliente
{
    public partial class Cadastro_Cliente : Form
    {
        public Cadastro_Cliente()
        {
            InitializeComponent();
        }

        private void Lbl_Text_Client_Click(object sender, EventArgs e)
        {

        }

        private void Cadastro_Cliente_Load(object sender, EventArgs e)
        {

        }
        //limita dados não numericos a textbox
        private void Txt_Cliente_DDD_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(Txt_Cliente_DDD.Text, "[^0-9]"))
            {
                MessageBox.Show("Digite somente o DDD");
                if (Txt_Cliente_DDD.Text.Length > 0)
                {
                    Txt_Cliente_DDD.Text = Txt_Cliente_DDD.Text.Remove(Txt_Cliente_DDD.Text.Length - 1);
                }
            };
        }
        //limita dados não numericos a textbox
        private void Txt_Cliente_Tel_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(Txt_Cliente_Tel.Text, "[^0-9]"))
            {
                MessageBox.Show("Digite somente telefone");
                if (Txt_Cliente_Tel.Text.Length > 0)
                {
                    Txt_Cliente_Tel.Text = Txt_Cliente_Tel.Text.Remove(Txt_Cliente_Tel.Text.Length- 1);
                }
            }
        }
        //envia o usuario para o menu
        private void retornaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Menu.Menu viajar = new Menu.Menu();
            viajar.Show();
            this.Hide();
        }
        //transmite os dados informados nas textbox para o banco de dados local
        private void salvarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string nome = Txt_Cliente_Cadastro.Text;
            string bairro = Txt_Cliente_Bairro.Text;
            string DDD = Txt_Cliente_DDD.Text;
            string telefone = Txt_Cliente_Tel.Text;


            Conexao_Cliente connection = new Conexao_Cliente();

            var cone = connection.CriarConexao();

            string comando = "INSERT INTO Dados_Clientes([Nome Cliente], [Bairro Cliente], [DDD Telefone], [Telefone Cliente]) VALUES ('" + nome + "', '" + bairro + "', '" + DDD + "', '" + telefone + "')";

            try
            {
                SqlCommand command = new SqlCommand(comando, connection.CriarConexao());

                command.ExecuteNonQuery();

                MessageBox.Show("Cadastro Realizado");

                this.Hide();

                Menu.Menu viaja = new Menu.Menu();
                viaja.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar cliente" + ex.Message);
            }
        }
    }
}
