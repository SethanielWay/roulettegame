using System;

namespace Ex07Roulette
{
    class Program
    {
        public static readonly int windowWidth = Console.LargestWindowWidth - 30;
        public static readonly int windowHeight = Console.LargestWindowHeight - 10;
        static void Main(string[] args)
        {
            Console.SetWindowSize(windowWidth, windowHeight);
            Console.SetBufferSize(windowWidth, windowHeight);
            new App().Run();
        }
    }

    public class App
    {
        public void Run()
        {
            Random rand = new Random();
            Wheel wheel = new Wheel();
            string playerName = "Seth";
            int money = 1000;
            int bet;
            int spins = 0;
            int result;
            string color;
            bool winner = true;
            bool abort = false;

            UI userInterface = new UI(money, playerName, spins);

            userInterface.printUI();
            userInterface.printBoard();
            while (userInterface.money != 0)
            {
                bool finished = false;
                abort = false;
                int selected;
                Console.Clear();
                userInterface.printUI();
                userInterface.printBoard();
                (abort, selected) = userInterface.chooseBetType();
                while (abort != true && finished != true)
                {
                    Console.Clear();
                    userInterface.printUI();
                    userInterface.printBoard();
                    switch (selected)
                    {
                        case 0:
                            (abort, selected) = userInterface.chooseEvenOrOdd();
                            bet = userInterface.betSize(userInterface.money, 23);
                            (result, color) = userInterface.spinWheelAnimation(wheel, rand);
                            if (result > 0 && result < 37 && result % 2 == selected)
                            {
                                winner = true;
                            }
                            else
                            {
                                winner = false;
                            }
                            userInterface.money = userInterface.recordResult(userInterface.money, bet, winner);
                            userInterface.spins++;
                            finished = true;
                            break;

                        case 1:
                            (finished, selected) = userInterface.chooseRedOrBlack();
                            bet = userInterface.betSize(userInterface.money, 23);
                            (result, color) = userInterface.spinWheelAnimation(wheel, rand);
                            char[] colorChoice = { 'R', 'B' };
                            if (colorChoice[selected] == wheel.wheel[result])
                            {
                                winner = true;
                            }
                            else
                            {
                                winner = false;
                            }
                            userInterface.money = userInterface.recordResult(userInterface.money, bet, winner);
                            userInterface.spins++;
                            finished = true;
                            break;

                        case 2:
                            (finished, selected) = userInterface.chooseLowsOrHighs();
                            bet = userInterface.betSize(userInterface.money, 23);
                            (result, color) = userInterface.spinWheelAnimation(wheel, rand);
                            if (result > selected * 18 && result < (selected + 1) * 18 + 1)
                            {
                                winner = true;
                            }
                            else
                            {
                                winner = false;
                            }
                            userInterface.money = userInterface.recordResult(userInterface.money, bet, winner);
                            userInterface.spins++;
                            finished = true;
                            break;

                        case 3:
                            (finished, selected) = userInterface.chooseDozens();
                            bet = userInterface.betSize(userInterface.money, 23);
                            (result, color) = userInterface.spinWheelAnimation(wheel, rand);
                            if (result > selected * 12 && result < (selected + 1) * 12 + 1)
                            {
                                winner = true;
                            }
                            else
                            {
                                winner = false;
                            }
                            userInterface.money = userInterface.recordResult(userInterface.money, bet, winner, 2);
                            userInterface.spins++;
                            finished = true;
                            break;

                        case 4:
                            (finished, selected) = userInterface.chooseColumn();
                            bet = userInterface.betSize(userInterface.money, 23);
                            (result, color) = userInterface.spinWheelAnimation(wheel, rand);
                            if (result > 0 && result < 37 && (result + (2 - selected)) % 3 == 0)
                            {
                                winner = true;
                            }
                            else
                            {
                                winner = false;
                            }
                            userInterface.money = userInterface.recordResult(userInterface.money, bet, winner, 2);
                            userInterface.spins++;
                            finished = true;
                            break;

                        case 5:
                            (finished, selected) = userInterface.choose6Numbers();
                            bet = userInterface.betSize(userInterface.money, 34);
                            (result, color) = userInterface.spinWheelAnimation(wheel, rand);
                            if (result > selected * 3 && result < (selected * 3) + 7)
                            {
                                winner = true;
                            }
                            else
                            {
                                winner = false;
                            }
                            userInterface.money = userInterface.recordResult(userInterface.money, bet, winner, 5);
                            userInterface.spins++;
                            finished = true;
                            break;

                        case 6:
                            (finished, selected) = userInterface.chooseCorner();
                            bet = userInterface.betSize(userInterface.money, 35);
                            (result, color) = userInterface.spinWheelAnimation(wheel, rand);
                            if (result > 0 && result < 37 && result % 2 == 0)
                            {
                                if (result > 1.5 * selected && result < 1.5 * selected + 6 && result != 1.5 * selected + 3)
                                {
                                    winner = true;
                                }
                                else
                                {
                                    winner = false;
                                }
                            }
                            else if (result > 0 && result < 37 && result % 2 != 0)
                            {
                                if (result > 1.5 * selected && result < 1.5 * selected + 5.5 && result != 1.5 * selected + 2.5)
                                {
                                    winner = true;
                                }
                                else
                                {
                                    winner = false;
                                }
                            }
                            else
                            {
                                winner = false;
                            }
                            userInterface.money = userInterface.recordResult(userInterface.money, bet, winner, 8);
                            userInterface.spins++;
                            finished = true;
                            break;

                        case 7:
                            (finished, selected) = userInterface.chooseStreet();
                            bet = userInterface.betSize(userInterface.money, 36);
                            (result, color) = userInterface.spinWheelAnimation(wheel, rand);
                            if (result > selected * 3 && result < selected * 3 + 4)
                            {
                                winner = true;
                            }
                            else
                            {
                                winner = false;
                            }
                            userInterface.money = userInterface.recordResult(userInterface.money, bet, winner, 11);
                            userInterface.spins++;
                            finished = true;
                            break;

                        case 8:
                            int selected1;
                            int selected2;
                            (finished, selected1, selected2) = userInterface.chooseSplit();
                            bet = userInterface.betSize(userInterface.money, 26, 35);
                            (result, color) = userInterface.spinWheelAnimation(wheel, rand);
                            if (result == selected1 || result == selected2)
                            {
                                winner = true;
                            }
                            else
                            {
                                winner = false;
                            }
                            userInterface.money = userInterface.recordResult(userInterface.money, bet, winner, 35);
                            userInterface.spins++;
                            finished = true;
                            break;

                        case 9:
                            (finished, selected) = userInterface.chooseSingleNumber();
                            bet = userInterface.betSize(userInterface.money, 20, 35);
                            (result, color) = userInterface.spinWheelAnimation(wheel, rand);
                            if (result == selected)
                            {
                                winner = true;
                            }
                            else
                            {
                                winner = false;
                            }
                            userInterface.money = userInterface.recordResult(userInterface.money, bet, winner, 35);
                            userInterface.spins++;
                            finished = true;
                            break;

                    }
                }
            }
        }
    }

    public class Wheel
    {
        public char[] wheel = { 'G', 'R', 'B', 'R', 'B', 'R', 'B', 'R', 'B', 'R', 'B', 'B', 'R', 'B', 'R', 'B', 'R', 'B', 'R', 'R', 'B', 'R', 'B', 'R', 'B', 'R', 'B', 'R', 'B', 'B', 'R', 'B', 'R', 'B', 'R', 'B', 'R', 'G' };
        public int[] rowA = { 1, 4, 7, 10, 13, 16, 19, 22, 25, 28, 31, 34 };
        public int[] rowB = { 2, 5, 8, 11, 14, 17, 20, 23, 26, 29, 32, 35 };
        public int[] rowC = { 3, 6, 9, 12, 15, 18 };
        public int Spin(Random rand)
        {
            int result = rand.Next(0, 38);
            return result;
        }
    }
}
