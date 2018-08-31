using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaixaEletronico
{
    public partial class Form1 : Form
    {
        contas[] contas;
        contas conta = new contas();
        Cliente cliente = new Cliente();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            contas = new contas[2];
            contas contaDoVictor = new contas
            {
                Titular = new Cliente("Victor"),
                Numero = 1
            };

            contas contaDoMario = new contas
            {
                Titular = new Cliente("Mario"),
                Numero = 2
            };

            this.contas = new contas[2];
            this.contas[0] = contaDoVictor;
            this.contas[1] = contaDoMario;

            

            for (int i = 0; i < 2; i++)
            {
                comboContas.Items.Add(contas[i].Titular);
            }

            foreach (contas Nome in contas)
            {
                comboTransferencia.Items.Add(Nome);
            }

            this.MostraConta();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            string textoDoValorDoDeposito = textoValor.Text;
            double valorDeposito = Convert.ToDouble(textoDoValorDoDeposito);
            this.conta.Deposita(valorDeposito);

            this.MostraConta();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string textoDoValorDoSaque = textoValor.Text;
            double valorSaque = Convert.ToDouble(textoDoValorDoSaque);
            try
            {
                this.conta.Saca(valorSaque);
                MessageBox.Show("Dinheiro Liberado");
            }
            catch(SaldoInsuficienteException)
            {
                MessageBox.Show("Saldo insuficiente");
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Valor negativo");
            }
            this.MostraConta();
        }

        private void MostraConta()
        {
            if (conta.Titular == null)
            {
                conta.Titular = new Cliente();
            }
            else
            {
                textoTitular.Text = conta.Titular.Nome;
                textoSaldo.Text = Convert.ToString(conta.Saldo);
                textoNumero.Text = Convert.ToString(conta.Numero);
            }
        }

        private void comboContas_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indiceSelecionado = comboContas.SelectedIndex;
            contas contaSelecionada = contas[indiceSelecionado];
            textoTitular.Text = Convert.ToString(contaSelecionada.Titular);
            textoSaldo.Text = Convert.ToString(contaSelecionada.Saldo);
            textoNumero.Text = Convert.ToString(contaSelecionada.Numero);
        }



        public void comboTransferencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indice = comboTransferencia.SelectedIndex;
            contas contaSelecionada = contas[indice];
        }

        private void buttonTransfere_Click(object sender, EventArgs e)
        {
            int indice = comboTransferencia.SelectedIndex;
            contas contaSelecionada = contas[indice];

            string textoTransferencia = textoValor.Text;
            double valorTransferencia = Convert.ToDouble(textoTransferencia);
            this.conta.Transfere(valorTransferencia, contaSelecionada);

            this.MostraConta();
        }
    }

    public void AdicionaConta(contas conta)
    {
        this.contas[this.quantidadeDeContas] = conta;
        this.quantidadeDeContas++;
        comboContas.Items.Add(conta);
    }
}