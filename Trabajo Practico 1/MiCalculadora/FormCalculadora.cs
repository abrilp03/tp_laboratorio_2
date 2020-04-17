using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();

            this.Text = "Calculadora de Abril Palomres del curso 2°A";

            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            this.MaximizeBox = false;
            this.MinimizeBox = false;

            this.cmbOperador.Items.AddRange(new string[] {"+", "-", "*", "/"});
            //this.cmbOperador.SelectedItem = "+";
            //this.cmbOperador.DropDownStyle = ComboBoxStyle.DropDownList;

            this.Limpiar();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            string auxResultado = this.lblResultado.Text;
            this.lblResultado.Text = Numero.DecimalBinario(auxResultado);                        
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            string auxResultado = this.lblResultado.Text;
            this.lblResultado.Text = Numero.BinarioDecimal(auxResultado);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            string numero1 = txtNumero1.Text;
            string numero2 = txtNumero2.Text;
            string operador = (string)this.cmbOperador.SelectedItem;

            double resultado = Operar(numero1, numero2, operador);

            this.lblResultado.Text = resultado.ToString();
        }

        private void Limpiar()
        {
            foreach(Control control in this.Controls)
            {
                if(control is TextBox || control is ComboBox || control is Label)
                {
                    control.Text = "";
                }
            }

            //this.txtNumero1.Text = "";
            //this.txtNumero2.Text = "";
            //this.lblResultado.Text = "";
            //this.cmbOperador.Text = "";           this.cmbOperador.SelectedIndex = 0;
        }

        private static double Operar(string numero1, string numero2, string operador)
        {
            double resultado;
            Numero n1 = new Numero(numero1);
            Numero n2 = new Numero(numero2);

            resultado = Calculadora.Operar(n1, n2, operador);

            return resultado;
        }
    }
}
