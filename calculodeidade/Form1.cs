using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculodeidade
{
    public partial class frmcalculodeidade : Form
    {
        public frmcalculodeidade()
        {
            InitializeComponent();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            int anosnascimento, anoatual, idade;

            anosnascimento = int.Parse(txtAnoNasc.Text);

            anoatual = int.Parse(txtAnoAtual.Text);

            idade = anoatual - anosnascimento;

            lblIdade.Text = idade.ToString(); 

        }
    }
}
