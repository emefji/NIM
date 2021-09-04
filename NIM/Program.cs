using System;
using System.Collections.Generic;

namespace NIM {
    class Program {

        // Om spelet crashar för att listan tagit slut har någon vunnit
        // Fixa buggen med att spelet fortsätter när man 0 pinnar kvar

        // code-repeti

        static void Main(string[] args) {
            int pinnar = 20;
            
            Play(pinnar);
        }

        static bool Check(int pinnar, bool turn) {

            // Player 2
            if (turn == true && pinnar == 1) {
                Console.WriteLine("Spelare 1 vinner");
                //System.Environment.Exit(0);
                return false;
            }

            //Player 1
            else if (turn == false && pinnar == 1) {
                Console.WriteLine("Spelare 2 vinner");
                //System.Environment.Exit(0);
                return false;
            }

            return true;
        }

        static void Play(int pinnar) {
            bool next = true;
            bool turn = true;

            while (next == true) {
                pinnar = Play2(turn, pinnar);

                next = Check(pinnar, turn);
                turn = !turn;
            }
        }

        static int Play2(bool turn, int pinnar) {
            if(turn == true) {
                Console.WriteLine("Spelare 1s tur");
            }
            else {
                Console.WriteLine("Spelare 2s tur");
            }


            var p1 = Console.ReadLine();
            int p1Int = Int32.Parse(p1);

            if (p1Int > 3 || p1Int < 1) {
                Console.WriteLine("välj ett nummer mellan 1-3");
                throw new Exception("Kan bara hantera 1-3");
            }

            if (p1Int > pinnar) {
                Console.WriteLine("kan inte ta bort " + p1Int + " pinnar");
                throw new Exception("Någon spelare tog bort för många pinnar");
            }

            pinnar = pinnar - p1Int;

            Console.WriteLine(pinnar + " antal pinnar kvar");

            return pinnar;  
        }
    }
}