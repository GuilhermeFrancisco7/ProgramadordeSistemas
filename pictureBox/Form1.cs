using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pictureBox
{
    public partial class frmPictureBox : Form
    {
        private string imagemLocalizada;
        public frmPictureBox()
        {
            InitializeComponent();
        }

        private void btnVerImagem_Click(object sender, EventArgs e)
        {
            pbCidade.Image = Image.FromFile(@"C:\Users\guilherme.falmeida7\Downloads\masp-sp.PNG");
            pbCidade.SizeMode = PictureBoxSizeMode.StretchImage;
        }
       
        private void btnAnexarImagem_MouseClick(object sender, MouseEventArgs e)
        {
           
            try
            {
                // Caixa de Diálogo para abrir arquivo
                OpenFileDialog abrirarquivo = new OpenFileDialog();
                abrirarquivo.Filter = "JPG files (*.jpg)|*.jpg| PNG files (*.png)|*.png|All files (*.*)|*.*";

                if (abrirarquivo.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    imagemLocalizada = abrirarquivo.FileName;
                    pbAnexarImagem.ImageLocation = imagemLocalizada;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ocorreu um erro!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
