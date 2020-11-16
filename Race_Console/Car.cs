using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2020_11_13
{
    public enum RoadType { First = 2, Second = 7, Third = 12, Fourth = 17};
    public enum CarType { Passenger, Cargo, Sport, Bus};
    public abstract class Car
    {
        public Car(RoadType road)
        {
            Road = road;
            Position = 1200;
            Color = FindColor(road);
            _random = new Random();
        }

        public static Random _random;
        public ConsoleColor Color { get; set; }
        
        public int Position { get; set; }
        public RoadType Road { get; set; }
        public string DriverName { get; set; }
        public int MaxSpeed { get; set; }
        public CarType CarType { get; set; }

        public void Prepare()
        {
            ForegroundColor = Color;
            CursorTop = (int)Road + 1;
            CursorLeft = 2;
            if (DriverName.Length > 7)
            {
                Write(DriverName.Substring(0, 7));
            }
            else Write(DriverName);

            PrintCar();
        }
        public void Drive()
        {
            ClearPrintedCar();

            int k = _random.Next(10, MaxSpeed / 2);
            Position += k;
            BonusPenalty(k);
            
            PrintCar();
        }
        void BonusPenalty(int k)
        {
            if (k > 80)
            {
                Position -= k;
            }
            else if (k % 77 == 0)
            {
                Position += k * 2;
            }
            else if (k % 33 == 0)
            {
                Position += k;
            }
            else if (k % 11 == 0)
            {
                Position -= k / 2;
            }
            else if (k % 7 == 0)
            {
                Position -= k / 4;
            }

        }
        public void ClearPrintedCar()
        {
            CursorTop = (int)Road;
            CursorLeft = Position / 100;
            WriteLine(@"       ");

            CursorTop = (int)Road + 1;
            CursorLeft = Position / 100;
            WriteLine(@"          ");

            CursorTop = (int)Road + 2;
            CursorLeft = Position / 100;
            WriteLine(@"          ");
        }
        public ConsoleColor FindColor(RoadType road)
        {
            if (Road == RoadType.First)
            {
                return ConsoleColor.Blue;
            }
            else if (Road == RoadType.Second)
            {
                return ConsoleColor.DarkYellow;
            }
            else if (Road == RoadType.Third)
            {
                return ConsoleColor.Cyan;
            }
            else
            {
                return ConsoleColor.Green;
            }
        }
        public override string ToString()
        {
            return $"{DriverName}: {Road.ToString()}, " +
                $"{CarType}, MaxSpeed: {MaxSpeed}, " +
                $"Position: {((double)Position/100 - 12):F2}";
        }
        public abstract void PrintCar();
    }
}
