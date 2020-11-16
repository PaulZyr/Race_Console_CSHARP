using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2020_11_13
{
    class SportCar : Car
    {
        public SportCar(RoadType road) : base(road)
        {
            CarType = CarType.Sport;
        }
        public override void PrintCar()
        {
            ForegroundColor = Color;

            int left = Position / 100;
            if (left > 112)
            {
                left = 112;
            }

            CursorTop = (int)Road + 1;
            CursorLeft = left;
            WriteLine(@" __  s\__");

            CursorTop = (int)Road + 2;
            CursorLeft = left;
            WriteLine(@"--o----o--");
        }
    }
}

