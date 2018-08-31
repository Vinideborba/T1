using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Soma1A100SemMult3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Variaveis
            int soma = 0;

            //Codigo
            //Laço de repetição
            for (int i = 1; i < 101; i++)
            {
                if (i % 3 != 0)
                {
                    soma += i;
                }
            }

            //Mostrando o Resultado
            MessageBox.Show("O resultado da soma é " + soma);
        }
    }
}
