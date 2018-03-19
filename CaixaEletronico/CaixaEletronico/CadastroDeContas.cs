using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaixaEletronico
{
    public partial class CadastroDeContas : Form
    {
        private Form1 aplicacaoPrincipal;
        public CadastroDeContas(Form1 aplicacaoPrincipal)
        {
            this.aplicacaoPrincipal = aplicacaoPrincipal;
            InitializeComponent();
        }

        public CadastroDeContas()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e) { }

        private void button1_Click(object sender, EventArgs e)
        {
            string titular = titularConta.Text;
            int numero = Convert.ToInt32(numeroConta.Text);
            Cliente cliente = new Cliente("Bruno");

            Conta conta = new ContaCorrente()
            {
                Numero = numero, Nome = titular
            };
            this.aplicacaoPrincipal.AdicionaConta(conta);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var contas = new HashSet<Conta>();

            var c1 = new ContaCorrente()
            {
                Nome = "Mauricio"
            };

            contas.Add(c1);
            contas.Add(c1);

            foreach (var c in contas)
            {
                MessageBox.Show(c.Nome);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //string titulo = "Arquitetura e" + " Design de Software";
            //titulo += "!";

            //int idade = 42;
            //string nome = "Guilherme";
            //string mensagem = string.Format("Olá {0}, a sua idade é: {1}", nome, idade);

            //MessageBox.Show(titulo);
            //MessageBox.Show(mensagem);

            //string texto = "Guilherme,42,sao paulo,brasil";
            //string[] partes = texto.Split(',');
            //foreach(var parte in partes)
            //{
            //    MessageBox.Show(parte);
            //}

            //string curso = "fn11";
            //curso = curso.ToUpper().Replace("1", "2");
            //MessageBox.Show(curso);

            string nomeCompleto = "guilherme silveira";
            int posicaoDoS = nomeCompleto.IndexOf("s");
            string primeiroNome = nomeCompleto.Substring(posicaoDoS);
            //string primeiroNome = nomeCompleto.Substring(0, 9);
            MessageBox.Show(primeiroNome);
        }

        private void CadastroDeContas_Load(object sender, EventArgs e)
        {
            if (File.Exists("entrada.txt"))
            {
                Stream entrada = File.Open("entrada.txt", FileMode.Open);
                StreamReader leitor = new StreamReader(entrada);
                string linha = leitor.ReadLine();

                while (linha != null)
                {
                    texto.Text += linha;
                    linha = leitor.ReadLine();
                }
                leitor.Close();
                entrada.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Stream saida = File.Open("entrada.txt", FileMode.Create);
            StreamWriter escritor = new StreamWriter(saida);
            escritor.Write(texto.Text);

            escritor.Close();
            saida.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var contas = new List<Conta>();
            var conta1 = new ContaCorrente(2300);
            var conta2 = new ContaCorrente(1000);
            var conta3 = new ContaCorrente(2500);
            contas.Add(conta1);
            contas.Add(conta2);
            contas.Add(conta3);

            var filtradas = from c in contas        //LINQ
                            where c.Saldo > 2000
                            select c;

            double saldoTotal = filtradas.Sum(c => c.Saldo);    //Lambda
            MessageBox.Show("O total é: " + saldoTotal);

        }
    }
}
