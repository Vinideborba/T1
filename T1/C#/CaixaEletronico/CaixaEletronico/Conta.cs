using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaixaEletronico
{
    class contas
    {
        public int Numero { get; set; }
        public Cliente Titular { get; set; }
        public double Saldo { get; protected set; }
        

        public virtual void Deposita(double valorASerDepositado)
        {
            if (valorASerDepositado > 0)
            {
                this.Saldo += valorASerDepositado;
            }
        }

        public virtual bool Saca(double valorASerSacado)
        {
            if (valorASerSacado < 0)
            {
                throw new ArgumentException();
            }
            if (valorASerSacado > this.Saldo)
            {
                throw new SaldoInsuficienteException();
            }
            else
            {
                if (this.Titular.EhMaiorDeIdade())
                {
                    this.Saldo -= valorASerSacado;
                    return true;
                }
                else
                {
                    if (valorASerSacado <= 200)
                    {
                        this.Saldo -= valorASerSacado;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        public void Transfere(double valor, contas destino)
        {
            this.Saca(valor);
            destino.Deposita(valor);
        }

        public double CalculaRendimentoAnual()
        {
            double saldoNaqueleMes = this.Saldo;

            for (int i = 0; i < 12; i++)
            {
                saldoNaqueleMes = saldoNaqueleMes * 1.007;
            }

            double rendimento = saldoNaqueleMes - this.Saldo;

            return rendimento;
        }
    }
}
