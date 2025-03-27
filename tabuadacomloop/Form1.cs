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

namespace tabuadacomloop
{
    public partial class frmtabuadaloop : Form
    {
        public frmtabuadaloop()
        {
            InitializeComponent();
        }

        private void btnExecutarTabuada_Click(object sender, EventArgs e)
        {
            // limpar a lista antes de adicionar novos resultados
            lstTabuada.Items.Clear(); 

            int numeroInserido = Convert.ToInt32(txtNumero.Text);
            // Adicionando a Tabuada para o número inserido.
            for(int i = 1; i <11; i++)
            {
                lstTabuada.Items.Add(numeroInserido + "x" + i + "=" + (numeroInserido * i));
               
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

namespace tabuadacomloop
{
    public partial class frmtabuadaloop : Form
    {
        public frmtabuadaloop()
        {
            InitializeComponent();
        }

        private void btnExecutarTabuada_Click(object sender, EventArgs e)
        {
            // limpar a lista antes de adicionar novos resultados
            lstTabuada.Items.Clear(); 

            int numeroInserido = Convert.ToInt32(txtNumero.Text);
            // Adicionando a Tabuada para o número inserido.
            for(int i = 1; i <11; i++)
            {
                lstTabuada.Items.Add(numeroInserido + "x" + i + "=" + (numeroInserido * i));
               
            }
            
        }
    }
}
>>>>>>> 8ab9e490f65f4e62dfc222416cb72ba809ecc8cd
