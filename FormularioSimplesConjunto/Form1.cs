using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using MySql.Data.MySqlClient;

namespace FormularioSimples
{
    public partial class frmFormularioSimples : Form
    {
        // Conexão com o banco
        MySqlConnection Conexao;
        string data_source = "server=localhost;userid=root;password=;database=formulariosimples;";

        public frmFormularioSimples()
        {
            InitializeComponent();

            //Configuração inicial do ListView para exibição dos dados dos clientes
            lstCadastrados.View = View.Details;         //Define a visualização como "Detalhes"
            lstCadastrados.LabelEdit = true;           //Permite editar os títulos das colunas
            lstCadastrados.AllowColumnReorder = true; //Permite reordenar as colunas
            lstCadastrados.FullRowSelect = true;     //Seleciona a linha inteira ao clicar
            lstCadastrados.GridLines = true;        //Exibe as Linhas de grade no listview

            //Definindo as colunas do ListView
            lstCadastrados.Columns.Add("numeroCadastro", 100, HorizontalAlignment.Left); //Coluna de código
            lstCadastrados.Columns.Add("Nome Completo", 200, HorizontalAlignment.Left); //Coluna de Nome Completo
            lstCadastrados.Columns.Add("Nome Social", 200, HorizontalAlignment.Left); //Coluna de nome social
            lstCadastrados.Columns.Add("Data de Nascimento", 200, HorizontalAlignment.Left); //Coluna de e-mail
            lstCadastrados.Columns.Add("Cidade", 200, HorizontalAlignment.Left); //Coluna de CPF
            lstCadastrados.Columns.Add("Gênero", 200, HorizontalAlignment.Left);
           
        }

        private void PesquisarPorNome(string nome)
        {
          string query = @"SELECT * FROM dados 
                WHERE nomecompleto LIKE @termo 
                   OR nomesocial LIKE @termo
                   OR cidade LIKE @termo
                ORDER BY numerocadastro DESC";

            try
            {
                using (MySqlConnection conexao = new MySqlConnection(data_source))
                {
                    conexao.Open();

                    MySqlCommand cmd = new MySqlCommand(query, conexao);
                    cmd.Parameters.AddWithValue("@termo", "%" + nome + "%");

                    MySqlDataReader reader = cmd.ExecuteReader();

                    lstCadastrados.Items.Clear();

                    while (reader.Read())
                    {
                        string[] row =
                        {
                    reader["numerocadastro"].ToString(),
                    reader["nomecompleto"].ToString(),
                    reader["nomesocial"].ToString(),
                    Convert.ToDateTime(reader["datanascimento"]).ToString("dd/MM/yyyy"),
                    reader["cidade"].ToString(),
                    reader["genero"].ToString()
                };

                        lstCadastrados.Items.Add(new ListViewItem(row));
                    }
                }
            }
         
        

            catch (MySqlException ex)
            {
                //Trata erros relacionados ao MySQL
                MessageBox.Show("Erro " + ex.Number + " ocorreu: " + ex.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                //Trata outros tipos de erro * erros no backEnd do formulário
                MessageBox.Show("Ocorreu: " + ex.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

            }
            finally
            {
                //Garante que a conexão com o banco será fechada, mesmo se ocorrer erro
                if (Conexao != null && Conexao.State == ConnectionState.Open)
                {
                    Conexao.Close();

                }
            }



        }
        private void carregar_clientes()
        {
                string query = "SELECT * FROM dados ORDER BY numerocadastro DESC";

                try
                {
                    using (MySqlConnection conexao = new MySqlConnection(data_source))
                    {
                        conexao.Open();

                        MySqlCommand cmd = new MySqlCommand(query, conexao);
                        MySqlDataReader reader = cmd.ExecuteReader();

                        lstCadastrados.Items.Clear();

                        while (reader.Read())
                        {
                            string[] row =
                            {
                    reader["numerocadastro"].ToString(),
                    reader["nomecompleto"].ToString(),
                    reader["nomesocial"].ToString(),
                    Convert.ToDateTime(reader["datanascimento"]).ToString("dd/MM/yyyy"),
                    reader["cidade"].ToString(),
                    reader["genero"].ToString()
                };

                            lstCadastrados.Items.Add(new ListViewItem(row));
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao carregar clientes: {ex.Message}", "Erro",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            

        }



        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            // Validações (mantenha as que você já tem)

            if (btnCadastrar.Text == "Atualizar" && lstCadastrados.SelectedItems.Count > 0)
            {
                AtualizarCliente();
            }
            else
            {
                CadastrarNovoCliente();
            }
        }

        private void CadastrarNovoCliente()
        {
            // Mantenha sua implementação atual de cadastro
            // ...

            // Após cadastrar com sucesso:
            btnCadastrar.Text = "Cadastrar"; // Garante que o botão volte ao estado normal
        }

        private void AtualizarCliente()
        {
            if (lstCadastrados.SelectedItems.Count == 0) return;

            int codigo = Convert.ToInt32(lstCadastrados.SelectedItems[0].SubItems[0].Text);

            try
            {
                using (MySqlConnection conexao = new MySqlConnection(data_source))
                {
                    conexao.Open();

                    string query = @"UPDATE dados SET 
                           nomecompleto = @nomecompleto,
                           nomesocial = @nomesocial,
                           datanascimento = @datanascimento,
                           cidade = @cidade,
                           genero = @genero
                           WHERE numerocadastro = @codigo";

                    MySqlCommand cmd = new MySqlCommand(query, conexao);

                    // Adiciona parâmetros
                    cmd.Parameters.AddWithValue("@codigo", codigo);
                    cmd.Parameters.AddWithValue("@nomecompleto", txtNomeCompleto.Text.Trim());
                    cmd.Parameters.AddWithValue("@nomesocial", txtNomeSocial.Text.Trim());
                    cmd.Parameters.AddWithValue("@datanascimento", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@cidade", comboBoxCidade.Text.Trim());

                    string generoSelecionado = "Não selecionado";
                    if (rbFeminino.Checked) generoSelecionado = "Feminino";
                    else if (rbMasculino.Checked) generoSelecionado = "Masculino";
                    else if (rbNaoBinario.Checked) generoSelecionado = "Não Binário";

                    cmd.Parameters.AddWithValue("@genero", generoSelecionado);

                    int linhasAfetadas = cmd.ExecuteNonQuery();

                    if (linhasAfetadas > 0)
                    {
                        MessageBox.Show("Cliente atualizado com sucesso!", "Sucesso",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Atualiza a lista
                        carregar_clientes();

                        // Limpa os campos e volta o botão ao estado normal
                        LimparCampos();
                        btnCadastrar.Text = "Cadastrar";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar: {ex.Message}", "Erro",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimparCampos()
        {
            txtNumeroCadastro.Text = "";
            txtNomeCompleto.Text = "";
            txtNomeSocial.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            comboBoxCidade.SelectedIndex = -1;
            rbFeminino.Checked = false;
            rbMasculino.Checked = false;
            rbNaoBinario.Checked = false;
        }
        private void txtNomeCompleto_Click(object sender, EventArgs e)
        {
            if (txtNomeCompleto.Text == "Insira seu nome completo")
            {
                //"LIMPA TUTOOOOOO" -Pastor Metralhadora
                txtNomeCompleto.Text = "";
            }
        }

        private void LimpaNoClique(object sender, EventArgs e)
        {
            if (txtNumeroCadastro.Text == "Número Cadastro")
            {
                //"LIMPA TUTOOOOOO" -Pastor Metralhadora
                txtNumeroCadastro.Text = "";
            }
        }

        private void txtNomeSocial_Click(object sender, EventArgs e)
        {
            if (txtNomeSocial.Text == "Insira seu nome social")
            {
                //"LIMPA TUTOOOOOO" -Pastor Metralhadora
                txtNomeSocial.Text = "";
            }
        }

        private void MensagemDeErro(Control txt)
        {
            txt.BackColor = System.Drawing.Color.LightPink;
            MessageBox.Show("Por favor, preencha os dados em rosa", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtPesquisa.Text))
            {
                PesquisarPorNome(txtPesquisa.Text.Trim());
            }
            else
            {
                // Se estiver vazio, recarrega todos os registros
                carregar_clientes();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimparCampos();
            btnCadastrar.Text = "Cadastrar";
            lstCadastrados.SelectedItems.Clear();
        }

        private void lstCadastrados_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
           
                // Verifica se há algum item selecionado
                if (lstCadastrados.SelectedItems.Count == 0) return;

                try
                {
                    // Obtém o item selecionado
                    ListViewItem selectedItem = lstCadastrados.SelectedItems[0];

                    // Preenche os campos do formulário
                    txtNumeroCadastro.Text = selectedItem.SubItems[0].Text;
                    txtNomeCompleto.Text = selectedItem.SubItems[1].Text;
                    txtNomeSocial.Text = selectedItem.SubItems[2].Text;

                    // Converte a data do formato exibido (dd/MM/yyyy)
                    if (DateTime.TryParseExact(selectedItem.SubItems[3].Text, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dataNascimento))
                    {
                        dateTimePicker1.Value = dataNascimento;
                    }

                    // Preenche a cidade
                    comboBoxCidade.Text = selectedItem.SubItems[4].Text;

                    // Configura o gênero
                    string genero = selectedItem.SubItems[5].Text;
                    rbFeminino.Checked = genero.Contains("Feminino");
                    rbMasculino.Checked = genero.Contains("Masculino");
                    rbNaoBinario.Checked = genero.Contains("Não Binário");

                    // Muda o botão para modo de atualização
                    btnCadastrar.Text = "Atualizar";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao carregar dados: {ex.Message}", "Erro",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            
        }
    }

}
