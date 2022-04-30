using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            bool nochmal = false;
            do
            {
                nochmal = false;
                bool größerAcht = false;
                string[] array = new string[9];
                Feldanfang(array);
                string zeichensieger = "";
                int i = 0;          //Player1 oder Player2  

                while (zeichensieger != "O" && zeichensieger != "X" && i < 9)    //zeichen ist X oder O wenn gewonnen
                {
                    Feld(array);
                    if (i % 2 == 0)
                    {
                        Console.Write("\nPlayer1");
                    }
                    else
                    {
                        Console.Write("\nPlayer2");

                    }
                    Console.WriteLine(" Feld eingeben");
                    int eingabe = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    größerAcht = FalscheEingabe(eingabe);   // Wenn Eingabe > 8
                    if (!größerAcht)
                    {
                        if (array[eingabe] == "O" || array[eingabe] == "X") // Spieler muss wieder wenn Feld schon gefüllt 
                        {
                            Console.WriteLine("Feld belegt");
                            i--;
                        }
                        if (array[eingabe] != "O" || array[eingabe] != "X")    // Wenn Feld voll ist dann überspringen
                        {
                            if (i % 2 == 0 && array[eingabe] != "X" && array[eingabe] != "O") // Player1
                            {
                                array[eingabe] = "X";
                            }
                            else if (array[eingabe] != "X" && array[eingabe] != "O")    // Player2
                            {
                                array[eingabe] = "O";
                            }
                            Console.WriteLine();
                            zeichensieger = Gewonnen(array);
                            i++;
                        }
                    }
                }

                Feld(array);
                if (zeichensieger == "X" || zeichensieger == "O")
                {
                    Sieger(zeichensieger);
                }
                else
                {
                    Console.WriteLine("\nUnentschieden");
                }
                nochmal = Neustart(nochmal);
                Console.Clear();
            } while (nochmal);
        }

        static void Feldanfang(string[] array)
        {
            for (int i = 0; i < 9; i++)
            {
                string j = Convert.ToString(i);
                array[i] = j;
            }
        }

        static void Feld(string[] array)
        {
            int b = 0;
            foreach (string a in array)
            {
                if (a == "O")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else if (a == "X")
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                Console.Write("\t\t" + a + "\t\t");
                Console.ForegroundColor = ConsoleColor.White;

                b++;
                if (b == 3 || b == 6)
                {
                    Console.WriteLine();
                    Console.Write("    ------------------------------------------------------------------------------------------------");
                    Console.WriteLine();
                }
                if (b != 3 && b != 6 && b != 9)
                {
                    Console.Write("|");
                }

            }
        }

        static string Gewonnen(string[] array)
        {
            string zeichen = "";

            for (int a = 0; a < 9; a += 3)
            {
                if (array[a] == array[a + 1] && array[a] == array[a + 2])    //Zeile
                {
                    zeichen = array[a];
                }
            }

            for (int b = 0; b < 3; b++)
            {
                if (array[b] == array[b + 3] && array[b] == array[b + 6])    //Spalte
                {
                    zeichen = array[b];
                }
            }

            if (array[0] == array[4] && array[0] == array[8])    //Kreuz
            {
                zeichen = array[0];
            }

            if (array[2] == array[4] && array[2] == array[6])    //Kreuz rück.
            {
                zeichen = array[2];
            }
            return zeichen;
        }

        static void Sieger(string zeichen)
        {
            if (zeichen == "X")
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\n\t\t\t\t      Spieler 1 hat gewonnen");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\t\t\t\t      Spieler 2 hat gewonnen");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        static bool FalscheEingabe(int eingabe)
        {
            if (eingabe > 8)
            {
                Console.WriteLine("Zahl zu groß");
                return true;
            }
            else
            {
                return false;
            }

        }
        static bool Neustart(bool nochmal)
        {
            bool falscheingabe = false;
            Console.WriteLine("Enter für Neustart\tEscape für Ende");
            ConsoleKeyInfo wiederholung;

            do
            {
                wiederholung = Console.ReadKey();
                if (wiederholung.Key == ConsoleKey.Enter)
                {
                    nochmal = true;
                    falscheingabe = false;
                }
                else if (wiederholung.Key == ConsoleKey.Escape)
                {
                    falscheingabe = false;
                }
                else
                {
                    falscheingabe = true;
                }
            } while (falscheingabe);

            return nochmal;
        }
    }
}
