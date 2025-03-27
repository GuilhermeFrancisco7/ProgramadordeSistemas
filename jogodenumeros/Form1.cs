using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jogodenumeros
{
    public partial class frmjogodenumeros : Form
    {
        int randomNumber;
        int numeroTentativas = 10;
        int palpitedoJogador;
        bool jogoGanho = false;
        string dica;

        public frmjogodenumeros()
        {
            InitializeComponent();
        }

        private void frmjogodenumeros_Load(object sender, EventArgs e)
        {
            Random random = new Random();
            randomNumber = random.Next(1, 101); // Metodo Random vai gerar números entre 1 e 100.

        }

        private void btnTentativas_Click(object sender, EventArgs e)
        {
            // Verifica se o número de tentativas é maior que zero!
            if(numeroTentativas == 0)
            {
                txtResultado.Text = "Você não tem mais tentaticas. O jogo acabou";
                return;
            }

            // Validação do valor do palpite (entre 1 e 100)
            if (!int.TryParse(txtNumeroInserido.Text, out palpitedoJogador) || palpitedoJogador < 1 || palpitedoJogador > 100)
            {
                txtResultado.Text = "Por Favor, Insira um número entre 1 e 100";
                return;
            }
            numeroTentativas--;
            lblNumTentativas.Text = numeroTentativas.ToString();


            if(palpitedoJogador == randomNumber)
            {
                jogoGanho = true;
                dica = "Parabéns, você Acertou!!!";
            }
            else if(palpitedoJogador < randomNumber)
            {
                dica = " O número do seu palpite é Menor!";
            }
            else 
            {
                dica = " O número do seu palpite é Maior!";
            }

            txtResultado.Text = dica;
        
        }
    }
}
