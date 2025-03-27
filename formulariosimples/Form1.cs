using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace formulariosimples
{
    public partial class frmFormularioSimples : Form
    {
        public frmFormularioSimples()
        {
            InitializeComponent();
        }

        private void btncadastrar_Click(object sender, EventArgs e)
        {
            int numerocadastro;
            string nomeusuario;
            DateTime dataNascimento;
            string cidade;
            bool generoF;
            bool generoM;
            bool generoNB;

            // Valaidação de campos obrigatórios
            if (string.IsNullOrWhiteSpace(txtNumeroCadastro.Text))
            {
                MessageBox.Show("Por favor, preencha o número de cadastro.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return; // Interrompe a execução do código caso ocampo esteja vázio
            }
            if (string.IsNullOrWhiteSpace(txtNomeCompleto.Text))
            {
                MessageBox.Show("Por favor, preencha o nome completo.","Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Validação de data de nascimento usando DateTimePicker
            dataNascimento = dateTimePicker1.Value.Date;
           
            if (dataNascimento >= DateTime.Now.Date) // Compara com a data atual sem hora
            {
                MessageBox.Show("Verifique novamente a sua data de nascimento.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
            }


            if (comboBoxCidade.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleciona a cidade.","Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!rbFeminino.Checked && !rbMaculino.Checked && !rbNaoBinario.Checked)
            {
                MessageBox.Show("por favor, Selecione o gênero", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Agora, caso todos os campos estejam preenchidos, a validação prossegue
            numerocadastro = Convert.ToInt32(txtNumeroCadastro.Text);
            nomeusuario = txtNomeCompleto.Text;
            cidade = comboBoxCidade.Text;
            generoF = rbFeminino.Checked;
            generoM = rbMaculino.Checked;
            generoNB = rbNaoBinario.Checked;

            //Formatar a data para exibir apenas a data (sem a hora)
            string dataFormatada = dataNascimento.ToString("dd/MM/yyyy");

            //Determinar o gênero selecionado

            string generoSelecionado = "Não informado"; // Caso nehum g~enro seja selecionado
            if (generoF)
                generoSelecionado = "Feminino";
            else if (generoM)
                generoSelecionado = "Masculino";
            else if (generoNB)
                generoSelecionado = "Não Binário";

            //Exibir as informações em MessageBox
            MessageBox.Show("Número Cadastro: " + numerocadastro);
            MessageBox.Show("Nome: " + nomeusuario);
            MessageBox.Show("Data de nascimento: " + dataFormatada);
            MessageBox.Show("Cidade: " + cidade);
            MessageBox.Show("Gênero: " + generoSelecionado);
           
        }

        private void txtNumeroCadastro_Click(object sender, EventArgs e)
        {
            // Limpa o conteúdo do TextBox quando o usuário  clica nele.
           if( txtNumeroCadastro.Text == "Número cadastro")
            {
                txtNumeroCadastro.Text = "";
            }
        }

        private void txtNomeCompleto_Click(object sender, EventArgs e)
        {
            // Limpa o conteúdo do textbox nomeCompleto quando o usuário clicar nela
            if(txtNomeCompleto.Text == "Insira o seu nome Completo")
            {
                txtNomeCompleto.Text = "";
            }
            
        }
    }
}
