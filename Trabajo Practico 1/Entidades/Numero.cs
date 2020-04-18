using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        #region Atributo, Constructores y Propiedad
        /// <summary>
        /// Atributo privado de la clase Numero
        /// </summary>
        private double _numero;

		/// <summary>
		/// Constructor por defecto que inicializa el atributo privado en 0
		/// </summary>
		public Numero()
		{
			this._numero = 0;
		}		

		/// <summary>
		/// Contructor con que recibe un string que inicializa el atributo privado por la propiedad SetNumero
		/// </summary>
		/// <param name="strNumero">parametro de tipo string</param>
		public Numero(string strNumero)
		{
			this.SetNumero = strNumero;
		}

		/// <summary>
		/// Constructor con parametro de tipo double que incializa el atributo privado llamando 
		/// a otro constructor por medio del parseo
		/// </summary>
		/// <param name="numero">parametro de tipo double que es parseadp a string</param>
		public Numero(double numero) : this(numero.ToString())
		{

		}

		/// <summary>
		/// Propiedad que recibe un string y lo valida a un numero llamando al método "ValidarNumero"
		/// </summary>
		public string SetNumero
		{
			set { this._numero = ValidarNumero(value); }
		}
        #endregion

        #region Metodos
        /// <summary>
        /// Metodo privado que intenta parsear un string a double en caso de ser posible
        /// </summary>
        /// <param name="strNumero">parametro de tipo string que ingresa</param>
        /// <returns>Retorna un double en caso de poder pasearlo o retorna 0 en caso de que no</returns>
        private double ValidarNumero(string strNumero)
		{
			double retorno;

			if(double.TryParse(strNumero, out double auxNumero))
			{
				retorno = auxNumero;
			}
			else
			{
				retorno = 0;
			}

			return retorno;
		}

		/// <summary>
		/// Método que toma un string y en caso de ser binario lo convierte a decimal
		/// </summary>
		/// <param name="binario">parametro de tipo string</param>
		/// <returns>Retorna un numero decimal si recibio un binario. Caso contrario, retorna "Valor Inválido"</returns>
		public static string BinarioDecimal(string binario)
		{
			double resultado = 0;
			bool esBinario = true;
			double[] auxBinario = new double[binario.Length];
			string strBinario;

			for(int i = 0; i < binario.Length; i++)
			{
				auxBinario[i] = char.GetNumericValue(binario[i]);

				if(auxBinario[i] != 1 && auxBinario[i] != 0)
				{
					esBinario = false;
					break;
				}
			}

			if(esBinario == false)
			{
				strBinario = "Valor Inválido";
			}
			else
			{
				for(int i = 0; i <binario.Length; i++)
				{
					resultado += auxBinario[i] * Math.Pow(2, binario.Length - i - 1);
				}

				strBinario = resultado.ToString();
			}

			return strBinario;
		}

		/// <summary>
		/// Metodo que recibe un double y, en caso de ser posible, lo transforma a binario
		/// </summary>
		/// <param name="numero">parametro de tipo double</param>
		/// <returns>Retorna un string con el residuo de la division, es decir el binario</returns>
		public static string DecimalBinario(double numero)
		{
			string strNumero = "";
			int intNumero = (int)numero;

			while(intNumero > 0)
			{
				strNumero = (intNumero % 2).ToString() + strNumero;
				intNumero /= 2;
			}

			return strNumero;
		}

		/// <summary>
		/// Método que recibe por parametro un string e intenta parsearlo para llamar a su sobrecarga
		/// </summary>
		/// <param name="numero">parametro de tipo string</param>
		/// <returns>Retorna un string con el numero binario o retorna "valor inválido"</returns>
		public static string DecimalBinario(string numero)
		{
			string strBinario;

			if (double.TryParse(numero, out double resultado))
			{
				strBinario = DecimalBinario(resultado);
			}
			else
			{
				strBinario = "Valor Inválido";
			}

			return strBinario;
		}
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Sobrecarga de operador menos que realiza la cuenta entre dos numeros de la clase Numero
        /// </summary>
        /// <param name="n1">parametro 1 de la clase Numero</param>
        /// <param name="n2">parametro 2 de la clase Numero</param>
        /// <returns>Retorna el resultado de la resta entre n1 y n2</returns>
        public static double operator -(Numero n1, Numero n2)
		{
			double resultado;

			resultado = n1._numero - n2._numero;

			return resultado;
		}

		/// <summary>
		/// Sobrecarga de operador más que realiza la cuenta entre dos numeros de la clase Numero
		/// </summary>
		/// <param name="n1">parametro 1 de la clase Numero</param>
		/// <param name="n2">parametro 2 de la clase Numero</param>
		/// <returns>Retorna el resultado de la suma entre n1 y n2</returns>
		public static double operator +(Numero n1, Numero n2)
		{
			double resultado;

			resultado = n1._numero + n2._numero;

			return resultado;

		}

		/// <summary>
		/// Sobrecarga de operador division que realiza la cuenta entre dos numeros de la clase Numero
		/// </summary>
		/// <param name="n1">parametro 1 de la clase Numero</param>
		/// <param name="n2">parametro 2 de la clase Numero</param>
		/// <returns>Retorna el resultado de la division entre n1 y n2</returns>
		public static double operator /(Numero n1, Numero n2)
		{
			double resultado;

			if(n2._numero == 0)
			{
				resultado = double.MinValue;
			}
			else
			{
				resultado = n1._numero / n2._numero;
			}					

			return resultado;

		}

		/// <summary>
		/// Sobrecarga de operador multiplicar que realiza la cuenta entre dos numeros de la clase Numero
		/// </summary>
		/// <param name="n1">parametro 1 de la clase Numero</param>
		/// <param name="n2">parametro 2 de la clase Numero</param>
		/// <returns>Retorna el resultado de la multiplicación entre n1 y n2</returns>
		public static double operator *(Numero n1, Numero n2)
		{
			double resultado;

			resultado = n1._numero * n2._numero;

			return resultado;
		}
        #endregion
    }
}
