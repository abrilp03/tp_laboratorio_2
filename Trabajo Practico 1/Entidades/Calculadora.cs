using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        #region Metodos
        /// <summary>
        /// Valida que el string ingresado sea "+", "-", "/" o "*", caso contrario devuelve "+" 
        /// </summary>
        /// <param name="operador">parametro de tipo string</param>
        /// <returns>Retorna el string validado como operador</returns>
        private static string ValidarOperador(string operador)
        {
            string auxOperador;

            if(operador == "+" || operador == "-" || operador == "/" || operador == "*")
            {
                auxOperador = operador;    
            }
            else
            {
                auxOperador = "+";
            }

            return auxOperador;
        }

        /// <summary>
        /// Realiza la operacion indicada entre dos numeros de tipo clase Numero
        /// </summary>
        /// <param name="num1">Numero 1 de la clase Numero</param>
        /// <param name="num2">Numero 2 de la clase Numero</param>
        /// <param name="operador">parametro de tipo string</param>
        /// <returns>Retorna un numero resultado de la operacion</returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double resultado = 0;
            string operadorValidado = ValidarOperador(operador);

            switch(operadorValidado)
            {
                case "+":
                    resultado = num1 + num2;
                    break;

                case "-":
                    resultado = num1 - num2;
                    break;

                case "*":
                    resultado = num1 * num2;
                    break;

                case "/":
                    resultado = num1 / num2;
                    break;

                default:
                    //Rompe
                    break;
            }

            return resultado;
        }
        #endregion
    }
}
