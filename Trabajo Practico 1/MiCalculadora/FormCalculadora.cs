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
        #region Constructor
        /// <summary>
        /// Constructor del form que inicializa el combo Box y estiliza la ventana segun lo pedido
        /// </summary>
        public FormCalculadora()
        {
            InitializeComponent();

            this.Text = "Calculadora de Abril Palomres del curso 2°A";

            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            this.MaximizeBox = false;
            this.MinimizeBox = false;

            this.cmbOperador.Items.AddRange(new string[] {"+", "-", "*", "/"});

            this.Limpiar();
        }
        #endregion

        #region Evento Click
        /// <summary>
        /// Cierra el programa al hacerle click llamando al método "Form.Close()"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Convierte un valor decimal a binario llamando al método "DecimalBinario" de la clase "Numero"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = Numero.DecimalBinario(lblResultado.Text);                        
        }

        /// <summary>
        /// Convierte un numero binario a decimal llamando al método "BinarioDecimal" de la clase "Numero"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = Numero.BinarioDecimal(lblResultado.Text);
        }

        /// <summary>
        /// Llama por el evento click al método "FormCalculadora.Limpiar()"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        /// <summary>
        /// Al hacer click, realiza la operacion indicada entre dos numeros
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            string numero1 = txtNumero1.Text;
            string numero2 = txtNumero2.Text;
            string operador = (string)this.cmbOperador.SelectedItem;

            double resultado = Operar(numero1, numero2, operador);

            this.lblResultado.Text = resultado.ToString();
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Método que borra los datos en todos los TextBox, ComboBox y Label
        /// </summary>
        private void Limpiar()
        {
            foreach(Control control in this.Controls)
            {
                if(control is TextBox || control is ComboBox || control is Label)
                {
                    control.Text = "";
                }
            }
        }

        /// <summary>
        /// Método que llama al método statico Operar de la clase Calculadora donde
        /// realiza la operacion asignada entre 
        /// el numero1 (Inicializado con la Clase Numero) y
        /// el numero2 (Inicializado con la Clase Numero)
        /// </summary>
        /// <param name="numero1">Numero 1 recibido del Textbox</param>
        /// <param name="numero2">Numero 2 recibido del Textbox</param>
        /// <param name="operador">Operador recibido del Combo Box</param>
        /// <returns>Resultado de la operación entre numero1 y numero 2</returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            double resultado;
            Numero n1 = new Numero(numero1);
            Numero n2 = new Numero(numero2);

            resultado = Calculadora.Operar(n1, n2, operador);

            return resultado;
        }
        #endregion
    }
}
