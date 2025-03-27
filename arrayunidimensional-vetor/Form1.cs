<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace arrayunidimensional_vetor
{
    public partial class frmVetor : Form
    {
        public frmVetor()
        {
            InitializeComponent();
        }

        private void btnTestar_Click(object sender, EventArgs e)
        {
            // matriz de uma dimensão, também chamda de vetor.
            string[] pecasComputador = { "Mouse", "Teclado", "Monitor", "Gabinete", "Câmera" };

           // MessageBox.Show(pecasComputador[2]); para mostrar no array pecasComputador o elemento 3 (monitor) na posição [2]

            foreach(string peca in pecasComputador)
            {
                MessageBox.Show(peca);
            }
        }
    }
}
=======
﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace arrayunidimensional_vetor
{
    public partial class frmVetor : Form
    {
        public frmVetor()
        {
            InitializeComponent();
        }

        private void btnTestar_Click(object sender, EventArgs e)
        {
            // matriz de uma dimensão, também chamda de vetor.
            string[] pecasComputador = { "Mouse", "Teclado", "Monitor", "Gabinete", "Câmera" };

           // MessageBox.Show(pecasComputador[2]); para mostrar no array pecasComputador o elemento 3 (monitor) na posição [2]

            foreach(string peca in pecasComputador)
            {
                MessageBox.Show(peca);
            }
        }
    }
}
>>>>>>> 8ab9e490f65f4e62dfc222416cb72ba809ecc8cd
