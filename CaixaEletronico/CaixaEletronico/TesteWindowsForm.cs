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
    public partial class TesteWindowsForm : Form
    {
        public TesteWindowsForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var contas = new List<Conta>();
            var c1 = new ContaCorrente();
            c1.Nome = "Mauricio";
            contas.Add(c1);

            Conta copiaC1 = contas[0];

            var c2 = new ContaCorrente();
            c2.Nome = "Victor";

            MessageBox.Show("Esta lá: " + contas.Contains(c1));
            MessageBox.Show("Esta lá: " + contas.Contains(c2));

        }
    }
}
