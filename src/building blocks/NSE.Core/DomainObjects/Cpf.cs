using NSE.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSE.Core.DomainObjects
{
    public class Cpf
    {
        public const int CpfMaxLength = 11;
        public string Numero { get; private set; }

        protected Cpf() { }
        public Cpf(string numero)
        {
            if (!Validar(numero)) throw new DomainException("CPF inválido");
            Numero = numero;
        }

        public static bool Validar(string cpf)
        {
            cpf = cpf.ApenasNumeros(cpf);

            if (cpf.Length > CpfMaxLength)
            {
                return false;
            }

            int[] sequenciaCpf = cpf.Select(c => c - '0').ToArray();

            var primeiroDigitoVerificador = PrimeiroDigitoVerificador(sequenciaCpf);

            if (primeiroDigitoVerificador != sequenciaCpf[9])
            {
                return false;
            }

            var segundoDigitoVerificador = SegundoDigitoVerificador(sequenciaCpf);

            if (segundoDigitoVerificador != sequenciaCpf[10])
            {
                return false;
            }

            return true;
        }

        private static int PrimeiroDigitoVerificador(int[] cpf)
        {
            int[] sequencia = { 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var primeiroDigitoVerificador = calculoDigitoVerificador(sequencia, cpf);

            return primeiroDigitoVerificador;
        }

        private static int SegundoDigitoVerificador(int[] cpf)
        {
            int[] sequencia = { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
            var primeiroDigitoVerificador = calculoDigitoVerificador(sequencia, cpf);

            return primeiroDigitoVerificador;
        }

        private static int calculoDigitoVerificador(int[] sequencia, int[] cpf)
        {
            var digitoVerificador = 0;

            for (var i = 0; i <= sequencia.Length; i++)
            {
                digitoVerificador += cpf[i] * sequencia[i];
            }

            var resto = (int)digitoVerificador % 11;

            if (digitoVerificador < 2)
            {
                digitoVerificador = 0;
            }
            else
            {
                digitoVerificador = 11 - resto;
            }

            return digitoVerificador;
        }


    }
}
