using System.Numerics;
using static System.Net.Mime.MediaTypeNames;

namespace PSAula10_exercicioEstacionamento
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            txtPlaca.Select();
        }
        Utilidades utilidades = new Utilidades();
        List<string> carros_estacionados = new List<string>();


        void adiciona_veiculo(TextBox txt)
        {
            if (carros_estacionados.Count >4)
            {
                MessageBox.Show("Não temos mais vagas disponíveis !!");
                return;
            }
            if (utilidades.txt_em_branco(txt) == true)
            {
                MessageBox.Show("Digita alguma coisa primo !!");
            }
            else
            {
                string estacionando = txt.Text;
                carros_estacionados.Add(estacionando);

            }
            txt.Clear();
            txt.Focus();
        }
        bool lista_esta_vazia()
        {
            if (carros_estacionados.Count > 0)
            {
                return false;
            }
            else
            {

                return true;
            }

        }
        void deleta_veiculo(TextBox txt)
        {
            if (lista_esta_vazia() == true)
            {
                MessageBox.Show("A lista está vazia !! \n" +
                                "Você não pode remover !!");
            }
            else
            {
                string deletar = txt.Text;
                for (int i = 0; i < carros_estacionados.Count; i++)
                {
                    string placa_da_vez = carros_estacionados[i];
                    deletar = txt.Text;
                    if (deletar == placa_da_vez)
                    {
                        carros_estacionados.RemoveAt(i);
                    }

                }
            }


            txt.Clear();
            txt.Focus();
        }
        void atualiza_interface()
        {
            listView_placa.Clear();
            string placa;

            for (int i = 0; i < carros_estacionados.Count; i++)
            {
                placa = ($"[ Vaga: {i + 1} ] - {carros_estacionados[i]}");
                listView_placa.Items.Add(placa);
            }


            int carros_em_vaga = 0;

            for (int i = 0; i < carros_estacionados.Count; i++)
            {

                carros_em_vaga++;

            }
            lblVeiculos.Text = $"Veículos {carros_em_vaga}";
        }
        void fechar()
        {
            if (carros_estacionados.Count > 0)
            {
                MessageBox.Show("Não podemos fechar no momento !!\n" +
                    "Ainda há carros estacionados !!");
            }
            else
            {
                Close();
            }
        }

        private void btnEstacionar_Click(object sender, EventArgs e)
        {
            adiciona_veiculo(txtPlaca);
            atualiza_interface();
        }

        private void btnRetirar_Click(object sender, EventArgs e)
        {
            deleta_veiculo(txtPlaca);
            atualiza_interface();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            fechar();
        }
    }
}