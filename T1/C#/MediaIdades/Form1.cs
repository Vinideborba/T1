using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaIdades
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
                int idadeAmigo1 = 25;
                int idadeAmigo2 = 32;
                int idadeAmigo3 = 54;

                double media = (idadeAmigo1 + idadeAmigo2 + idadeAmigo3) / 3;
                MessageBox.Show("A média das idades é: " + media);
            
        }
    }
}
