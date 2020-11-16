using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2020_11_13
{
    public class PrintGame
    {
        public static void PrintBoard(List<Car> cars)
        {
            Clear();
            ForegroundColor = ConsoleColor.White;
            for (var i = 0; i <= 22; ++i)
            {
                for (var j = 0; j <= 128; ++j)
                {
                    if (i == 0 || i == 5 || i == 10
                        || i == 15 || i == 20 || i == 22)
                    {
                        Write("-");
                    }
                    else if (j == 0 || (j == 10 && i != 21) || j == 128)
                    {
                        Write("|");
                    }
                    else
                    {
                        Write(" ");
                    }
                }
                WriteLine();
            }
            PrintDistanceInfo();
            PrintFinish();
            PrintGameInfo(cars);
        }
        public static void PrintGameInfo(List<Car> cars)
        {
            ForegroundColor = ConsoleColor.White;
            CursorTop = 24;
            CursorLeft = 0;
            foreach (var item in cars)
            {
                ForegroundColor = item.Color;
                WriteLine(item);
            }
        }
        public static void PrintFinish()
        {
            for (var i = 1; i < 20; ++i)
            {
                if (i != 5 && i != 10 && i != 15)
                {
                    ForegroundColor = ConsoleColor.Red;
                    CursorTop = i;
                    CursorLeft = 122;
                    Write("$$");
                }
            }
        }
        public static void PrintDistanceInfo()
        {
            string result = "";
            string str = new string('.', 22);
            result += "START" + str + "25"
                + str + "50" + str + "75" + str + "FINISH";
            ForegroundColor = ConsoleColor.Red;
            CursorTop = 21;
            CursorLeft = 22;
            WriteLine(result);
        }
        public static void CountDown()
        {
            ForegroundColor = ConsoleColor.Red;
            CursorTop = 12;
            CursorLeft = 50;
            Write($"Press any key to start");
            ReadKey();
            for (var i = 3; i > 0; i--)
            {
                CursorTop = 12;
                CursorLeft = 50;
                Write($"START in {i}            ");
                System.Threading.Thread.Sleep(1000);
            }
            CursorTop = 12;
            CursorLeft = 50;
            Write("              ");
        }
        public static char Greeting()
        {
            int top = 4;
            int left = 8;
            Hello();
            System.Threading.Thread.Sleep(1500);
            Clear();
            Frame();
            ForegroundColor = ConsoleColor.DarkCyan;
            CursorTop = top;
            CursorLeft = left + 4;
            WriteLine("***** Menu: *****\n");
            CursorLeft = left;
            WriteLine("1 - Play with Default Cars");
            CursorLeft = left;
            WriteLine("2 - Choose Player's Names and Cars");
            CursorLeft = left;
            WriteLine("0 - Exit\n");
            CursorLeft = left + 4;
            Write("Input: ");

            return ReadLine()[0];
        }
        static void Frame()
        {
            for (int i = 2; i <= 12; ++i)
            {
                CursorTop = i;
                if (i == 2 || i == 12)
                {
                    CursorLeft = 5;
                    Write(new string('%', 41));
                }
                else
                {
                    CursorLeft = 5;
                    Write("%");
                    CursorLeft = 45;
                    WriteLine("%");
                }

            }
        }
        static void Hello()
        {
            ForegroundColor = ConsoleColor.DarkCyan;
            int left = 7;
            CursorTop = 3;
            CursorLeft = left;
            WriteLine(@" %%  %%  %%%%%%  %%      %%       /%%%\    %%");
            CursorLeft = left;
            WriteLine(" %%  %%  %%      %%      %%      %%   %%   %%");
            CursorLeft = left;
            WriteLine(" %%%%%%  %%%%%%  %%      %%      %%   %%   %%");
            CursorLeft = left;
            WriteLine(" %%  %%  %%      %%      %%      %%   %%     ");
            CursorLeft = left;
            WriteLine(@" %%  %%  %%%%%%  %%%%%%  %%%%%%   \%%%/    %%");
        }
        public static void Bye()
        {
            ForegroundColor = ConsoleColor.DarkCyan;
            int left = 15;
            CursorTop = 7;
            CursorLeft = left;
            WriteLine(" %%%%%   %%  %%  %%%%%%          %%%%%   %%  %%  %%%%%% ");
            CursorLeft = left;
            WriteLine(" %%  %%  %%  %%  %%              %%  %%  %%  %%  %%     ");
            CursorLeft = left;
            WriteLine(" %%%%%    %%%%   %%%%%%   %%%%   %%%%%    %%%%   %%%%%% ");
            CursorLeft = left;
            WriteLine(" %%  %%    %%    %%              %%  %%    %%    %%     ");
            CursorLeft = left;
            WriteLine(" %%%%%     %%    %%%%%%          %%%%%     %%    %%%%%% ");
        }
    }
}
