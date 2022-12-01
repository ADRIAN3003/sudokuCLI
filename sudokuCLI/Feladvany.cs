using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudokuCLI
{
    class Feladvany
    {
        public string Kezdo { get; private set; }
        public int Meret { get; private set; }

        public Feladvany(string sor)
        {
            Kezdo = sor;
            Meret = Convert.ToInt32(Math.Sqrt(sor.Length));
        }

        public double Szazalek()
        {
            double szazalek = 0;
            for (int i = 0; i < Meret * Meret; i++)
            {
                if (Kezdo[i] != '0')
                {
                    szazalek++;
                }
            }

            if (szazalek != 0)
            {
                szazalek = (szazalek / (Meret * Meret)) * 100;
            }
            else
            {
                szazalek = 100;
            }

            return Math.Round(szazalek);
        }

        public void Kirajzol()
        {
            for (int i = 0; i < Kezdo.Length; i++)
            {
                if (Kezdo[i] == '0')
                {
                    Console.Write(".");
                }
                else
                {
                    Console.Write(Kezdo[i]);
                }
                if (i % Meret == Meret - 1)
                {
                    Console.WriteLine();
                }
            }
        }
    }

}
