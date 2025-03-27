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

namespace switch_case
{
    public partial class frmswitch : Form
    {
        public frmswitch()
        {
            InitializeComponent();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                var codigo = Convert.ToInt16(txtCodeInserido.Text);
                lblDescricao.Text = GetTipoCombustivel(codigo);
             
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha: " + ex.Message);
            }
        }

        private string GetTipoCombustivel(int codigo)
        {
            var result = "";
            switch(codigo)
            {
                case 1:
                  result = "Gasolina";
                break;

                case 2:
                    result = "Álcool";
                    break;

                case 3:
                    result = "Flex";
                    break;

                case 4:
                    result = "Gas GNV";
                    break;
                case 5:
                    result = "Diesel";
                    break;

                case 6:
                    result = "Eletriciade";
                    break;

               default:
                    result = "Inválido";
                    break;
            }
            return result;
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

namespace switch_case
{
    public partial class frmswitch : Form
    {
        public frmswitch()
        {
            InitializeComponent();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                var codigo = Convert.ToInt16(txtCodeInserido.Text);
                lblDescricao.Text = GetTipoCombustivel(codigo);
             
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha: " + ex.Message);
            }
        }

        private string GetTipoCombustivel(int codigo)
        {
            var result = "";
            switch(codigo)
            {
                case 1:
                  result = "Gasolina";
                break;

                case 2:
                    result = "Álcool";
                    break;

                case 3:
                    result = "Flex";
                    break;

                case 4:
                    result = "Gas GNV";
                    break;
                case 5:
                    result = "Diesel";
                    break;

                case 6:
                    result = "Eletriciade";
                    break;

               default:
                    result = "Inválido";
                    break;
            }
            return result;
        }
    }
}
>>>>>>> 8ab9e490f65f4e62dfc222416cb72ba809ecc8cd
