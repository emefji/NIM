using System;
using System.Collections.Generic;

namespace NIM {
    class Program {

        // Om spelet crashar för att listan tagit slut har någon vunnit
        // Fixa buggen med att spelet fortsätter när man 0 pinnar kvar

        static void Main(string[] args) {
            //true = p1 & false = p2
            
            List<int> pinnar = new List<int>();
            for (int i = 0; i < 15; i++) {
                pinnar.Add(1);
            }

            Play(pinnar);
        }

        static void Check(List<int> pinnar, bool turn) {

            // Player 2
            if (turn == true && pinnar.Count == 1) {
                Console.WriteLine("Spelare 1 vinner");
                System.Environment.Exit(0);
            }

            //Player 1
            else if (turn == false && pinnar.Count == 1) {
                Console.WriteLine("Spelare 2 vinner");
                System.Environment.Exit(0);
            }
        }

        static void Play(List<int> pinnar) {
            bool turn = true;

            if (turn == true) {
                Console.WriteLine("Spelare 1s tur");
                var p1 = Console.ReadLine();
                int p1Int = Int32.Parse(p1);
                
                if (p1Int > 3 || p1Int < 1) {
                    Console.WriteLine("välj ett nummer mellan 1-3");
                    return;
                }
                
                try {
                    pinnar.RemoveRange(0, p1Int);
                }

                catch {
                    if (p1Int > pinnar.Count) {
                        Console.WriteLine("kan inte ta bort " + p1Int + " pinnar");
                    }
                }

                Console.WriteLine(pinnar.Count + " antal pinnar kvar");
                Check(pinnar, turn);
                turn = false;
            }

            if (turn == false) {
                Console.WriteLine("Spelare 2s tur");
                var p2 = Console.ReadLine();
                int p2Int = Int32.Parse(p2);
                if (p2Int > 3 || p2Int < 1) {
                    Console.WriteLine("välj ett nummer mellan 1-3");
                    return;
                }
                try {
                    pinnar.RemoveRange(0, p2Int);
                }
                catch {
                    if (p2Int > pinnar.Count) {
                        Console.WriteLine("kan inte ta bort " + p2Int + "pinnar");
                    }
                }
                Console.WriteLine(pinnar.Count + " antal pinnar kvar");
                Check(pinnar, turn);
                Play(pinnar);
            }
        }

        // Koppla in om du vill
        // talet som funktionen skickar tillbaka är hur många pinnar vi vill ta bort
        int makeAIMove(List<int> pinnar) {
            if (pinnar.Count % 3 != 1) {
                return 4 - pinnar.Count % 3;
            }
            else {
                return 1;
            }
        }
    }
}