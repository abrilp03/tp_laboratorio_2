using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
		private double _numero;

		public Numero()
		{
			this._numero = 0;
		}		

		public Numero(string strNumero)
		{
			this.SetNumero = strNumero;
		}

		public Numero(double numero) : this(numero.ToString())
		{

		}

		public string SetNumero
		{
			set { this._numero = ValidarNumero(value); }
		}

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

		public static double operator -(Numero n1, Numero n2)
		{
			double resultado;

			resultado = n1._numero - n2._numero;

			return resultado;
		}

		public static double operator +(Numero n1, Numero n2)
		{
			double resultado;

			resultado = n1._numero + n2._numero;

			return resultado;

		}

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

		public static double operator *(Numero n1, Numero n2)
		{
			double resultado;

			resultado = n1._numero * n2._numero;

			return resultado;
		}
	}
}
