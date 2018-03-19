using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaixaEletronico
{
    class ContaInvestimento : Conta, ITributavel
    {
        public double CalculaTributo()
        {
            return this.Saldo * 0.03;
        }

        public override bool Saca(double valor)
        {
            if (valor < 0)
            {
                throw new ArgumentException();
            }
            else if (valor > this.Saldo)
            {
                throw new SaldoInsuficienteException();
            }
            else
            {
                this.Saldo -= valor;
                return true;
            }
        }
    }
}
