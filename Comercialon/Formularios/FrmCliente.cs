using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Comercialon.Classes;

namespace Comercialon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {   // A linha abaixo remove pontos e traços do cpf
            mskCpf.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente(
               txtNome.Text,
               mskCpf.Text,
               txtEmail.Text,
               txtTelefone.Text
           );
            cliente.Inserir();
            Endereco endereco = new Endereco
                (txtLogradouro.Text, txtNumero.Text, txtComplemento.Text
                , txtCep.Text, txtBairro.Text, txtCidade.Text, cmdTipo.Text,
                txtEstado.Text, txtUf.Text );
            MessageBox.Show("Cliente " + cliente.Id + " inserido.");
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            string email = txtEmail.Text;

            Regex rg = new Regex(@"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");

            if (rg.IsMatch(email))
            {
                btnInserir.Enabled = true;
            }
            else
            {
                btnInserir.Enabled = false;
            }
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void txtCpf_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void txtCep_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
