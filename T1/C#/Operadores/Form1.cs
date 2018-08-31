using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Operadores
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
            int n = 15;

            //Programa
            for (int i = 3; i < 5; i++)
            {
                if (n%i==0)
                {
                    MessageBox.Show("O numero "+n+" é divisivel por "+i);
                }
                else
                {
                    MessageBox.Show("O numero " + n + " não é divisivel por " + i);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Programa
            for (int i = 0; i <= 30 ; i++)
            {
                if (i % 3 == 0 && i % 4 == 0)
                {
                    MessageBox.Show("O numero "+i+" é divisivel por 3 e por 4");
                }
                else if (i % 3 == 0)
                {
                    MessageBox.Show("O numero " + i + " é divisivel por 3");
                }
                else if(i % 4 == 0)
                {
                    MessageBox.Show("O numero " + i + " é divisivel por 4");
                }
                else
                {
                    MessageBox.Show("O numero "+ i +" não é divisivel nem por 3 nem por 4");
                }
            }
        }
    }
}
