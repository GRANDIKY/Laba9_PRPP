using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba9_PRPP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car car1 = new Car() { Name = "Lada", Color = "red" };
            Car car2 = new Car() { Name = "Toyota", Color = "blue" };
            Car car3 = new Car() { Name = "BMW", Color = "black" };

            Garage garage = new Garage();
            garage.AddCar(car1);
            garage.AddCar(car2);
            garage.AddCar(car3);

            Washer washer = new Washer();

            garage.SetWashCarDelegate(washer.Wash);

            garage.WashAllCars();

            garage.GetInfo();
        }

        public delegate void WashCarDelegate(Car car);

        public class Car
        {
            public string Name { get; set; }
            public string Color { get; set; }
            public bool IsClean { get; set; } = false; // Машина изначально не чистая

            public void Wash()
            {
                IsClean = true;
                Console.WriteLine($"Машина {Name} помыта.");
            }

            public void GetInfo()
            {
                Console.WriteLine($"Машина: {Name}, цвет: {Color}, чистая: {IsClean}");
            }
        }

        public class Garage
        {
            private List<Car> cars = new List<Car>();

            private WashCarDelegate washCarDelegate;

            public void SetWashCarDelegate(WashCarDelegate washCarDelegate)
            {
                this.washCarDelegate = washCarDelegate;
            }

            public void AddCar(Car car)
            {
                cars.Add(car);
            }

            public void WashAllCars()
            {
                if (washCarDelegate != null)
                {
                    foreach (Car car in cars)
                    {
                        if (!car.IsClean)
                        {
                            washCarDelegate(car);
                        }
                    }
                }
            }

            public void GetInfo()
            {
                Console.WriteLine("Информация о гараже:");
                foreach (Car car in cars)
                {
                    car.GetInfo();
                }
            }
        }

        public class Washer
        {
            public void Wash(Car car)
            {
                car.Wash();
            }
        }

    }
}
