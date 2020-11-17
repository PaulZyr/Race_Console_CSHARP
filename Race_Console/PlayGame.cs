using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2020_11_13
{
    class PlayGame
    {
        List<Car> cars;
        public int MinForRandomCarSpeed { get; set; }
        public int MaxForRandomCarSpeed { get; set; }
        
        public event Action prepareCarEvent;
        public event Action driveCarEvent;
        public event Action finishEvent;

        public PlayGame()
        {
            cars = new List<Car>();
            MinForRandomCarSpeed = 140;
            MaxForRandomCarSpeed = 200;
        }
        public void AddCar(Car car)
        {
            cars.Add(car);
        }
        public void Play(int n)
        {
            try
            {
                if (n == 0)
                {
                    BeforeStart();
                }

                OnPrepareCarEvent();

                PrintGame.CountDown();

                while (true)
                {
                    OnDriveCarEvent();

                    PrintGame.PrintGameInfo(cars);

                    if (CheckFinish())
                    {
                        OnFinishEvent();
                    }

                    System.Threading.Thread.Sleep(40);
                }
            }
            catch(Exception ex)
            {
                if (ex.Message != "exit")
                {
                    PrintGame.PrintExceptionInfo(ex.Message);
                }
                else
                {
                    throw new Exception("exit");
                }
            }
        }
        void PlayAgain()
        {
            if (Again())
            {
                foreach(var item in cars)
                {
                    item.Position = 1200;
                    item.MaxSpeed = Car._random.Next
                        (MinForRandomCarSpeed, MaxForRandomCarSpeed);
                }
                PrintGame.PrintBoard(cars);
                Play(1);
            }
            else throw new Exception("exit");
        }
        bool Again()
        {
            ForegroundColor = ConsoleColor.White;
            CursorTop = 13;
            CursorLeft = 36;
            Write("Press ENTER to continue");
            ReadKey();
            CursorLeft = 36;
            Write("                       ");
            CursorLeft = 36;
            Write("Play again? (y/n): ");
            string str = ReadLine();
            if (str == "y" || str == "yes" || str == "1")
            {
                return true;
            }
            else return false;
        }
        public void BeforeStart()
        {
            SetWindowSize(150, 40);
            foreach(var item in cars)
            {
                item.MaxSpeed = Car._random.Next
                    (MinForRandomCarSpeed, MaxForRandomCarSpeed);
                prepareCarEvent += new Action(item.Prepare);
                driveCarEvent += new Action(item.Drive);
            }
            finishEvent += GameOver;
            PrintGame.PrintBoard(cars);
        }
        void OnPrepareCarEvent()
        {
            if (prepareCarEvent != null)
            {
                prepareCarEvent.Invoke();
            }
            else
            {
                throw new Exception("prepareCarEvent is empty");
            }
        }
        void OnDriveCarEvent()
        {
            if (driveCarEvent != null)
            {
                driveCarEvent.Invoke();
            }
            else
            {
                throw new Exception("driveCarEvent is empty");
            }
        }
        void OnFinishEvent()
        {
            if (finishEvent != null)
            {
                finishEvent.Invoke();
            }
            else
            {
                throw new Exception("finishEvent is empty");
            }
        }
        bool CheckFinish()
        {
            foreach (var item in cars)
            {
                if ((item.Position / 100 - 12) >= 100)
                {
                    return true;
                }
            }
            return false;
        }
        public void GameOver()
        {
            Car winner = Winner();

            ForegroundColor = ConsoleColor.Red;
            
            for (int j = 5; j <= 11; ++j)
            {
                CursorTop = j;
                for (int i = 35; i <= 61; ++i)
                {
                    CursorLeft = i;
                    if (j == 5 || j == 11 || i == 35 || i == 61)
                    {
                        Write("*");
                    }
                    else Write(" ");
                }
            }
            CursorTop = 7;
            CursorLeft = 40;
            WriteLine("--- GAME OVER ---");
            CursorTop = 9;
            CursorLeft = 40;
            Write("Winner:  ");
            ForegroundColor = winner.Color;
            Write($"{winner.DriverName}");

            PlayAgain();
        }
        Car Winner()
        {
            Car tmp = cars[0];
            foreach (var item in cars)
            {
                if (item.Position > tmp.Position)
                {
                    tmp = item;
                }
            }
            return tmp;
        }
        public void InitDefaultDriverNames()
        {
            cars.Add(new CargoCar(RoadType.First)
            { DriverName = "Olivia" });
            cars.Add(new PassengerCar(RoadType.Second)
            { DriverName = "Ignat" });
            cars.Add(new SportCar(RoadType.Third)
            { DriverName = "Erika" });
            cars.Add(new BusCar(RoadType.Fourth)
            { DriverName = "Jerry" });
        }
    }
}