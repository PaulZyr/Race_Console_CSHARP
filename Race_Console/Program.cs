using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2020_11_13
{
    class Program
    {
        // PE911 Зырянов Павел
        // д/з урок 9 "Автомобильные гонки"
        // от 13.11.2020

        static void Main(string[] args)
        {
            PlayGame play = new PlayGame();
            char q = PrintGame.Greeting();

            if (q == '1')
            {
                play.InitDefaultDriverNames();
            }
            else if (q == '2')
            {
                InputDriverNamesTypeCar(play);
            }

            try
            {
                if (q != '0')
                {
                    play.Play(0);
                }
            }
            catch(Exception ex)
            {
                if (ex.Message != "exit")
                {
                    PrintGame.PrintExceptionInfo(ex.Message);
                }
            }
            Clear();
            PrintGame.Bye();
            ReadKey();
        }
        static void InputDriverNamesTypeCar(PlayGame play)
        {
            for (var i = 1; i <= 4; i++)
            {
                Clear();
                WriteLine($"Input {i} driver's Name: ");
                string name = ReadLine();
                WriteLine($"Choose a Car for {name}:\n" +
                    $"1 - Sport Car\n" +
                    $"2 - Cargo Car\n" +
                    $"3 - Passenger Car\n" +
                    $"4 - Bus");
                string str = ReadLine();
                int choose = 0;
                if (!Int32.TryParse(str, out choose)
                    || choose < 1 || choose > 4)
                {
                    WriteLine("Wrong Input! Player car will be default!");
                }

                Car car = null;
                switch (choose)
                {
                    case 1:
                        car = new SportCar(RoadType.First);
                        break;
                    case 2:
                        car = new CargoCar(RoadType.Second);
                        break;
                    case 3:
                        car = new PassengerCar(RoadType.Third);
                        break;
                    case 4:
                        car = new BusCar(RoadType.Fourth);
                        break;
                    default:
                        car = new PassengerCar((RoadType)i);
                        break;
                }
                car.DriverName = name;
                play.AddCar(car);
            }
        }
    }
}
