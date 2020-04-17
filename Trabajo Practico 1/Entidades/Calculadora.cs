using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
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

    }
}
