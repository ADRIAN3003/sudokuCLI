using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace sudokuCLI
{
    class Program
    {
        static List<Feladvany> feladvanies = new List<Feladvany>();
        static int meret = 0;
        static Feladvany kivalasztott;
        static void Main(string[] args)
        {
            HarmadikFeladat();
            NegyedikFeladat();
            OtodikFeladat();
            HatodikFeladat();
            HetedikFeladat();
            NyolcadikFeladat();

            Console.ReadKey();
        }

        private static void NyolcadikFeladat()
        {
            using (StreamWriter sw = new StreamWriter("sudoku" + meret + ".txt"))
            {
                foreach (var item in feladvanies.FindAll(x => x.Meret == meret))
                {
                    sw.WriteLine(item.Kezdo);
                }

            }
            Console.WriteLine("\n8. feladat: sudoku" + meret + ".txt állomány " + feladvanies.Count(x => x.Meret == meret) + " darab feladvánnyal létrehozva");
        }

        private static void HetedikFeladat()
        {
            Console.WriteLine("\n7. feladat: A feladvány kirajzolva: ");
            kivalasztott.Kirajzol();
        }

        private static void HatodikFeladat()
        {
            Console.WriteLine("\n6. feladat: A feladvány kitöltöttsége: " + kivalasztott.Szazalek() + "%");
        }

        private static void OtodikFeladat()
        {
            Console.WriteLine("\n5. feladat: A kiválasztott feladavány:");
            Random rnd = new Random();

            kivalasztott = feladvanies.FindAll(x => x.Meret == meret)[rnd.Next(feladvanies.Count(y => y.Meret == meret))];
            Console.WriteLine(kivalasztott.Kezdo);
        }

        private static void NegyedikFeladat()
        {
            Console.Write("\n4. feladat: Kérem a feladvány méretét [4..9]: ");
            meret = Convert.ToInt32(Console.ReadLine());
            while (4 > meret || 9 < meret)
            {
                Console.Write("\n4. feladat: Kérem a feladvány méretét [4..9]: ");
                meret = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine(meret + "x" + meret + " méretű feladványból " + feladvanies.Count(x => x.Meret == meret) + " darab van tárolva");
        }

        private static void HarmadikFeladat()
        {
            using (StreamReader sr = new StreamReader("feladvanyok.txt"))
            {
                while (!sr.EndOfStream)
                {
                    feladvanies.Add(new Feladvany(sr.ReadLine()));
                }
            }
            Console.WriteLine("3. feladat: Beolvasva " + feladvanies.Count + " feladvány");
        }
    }
}
