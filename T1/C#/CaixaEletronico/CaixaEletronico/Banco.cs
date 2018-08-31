using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaixaEletronico
{
    class Banco
    {
        private contas[] contasBanco = new contas[10];

        private int quantidade;

        public void Adiciona(contas conta)
        {
            this.contasBanco[this.quantidade] = conta;
            quantidade++;

        }
    }
}
