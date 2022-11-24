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
            int[] primeiraSequencia = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            var primeiroDigitoVerificador = calculoDigitoVerificador(primeiraSequencia, cpf);

            return primeiroDigitoVerificador;
        }

        private static int SegundoDigitoVerificador(int[] cpf)
        {
            int[] segundaSequencia = { 11,10, 9, 8, 7, 6, 5, 4, 3, 2 };
            var primeiroDigitoVerificador = calculoDigitoVerificador(segundaSequencia, cpf);

            return primeiroDigitoVerificador;
        }

        private static int calculoDigitoVerificador(int[] sequenciaCalculo, int[] cpf)
        {
            var digitoVerificador = 0;

            for (var i = 0; i < sequenciaCalculo.Length; i++)
            {
                digitoVerificador += cpf[i] * sequenciaCalculo[i];
            }

            var resto = digitoVerificador % 11;

            if (resto < 2)
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
