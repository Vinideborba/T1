using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaixaEletronico
{

    class ContaPoupanca : contas, Itributavel
    {
        private static int totalDeContas = 0;
        public ContaPoupanca()
    {
            ContaPoupanca.totalDeContas++;
    }
    public int ProximaConta()
    {
        return ContaPoupanca.totalDeContas + 1;
    }

    public override void Deposita(double valorASerDepositado)
        {
            if (valorASerDepositado > 0 )
            {
                this.Saldo += valorASerDepositado - 0.1;
            }
            base.Deposita(valorASerDepositado);
        }

        public double CalculaTributos()
        {
            return this.Saldo * 0.02;
        }
    }
}
