using System;
using System.Collections.Generic;
using System.Text;

namespace Ex07Roulette
{
    public class ListNavigation
    {
        List<string> list;
        int cursorStart;
        bool abort;

        public ListNavigation(List<string> list, int cursorStart, bool abort)
        {
            this.list = list;
            this.cursorStart = cursorStart;
            this.abort = abort;
        }

        public (bool, int) scrollList()
        {
            abort = false;
            Console.SetCursorPosition(0, cursorStart);

            Console.ForegroundColor = ConsoleColor.Yellow;

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($" {list[i]}");
                Console.WriteLine();
            }

            int index = 0;

            Console.SetCursorPosition(0, cursorStart);
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.Write($" {list[index]}");
            Console.ResetColor();
            Console.SetCursorPosition(0, 6);

            ConsoleKeyInfo cki;
            Console.TreatControlCAsInput = true;
            do
            {
                cki = Console.ReadKey(true);
                switch (cki.Key)
                {
                    case ConsoleKey.DownArrow:
                        if (index < list.Count - 1)
                        {
                            Console.SetCursorPosition(0, cursorStart + (2 * index));
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write($" {list[index]}");

                            index++;

                            Console.SetCursorPosition(0, cursorStart + (2 * index));
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.Gray;
                            Console.Write($" {list[index]}");
                            Console.ResetColor();
                            Console.SetCursorPosition(0, 6);
                            break;
                        }
                        else
                        {
                            break;
                        }

                    case ConsoleKey.UpArrow:

                        if (index > 0)
                        {
                            Console.SetCursorPosition(0, cursorStart + (2 * index));
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write($" {list[index]}");

                            index--;

                            Console.SetCursorPosition(0, cursorStart + (2 * index));
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.Gray;
                            Console.Write($" {list[index]}");
                            Console.ResetColor();
                            Console.SetCursorPosition(0, 6);
                            break;
                        }
                        else
                        {
                            break;
                        }
                    case ConsoleKey.Escape:
                        abort = true;
                        break;
                }
            } while (cki.Key != ConsoleKey.Enter && abort != true);
            return (abort, index);
        }
    }
    public class ListNavigationInt
    {
        List<int> list;
        int cursorStart;
        bool abort;
        string indent = $"\t\t\t\t\t\t\t\t\t";

        public ListNavigationInt(List<int> list, int cursorStart, bool abort)
        {
            this.list = list;
            this.cursorStart = cursorStart;
            this.abort = abort;
        }

        public (bool, int) scrollList()
        {
            abort = false;
            Console.SetCursorPosition(0, cursorStart);

            Console.ForegroundColor = ConsoleColor.Yellow;

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"{indent}{list[i]}");
                Console.WriteLine();
            }

            int index = 0;

            Console.SetCursorPosition(0, cursorStart);
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.Write($"{indent}{list[index]}");
            Console.ResetColor();
            Console.SetCursorPosition(0, 6);

            ConsoleKeyInfo cki;
            Console.TreatControlCAsInput = true;
            do
            {
                cki = Console.ReadKey(true);
                switch (cki.Key)
                {
                    case ConsoleKey.DownArrow:
                        if (index < list.Count - 1)
                        {
                            Console.SetCursorPosition(0, cursorStart + (2 * index));
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write($"{indent}{list[index]}");

                            index++;

                            Console.SetCursorPosition(0, cursorStart + (2 * index));
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.Gray;
                            Console.Write($"{indent}{list[index]}");
                            Console.ResetColor();
                            Console.SetCursorPosition(0, 6);
                            break;
                        }
                        else
                        {
                            break;
                        }

                    case ConsoleKey.UpArrow:

                        if (index > 0)
                        {
                            Console.SetCursorPosition(0, cursorStart + (2 * index));
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write($"{indent}{list[index]}");

                            index--;

                            Console.SetCursorPosition(0, cursorStart + (2 * index));
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.Gray;
                            Console.Write($"{indent}{list[index]}");
                            Console.ResetColor();
                            Console.SetCursorPosition(0, 6);
                            break;
                        }
                        else
                        {
                            break;
                        }
                    case ConsoleKey.Escape:
                        abort = true;
                        break;
                }
            } while (cki.Key != ConsoleKey.Enter && abort != true);
            return (abort, index);
        }
    }
    public class ListNavigationSingleSpaced
    {
        List<string> list;
        int cursorStart;
        bool abort;

        public ListNavigationSingleSpaced(List<string> list, int cursorStart, bool abort)
        {
            this.list = list;
            this.cursorStart = cursorStart;
            this.abort = abort;
        }

        public (bool, int) scrollList()
        {
            abort = false;
            Console.SetCursorPosition(0, cursorStart);

            Console.ForegroundColor = ConsoleColor.Yellow;

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($" {list[i]}");
            }

            int index = 0;

            Console.SetCursorPosition(0, cursorStart);
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.Write($" {list[index]}");
            Console.ResetColor();
            Console.SetCursorPosition(0, 6);

            ConsoleKeyInfo cki;
            Console.TreatControlCAsInput = true;
            do
            {
                cki = Console.ReadKey(true);
                switch (cki.Key)
                {
                    case ConsoleKey.DownArrow:
                        if (index < list.Count - 1)
                        {
                            Console.SetCursorPosition(0, cursorStart + index);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write($" {list[index]}");

                            index++;

                            Console.SetCursorPosition(0, cursorStart + index);
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.Gray;
                            Console.Write($" {list[index]}");
                            Console.ResetColor();
                            Console.SetCursorPosition(0, 6);
                            break;
                        }
                        else
                        {
                            break;
                        }

                    case ConsoleKey.UpArrow:

                        if (index > 0)
                        {
                            Console.SetCursorPosition(0, cursorStart + index);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write($" {list[index]}");

                            index--;

                            Console.SetCursorPosition(0, cursorStart + index);
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.Gray;
                            Console.Write($" {list[index]}");
                            Console.ResetColor();
                            Console.SetCursorPosition(0, 6);
                            break;
                        }
                        else
                        {
                            break;
                        }
                    case ConsoleKey.Escape:
                        abort = true;
                        break;
                }
            } while (cki.Key != ConsoleKey.Enter && abort != true);
            return (abort, index);
        }
    }
    public class ListNavigation3Columns
    {
        List<string> list;
        int cursorStart;
        bool abort;
        string tab = $"\t";

        public ListNavigation3Columns(List<string> list, int cursorStart, bool abort)
        {
            this.list = list;
            this.cursorStart = cursorStart;
            this.abort = abort;
        }

        public (bool, int) scrollList()
        {
            abort = false;
            Console.SetCursorPosition(0, cursorStart);

            Console.ForegroundColor = ConsoleColor.Yellow;

            for (int i = 0; i < 13; i++)
            {
                Console.WriteLine($"\t\t\t{tab}{list[i]}");
                Console.WriteLine();
            }

            Console.SetCursorPosition(0, cursorStart);
            // 0, 1, 2, 3, 4, 5, 6, 7, 8, 9,10,11,12
            //13,14,15,16,17,18,19,20,21,22,23,24,25
            //26,27,28,29,30,31,32,33,34,35,36,00
            for (int i = 13; i < 26; i++)
            {
                Console.WriteLine($"\t\t\t{tab}{tab}{list[i]}");
                Console.WriteLine();
            }

            Console.SetCursorPosition(0, cursorStart);

            for (int i = 26; i < list.Count; i++)
            {
                Console.WriteLine($"\t\t\t{tab}{tab}{tab}{list[i]}");
                Console.WriteLine();
            }

            int index = 0;
            int columnIndex = 0;
            int column = 1;
            string Tabs(int n)
            {
                return new string('\t', n);
            }

            Console.SetCursorPosition(0, cursorStart);
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.Write($"\t\t\t{tab}{list[index]}");
            Console.ResetColor();
            Console.SetCursorPosition(0, 6);

            ConsoleKeyInfo cki;
            Console.TreatControlCAsInput = true;
            do
            {
                cki = Console.ReadKey(true);
                switch (cki.Key)
                {
                    case ConsoleKey.DownArrow:
                        if (column != 3)
                        {
                            if (columnIndex < 12)
                            {
                                Console.SetCursorPosition(0, cursorStart + (2 *columnIndex));
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write($"\t\t\t{Tabs(column)}{list[index]}");

                                index++;
                                columnIndex++;

                                Console.SetCursorPosition(0, cursorStart + (2 * columnIndex));
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.BackgroundColor = ConsoleColor.Gray;
                                Console.Write($"\t\t\t{Tabs(column)}{list[index]}");
                                Console.ResetColor();
                                Console.SetCursorPosition(0, 6);
                                break;
                            }
                            else
                            {
                                Console.SetCursorPosition(0, cursorStart + (2 * columnIndex));
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write($"\t\t\t{Tabs(column)}{list[index]}");

                                index++;
                                columnIndex = 0;
                                column++;

                                Console.SetCursorPosition(0, cursorStart + (2 * columnIndex));
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.BackgroundColor = ConsoleColor.Gray;
                                Console.Write($"\t\t\t{Tabs(column)}{list[index]}");
                                Console.ResetColor();
                                Console.SetCursorPosition(0, 6);
                                break;
                            }
                        }
                        else
                        {
                            if (columnIndex < list.Count - 1 - (13 * (column - 1)))
                            {
                                Console.SetCursorPosition(0, cursorStart + (2 * columnIndex));
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write($"\t\t\t{Tabs(column)}{list[index]}");

                                index++;
                                columnIndex++;

                                Console.SetCursorPosition(0, cursorStart + (2 * columnIndex));
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.BackgroundColor = ConsoleColor.Gray;
                                Console.Write($"\t\t\t{Tabs(column)}{list[index]}");
                                Console.ResetColor();
                                Console.SetCursorPosition(0, 6);
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                    case ConsoleKey.UpArrow:

                        if (columnIndex > 0)
                        {
                            Console.SetCursorPosition(0, cursorStart + (2 *columnIndex));
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write($"\t\t\t{Tabs(column)}{list[index]}");

                            index--;
                            columnIndex--;

                            Console.SetCursorPosition(0, cursorStart + (2 * columnIndex));
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.Gray;
                            Console.Write($"\t\t\t{Tabs(column)}{list[index]}");
                            Console.ResetColor();
                            Console.SetCursorPosition(0, 6);
                            break;
                        }
                        else if (column > 1)
                        {
                            Console.SetCursorPosition(0, cursorStart + (2 * columnIndex));
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write($"\t\t\t{Tabs(column)}{list[index]}");

                            index--;
                            columnIndex = 12;
                            column--;

                            Console.SetCursorPosition(0, cursorStart + (2 * columnIndex));
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.Gray;
                            Console.Write($"\t\t\t{Tabs(column)}{list[index]}");
                            Console.ResetColor();
                            Console.SetCursorPosition(0, 6);
                            break;
                        }
                        else
                        {
                            break;
                        }

                    case ConsoleKey.RightArrow:

                        if (column < 3)
                        {
                            Console.SetCursorPosition(0, cursorStart + (2 * columnIndex));
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write($"\t\t\t{Tabs(column)}{list[index]}");

                            column++;
                            index += 13;

                            Console.SetCursorPosition(0, cursorStart + (2 * columnIndex));
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.Gray;
                            Console.Write($"\t\t\t{Tabs(column)}{list[index]}");
                            Console.ResetColor();
                            Console.SetCursorPosition(0, 6);
                            break;
                        }
                        else
                        {
                            break;
                        }
                    case ConsoleKey.LeftArrow:

                        if (column > 1)
                        {
                            Console.SetCursorPosition(0, cursorStart + (2 * columnIndex));
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write($"\t\t\t{Tabs(column)}{list[index]}");

                            column--;
                            index -= 13;

                            Console.SetCursorPosition(0, cursorStart + (2 * columnIndex));
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.Gray;
                            Console.Write($"\t\t\t{Tabs(column)}{list[index]}");
                            Console.ResetColor();
                            Console.SetCursorPosition(0, 6);
                            break;
                        }
                        else
                        {
                            break;
                        }
                    case ConsoleKey.Escape:
                        abort = true;
                        break;
                }
            } while (cki.Key != ConsoleKey.Enter && abort != true);
            return (abort, index);
        }
    }
}