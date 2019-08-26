using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

namespace Ex07Roulette
{
    public class UI
    {

        public int money;
        string playerName;
        public int spins;
        static string leftStart = "\t\t\t";

        public UI(int money, string playerName, int spins)
        {
            this.money = money;
            this.playerName = playerName;
            this.spins = spins;
        }

        public void printUI()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            string menu = $"Wallet: ${money}    |    {playerName}    |    Total Spins: {spins}";
            Console.SetCursorPosition((Console.WindowWidth - menu.Length) / 2, 2);
            Console.WriteLine(menu);
            Console.ForegroundColor = ConsoleColor.Magenta;

        }

        public void printBoard()
        {
            string start = "\t\t\t\t\t\t\t\t\t\t\t\t";
            string greenBackground = $"{start}|                                |";
            Console.ForegroundColor = ConsoleColor.White;

            string zeros = $"{start}\t    0\t   00";

            List<string> redNums = new List<string>()
            {
                $"{start}\t01\t\t03",
                $"{start}\t\t05\t",
                $"{start}\t07\t\t09",
                $"{start}\t\t\t12",
                $"{start}\t\t14\t",
                $"{start}\t16\t\t18",
                $"{start}\t19\t\t21",
                $"{start}\t\t23\t",
                $"{start}\t25\t\t27",
                $"{start}\t\t\t30",
                $"{start}\t\t32\t",
                $"{start}\t34\t\t36"
            };
            List<string> blackNums = new List<string>()
            {
                $"{start}\t\t02\t",
                $"{start}\t04\t\t06",
                $"{start}\t\t08\t",
                $"{start}\t10\t11\t",
                $"{start}\t13\t\t15",
                $"{start}\t\t17\t",
                $"{start}\t\t20\t",
                $"{start}\t22\t\t24",
                $"{start}\t\t26\t",
                $"{start}\t28\t29\t",
                $"{start}\t31\t\t33",
                $"{start}\t\t35\t"
            };

            Console.SetCursorPosition(0, 12);
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            for (int i = 0; i < 29; i++)
            {
                Console.WriteLine(greenBackground);
            }

            Console.SetCursorPosition(0, 13);
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(zeros);

            Console.SetCursorPosition(0, 15);
            Console.BackgroundColor = ConsoleColor.Red;
            foreach (string num in redNums)
            {
                Console.WriteLine(num);
                Console.WriteLine();
            }

            Console.SetCursorPosition(0, 15);
            Console.BackgroundColor = ConsoleColor.Black;
            foreach (string num in blackNums)
            {
                Console.WriteLine(num);
                Console.WriteLine();
            }
        }

        public (int, string) spinWheelAnimation(Wheel wheel, Random rand)
        {
            string[] spins = { "Spinning       ", "SPinning.      ", "SPInning..     ", "SPINning...    ", "SPINNing....   ", "SPINNIng.....  ", "SPINNINg...... ", "SPINNING......." };
            for (int i = 0; i < 5; i++)
            {
                foreach (var spin in spins)
                {
                    Console.SetCursorPosition((Console.BufferWidth - 8) / 2, 5);
                    Thread.Sleep(100);
                    Console.Write(spin);
                }
            }
            string color;
            string number;

            int result = wheel.Spin(rand);
            if (result == 37)
            {
                color = "Green";
                number = "00";
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if(result == 0)
            {
                color = "Green";
                number = "0";
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (wheel.wheel[result] == 'R')
            {
                color = "Red";
                number = result.ToString();
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                color = "Black";
                number = result.ToString();
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
            }


            string resultMessage = $"      --->{color} {number}<---      ";
            Console.SetCursorPosition((Console.BufferWidth - resultMessage.Length) / 2, 5);
            Console.WriteLine(resultMessage);

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Yellow;

            return (result, color);
        }

        public int recordResult(int wallet, int bet, bool winner, int multiplier)
        {
            if (winner == true)
            {
                string resultMessage = $"Congratualations! You just won ${bet * multiplier}!!";
                Console.SetCursorPosition((Console.BufferWidth - resultMessage.Length) / 2, 7);
                Console.WriteLine(resultMessage);
                wallet = wallet + multiplier * bet;
            }
            else
            {
                string resultMessage = $"Bad Luck! You've just lost ${bet}. Give it another spin!";
                Console.SetCursorPosition((Console.BufferWidth - resultMessage.Length) / 2, 7);
                Console.WriteLine(resultMessage);
                wallet = wallet - bet;
            }
            Console.ReadLine();
            return wallet;
        }
        public int recordResult(int wallet, int bet, bool winner)
        {
            if (winner == true)
            {
                string resultMessage = $"Congratualations! You just won ${bet}!!";
                Console.SetCursorPosition((Console.BufferWidth - resultMessage.Length) / 2, 7);
                Console.WriteLine(resultMessage);
                wallet = wallet + bet;
            }
            else
            {
                string resultMessage = $"Bad Luck! You've just lost ${bet}. Give it another spin!";
                Console.SetCursorPosition((Console.BufferWidth - resultMessage.Length) / 2, 7);
                Console.WriteLine(resultMessage);
                wallet = wallet - bet;
            }
            Console.ReadLine();
            return wallet;
        }

        public int betSize(int wallet, int startCursor)
        {
            int bet = wallet;
            string start = "\t\t\t";
            bool finished = false;
            bool abort = false;

            Console.SetCursorPosition(0, startCursor);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"{start}How much would you like to bet?");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{start}Use Arrow Keys to Adjust");
            Console.WriteLine($"{start}Enter to confirm | ESC to cancel");
            Console.WriteLine();
            Console.WriteLine($"{start}${bet}");

            ConsoleKeyInfo cki;
            Console.TreatControlCAsInput = true;
            do
            {
                cki = Console.ReadKey(true);
                switch (cki.Key)
                {
                    case ConsoleKey.DownArrow:
                        if (bet > 0)
                        {
                            bet -= 1;
                            Console.SetCursorPosition(0, startCursor + 4);
                            Console.WriteLine($"{start}${bet}          ");
                            break;
                        }
                        else
                        {
                            break;
                        }
                    case ConsoleKey.UpArrow:
                        if (bet < wallet)
                        {
                            bet += 1;
                            Console.SetCursorPosition(0, startCursor + 4);
                            Console.WriteLine($"{start}${bet}          ");
                            break;
                        }
                        else
                        {
                            break;
                        }
                    case ConsoleKey.LeftArrow:
                        if (bet - 25 >= 0)
                        {
                            bet -= 25;
                            Console.SetCursorPosition(0, startCursor + 4);
                            Console.WriteLine($"{start}${bet}          ");
                            break;
                        }
                        else
                        {
                            break;
                        }
                    case ConsoleKey.RightArrow:
                        if (bet + 25 <= wallet)
                        {
                            bet += 25;
                            Console.SetCursorPosition(0, startCursor + 4);
                            Console.WriteLine($"{start}${bet}          ");
                            break;
                        }
                        else
                        {
                            break;
                        }
                    case ConsoleKey.Enter:
                        finished = true;
                        break;

                    case ConsoleKey.Escape:
                        abort = true;
                        finished = true;
                        break;
                }
            } while (finished != true);
            if (abort != true)
            {
                return bet;
            }
            else
            {
                bet = 0;
                return bet;
            }

        }

        public int betSize(int wallet, int startCursor, int rightShift)
        {
            int bet = wallet;
            string start = "\t\t\t";
            bool finished = false;
            bool abort = false;


            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.SetCursorPosition(rightShift, startCursor);
            Console.WriteLine($"{start}How much would you like to bet?");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(rightShift, startCursor + 1);
            Console.WriteLine($"{start}Use Arrow Keys to Adjust");
            Console.SetCursorPosition(rightShift, startCursor + 2);
            Console.WriteLine($"{start}Enter to confirm | ESC to cancel");
            Console.WriteLine();
            Console.SetCursorPosition(rightShift, startCursor + 4);
            Console.WriteLine($"{start}${bet}");

            ConsoleKeyInfo cki;
            Console.TreatControlCAsInput = true;
            do
            {
                cki = Console.ReadKey(true);
                switch (cki.Key)
                {
                    case ConsoleKey.DownArrow:
                        if (bet > 0)
                        {
                            bet -= 1;
                            Console.SetCursorPosition(rightShift, startCursor + 4);
                            Console.WriteLine($"{start}${bet}          ");
                            break;
                        }
                        else
                        {
                            break;
                        }
                    case ConsoleKey.UpArrow:
                        if (bet < wallet)
                        {
                            bet += 1;
                            Console.SetCursorPosition(rightShift, startCursor + 4);
                            Console.WriteLine($"{start}${bet}          ");
                            break;
                        }
                        else
                        {
                            break;
                        }
                    case ConsoleKey.LeftArrow:
                        if (bet - 25 >= 0)
                        {
                            bet -= 25;
                            Console.SetCursorPosition(rightShift, startCursor + 4);
                            Console.WriteLine($"{start}${bet}          ");
                            break;
                        }
                        else
                        {
                            break;
                        }
                    case ConsoleKey.RightArrow:
                        if (bet + 25 <= wallet)
                        {
                            bet += 25;
                            Console.SetCursorPosition(rightShift, startCursor + 4);
                            Console.WriteLine($"{start}${bet}          ");
                            break;
                        }
                        else
                        {
                            break;
                        }
                    case ConsoleKey.Enter:
                        finished = true;
                        break;

                    case ConsoleKey.Escape:
                        abort = true;
                        finished = true;
                        break;
                }
            } while (finished != true);
            if (abort != true)
            {
                return bet;
            }
            else
            {
                bet = 0;
                return bet;
            }

        }

        public (bool, int) chooseBetType()
        {
            string menu2 = "What would you like to bet on? (ESC to cancel)";
            List<string> betTypes = new List<string>()
            {

                $"{leftStart}Evens / Odds\t\t\t\t1:1",
                $"{leftStart}Reds / Blacks\t\t\t\t1:1",
                $"{leftStart}Lows / Highs\t\t\t\t1:1",
                $"{leftStart}Dozens\t\t\t\t\t2:1",
                $"{leftStart}Columns (12 Numbers)\t\t\t2:1",
                $"{leftStart}6 Numbers (2 Adjacent Rows)\t\t5:1",
                $"{leftStart}Corner (4 Adjacent Numbers)\t\t8:1",
                $"{leftStart}Street (Row of 3 Numbers)\t\t11:1",
                $"{leftStart}Split (2 Adjacent Numbers)\t\t17:1",
                $"{leftStart}Single Number\t\t\t\t35:1"
            };
            Console.SetCursorPosition((Console.WindowWidth - menu2.Length) / 2, 6);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(menu2);

            int selected = 0;
            bool finished = false;

            ListNavigation list = new ListNavigation(betTypes, 15, finished);

            (finished, selected) = list.scrollList();
            return (finished, selected);
        }
        public (bool, int) chooseEvenOrOdd()
        {
            string menu2 = $"{leftStart}Evens or Odds?";
            List<string> evenOrOdd = new List<string>()
            {
                $"{leftStart}Evens",
                $"{leftStart}Odds",
            };
            Console.SetCursorPosition(0, 15);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(menu2);

            int selected = 0;
            bool finished = false;

            ListNavigation list = new ListNavigation(evenOrOdd, 17, finished);

            (finished, selected) = list.scrollList();
            return (finished, selected);
        }

        public (bool, int) chooseRedOrBlack()
        {
            string menu2 = $"{leftStart}Red or Black?";
            List<string> redsBlacks = new List<string>()
            {
                $"{leftStart}Red",
                $"{leftStart}Black",
            };
            Console.SetCursorPosition(0, 15);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(menu2);

            int selected = 0;
            bool finished = false;

            ListNavigation list = new ListNavigation(redsBlacks, 17, finished);

            (finished, selected) = list.scrollList();
            return (finished, selected);
        }
        public (bool, int) chooseLowsOrHighs()
        {
            string menu2 = $"{leftStart}Lows or Highs?";
            List<string> lowsHighs = new List<string>()
            {
                $"{leftStart}Lows",
                $"{leftStart}Highs",
            };
            Console.SetCursorPosition(0, 15);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(menu2);

            int selected = 0;
            bool finished = false;

            ListNavigation list = new ListNavigation(lowsHighs, 17, finished);

            (finished, selected) = list.scrollList();
            return (finished, selected);
        }

        public (bool, int) splitZeros()
        {
            string menu2 = $"{leftStart}{leftStart}\t\t   Slit 0 and 00?";
            List<string> yesOrNo = new List<string>()
            {
                $"{leftStart}{leftStart}\t\t\tYes",
                $"{leftStart}{leftStart}\t\t\tNo",
            };
            Console.SetCursorPosition(0, 15);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(menu2);

            int selected = 0;
            bool finished = false;

            ListNavigation list = new ListNavigation(yesOrNo, 17, finished);

            (finished, selected) = list.scrollList();
            return (finished, selected);
        }

        public (bool, int) chooseDozens()
        {
            string menu2 = $"{leftStart}Which dozen would you like to bet on?";
            List<string> dozens = new List<string>()
            {
                $"{leftStart}1 - 12",
                $"{leftStart}13 - 24",
                $"{leftStart}25 - 36",
            };
            Console.SetCursorPosition(0, 15);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(menu2);

            int selected = 0;
            bool finished = false;

            ListNavigation list = new ListNavigation(dozens, 17, finished);

            (finished, selected) = list.scrollList();
            return (finished, selected);
        }
        public (bool, int) chooseColumn()
        {
            string menu2 = $"{leftStart}Which column would you like to bet on?";
            List<string> column = new List<string>()
            {
                $"{leftStart}A: 1, 4, 7, 10, 13, 16, 19, 22, 25, 28, 31, 34",
                $"{leftStart}B: 2, 5, 8, 11, 14, 17, 20, 23, 26, 29, 32, 35",
                $"{leftStart}C: 3, 6, 9, 12, 15, 18, 21, 24, 27, 30, 33, 36",
            };
            Console.SetCursorPosition(0, 15);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(menu2);

            int selected = 0;
            bool finished = false;

            ListNavigation list = new ListNavigation(column, 17, finished);

            (finished, selected) = list.scrollList();
            return (finished, selected);
        }
        public (bool, int) choose6Numbers()
        {
            string menu2 = $"{leftStart}Which 6 numbers would you like to bet on?";
            List<string> sixNumbers = new List<string>()
            {
                $"{leftStart}1 through 6",
                $"{leftStart}4 through 9",
                $"{leftStart}7 through 12",
                $"{leftStart}10 through 15",
                $"{leftStart}13 through 18",
                $"{leftStart}16 through 21",
                $"{leftStart}19 through 24",
                $"{leftStart}22 through 27",
                $"{leftStart}25 through 30",
                $"{leftStart}28 through 33",
                $"{leftStart}31 through 36",
            };
            Console.SetCursorPosition(0, 10);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(menu2);

            int selected = 0;
            bool finished = false;

            ListNavigation list = new ListNavigation(sixNumbers, 12, finished);

            (finished, selected) = list.scrollList();
            return (finished, selected);
        }
        public (bool, int) chooseCorner()
        {
            string menu2 = $"{leftStart}Which 4 numbers would you like to bet on?";
            List<string> evenOrOdd = new List<string>()
            {
                $"{leftStart}1, 2, 4, 5",
                $"{leftStart}2, 3, 5, 6",
                $"{leftStart}4, 5, 7, 8",
                $"{leftStart}5, 6, 8, 9",
                $"{leftStart}7, 8, 10, 11",
                $"{leftStart}8, 9, 11, 12",
                $"{leftStart}10, 11, 13, 14",
                $"{leftStart}11, 12, 14, 15",
                $"{leftStart}13, 14, 16, 17",
                $"{leftStart}14, 15, 17, 18",
                $"{leftStart}16, 17, 19, 20",
                $"{leftStart}17, 18, 20, 21",
                $"{leftStart}19, 20, 22, 23",
                $"{leftStart}20, 21, 23, 24",
                $"{leftStart}22, 23, 25, 26",
                $"{leftStart}23, 24, 26, 27",
                $"{leftStart}25, 26, 28, 29",
                $"{leftStart}26, 27, 29, 30",
                $"{leftStart}28, 29, 30, 31",
                $"{leftStart}29, 30, 32, 33",
                $"{leftStart}31, 32, 34, 35",
                $"{leftStart}32, 33, 35, 36",
            };
            Console.SetCursorPosition(0, 10);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(menu2);

            int selected = 0;
            bool finished = false;

            ListNavigationSingleSpaced list = new ListNavigationSingleSpaced(evenOrOdd, 12, finished);

            (finished, selected) = list.scrollList();
            return (finished, selected);
        }
        public (bool, int) chooseStreet()
        {
            string menu2 = $"{leftStart}Which street would you like to bet on?";
            List<string> evenOrOdd = new List<string>()
            {
                $"{leftStart}1, 2, 3",
                $"{leftStart}4, 5, 6",
                $"{leftStart}7, 8, 9",
                $"{leftStart}10, 11, 12",
                $"{leftStart}13, 14, 15",
                $"{leftStart}16, 17, 18",
                $"{leftStart}19, 20, 21",
                $"{leftStart}22, 23, 24",
                $"{leftStart}25, 26, 27",
                $"{leftStart}28, 29, 30",
                $"{leftStart}31, 32, 33",
                $"{leftStart}34, 35, 36",

            };
            Console.SetCursorPosition(0, 10);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(menu2);

            int selected = 0;
            bool finished = false;

            ListNavigation list = new ListNavigation(evenOrOdd, 12, finished);

            (finished, selected) = list.scrollList();
            return (finished, selected);
        }
        public (bool, int, int) chooseSplit()
        {
            string menu2 = $"{leftStart}Which number would you like to bet on?";
            List<string> allNumbers = new List<string>()
            {
                "0", "1","2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "00"
            };
            Console.SetCursorPosition(0, 10);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(menu2);

            int selected1 = 0;
            int selected2 = 0;
            bool finished = false;
            int choice;

            ListNavigation3Columns list = new ListNavigation3Columns(allNumbers, 12, finished);

            (finished, selected1) = list.scrollList();

            if(selected1 == 0)
            {
                (finished, choice) = splitZeros();
                if(finished == false && choice == 0)
                {
                    selected2 = 37;
                }
                else
                {
                    finished = true;
                }
            }
            else if(selected1 == 37)
            {
                (finished, choice) = splitZeros();
                if (finished == false && choice == 0)
                {
                    selected2 = 0;
                }
                else
                {
                    finished = true;
                }
            }
            else
            {
                List<int> splitOptions = new List<int> { };
                (finished, splitOptions) = findSplit(selected1);
                (finished, selected2) = chooseSplit2(selected1, splitOptions);
            }

            return (finished, selected1, selected2);
        }
        public (bool, int) chooseSingleNumber()
        {
            string menu2 = $"{leftStart}Which number would you like to bet on?";
            List<string> allNumbers = new List<string>()
            {
                "0", "1","2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "00"
            };
            Console.SetCursorPosition(0, 10);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(menu2);

            int selected = 0;
            bool finished = false;

            ListNavigation3Columns list = new ListNavigation3Columns(allNumbers, 12, finished);

            (finished, selected) = list.scrollList();
            return (finished, selected);
        }

        public (bool, List<int>) findSplit(int selected)
        {
            bool finished = false;
            List<int> selected2 = new List<int> { };

            if (selected % 3 == 1)
            {
                selected2.Add(selected + 1);
                if (selected - 3 > 0)
                {
                    selected2.Add(selected - 3);
                }
                if(selected + 3 < 37)
                {
                    selected2.Add(selected + 3);
                }
            }
            else if(selected % 3 == 2)
            {
                selected2.Add(selected - 1);
                selected2.Add(selected + 1);
                if (selected - 3 > 0)
                {
                    selected2.Add(selected - 3);
                }
                if (selected + 3 < 37)
                {
                    selected2.Add(selected + 3);
                }
            }
            else
            {
                selected2.Add(selected - 1);
                if (selected - 3 > 0)
                {
                    selected2.Add(selected - 3);
                }
                if (selected + 3 < 37)
                {
                    selected2.Add(selected + 3);
                }

            }
            return (finished, selected2);
        }

        public (bool, int) chooseSplit2(int selected, List<int> list)
        {
            string menu2 = $"{leftStart}{leftStart}\tChoose a number to pair with {selected}:";
            
            Console.SetCursorPosition(0, 15);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(menu2);

            selected = 0;
            bool finished = false;

            ListNavigationInt listOptions = new ListNavigationInt(list, 17, finished);

            (finished, selected) = listOptions.scrollList();
            int pair = list[selected];
            return (finished, selected);
        }
    }
}