using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Lab2
{
    class Program
    {
        static void Main()
        {
            // 1.
            string[] A = { "12", "34", "52", "78", "90"};
            var elementsWithTwo = A.Where(s => s.Contains('2'));
            Console.WriteLine("Elements containing '2': " + string.Join(", ", elementsWithTwo));

            // 2. 
            int[] B = { 2, -7, -10, 6, 7, 9, 3 };
            var positiveElements = B.Where(n => n > 0);
            Console.WriteLine("Positive elements: " + string.Join(", ", positiveElements));

            // 3.
            string[] C = { "Light Green", "Red", "Green", "Yellow", "Purple", "Dark Green", "Light Red", "Dark Red", "Dark Yellow", "Light Yellow" };
            var yellowShades = C.Where(c => c.Contains("Yellow"));
            Console.WriteLine("Yellow shades: " + string.Join(", ", yellowShades));

            // 4. 
            var cars = new List<Car>
            {
                new Car { Model = "Sedan", PassengerCount = 4, Passengers = new List<Passenger>
                    {
                        new Passenger { Gender = "Male", Age = 35 },
                        new Passenger { Gender = "Female", Age = 28 },
                        new Passenger { Gender = "Male", Age = 42 },
                        new Passenger { Gender = "Female", Age = 19 }
                    }
                },
                new Car { Model = "SUV", PassengerCount = 5, Passengers = new List<Passenger>
                    {
                        new Passenger { Gender = "Male", Age = 50 },
                        new Passenger { Gender = "Female", Age = 22 },
                        new Passenger { Gender = "Male", Age = 31 },
                        new Passenger { Gender = "Female", Age = 27 },
                        new Passenger { Gender = "Male", Age = 38 }
                    }
                },
                new Car { Model = "Sports", PassengerCount = 2, Passengers = new List<Passenger>
                    {
                        new Passenger { Gender = "Male", Age = 25 },
                        new Passenger { Gender = "Female", Age = 23 }
                    }
                },
                new Car { Model = "Minivan", PassengerCount = 7, Passengers = new List<Passenger>
                    {
                        new Passenger { Gender = "Male", Age = 52 },
                        new Passenger { Gender = "Female", Age = 48 },
                        new Passenger { Gender = "Male", Age = 15 },
                        new Passenger { Gender = "Female", Age = 17 },
                        new Passenger { Gender = "Male", Age = 9 },
                        new Passenger { Gender = "Female", Age = 11 },
                        new Passenger { Gender = "Male", Age = 7 }
                    }
                }
            };
            
            var carsWithFourPassengers = cars.Where(c => c.PassengerCount == 4);
            foreach (var car in carsWithFourPassengers)
            {
                Console.WriteLine($"Car: {car.Model}, Passengers:");
                foreach (var passenger in car.Passengers)
                {
                    Console.WriteLine($"  - Gender: {passenger.Gender}, Age: {passenger.Age}");
                }
            }

            // 5. 
            var products = new List<Product>
            {
                new Product { Name = "Apple", Quantity = 3, Description = "Fresh fruit" },
                new Product { Name = "Bread", Quantity = 2, Description = "Whole grain" },
                new Product { Name = "Milk", Quantity = 1, Description = "Low fat" },
                new Product { Name = "Cheese", Quantity = 4, Description = "Cheddar" },
                new Product { Name = "Orange", Quantity = 5, Description = "Fresh fruit" }
            };

            var productsWithLowQuantity = products.Where(p => p.Quantity < 5);
            foreach (var product in productsWithLowQuantity)
            {
                Console.WriteLine($"Product: {product.Name}, Quantity: {product.Quantity}, Description: {product.Description}");
            }
            
            // 6.
            List<string> myCars = new List<string> { "Yugo", "Aztec", "BMW" };
            List<string> yourCars = new List<string> { "BMW", "Saab", "Aztec" };
            
            var combinedCars = myCars.Concat(yourCars);
            
            Console.WriteLine("All cars (with duplicates): " + string.Join(", ", combinedCars));
        }
    }

    class Car
    {
        public string Model { get; set; }
        public int PassengerCount { get; set; }
        public List<Passenger> Passengers { get; set; }
    }
    
    class Passenger
    {
        public string Gender { get; set; }
        public int Age { get; set; }
    }

    class Product
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
    }

    [TestFixture]
    public class UnitTests
    {
        [Test]
        public void TestElementsWithTwo()
        {
            string[] A = { "12", "34", "52", "78", "90" };
            var elementsWithTwo = A.Where(s => s.Contains('2'));
            Assert.That(elementsWithTwo, Is.EqualTo(new[] { "12", "52" }));
        }

        [Test]
        public void TestPositiveElements()
        {
            int[] B = { 2, -7, -10, 6, 7, 9, 3 };
            var positiveElements = B.Where(n => n > 0);
            Assert.That(positiveElements, Is.EqualTo(new[] { 2, 6, 7, 9, 3 }));
        }

        [Test]
        public void TestYellowShades()
        {
            string[] C = { "Light Green", "Red", "Green", "Yellow", "Purple", "Dark Green", "Light Red", "Dark Red", "Dark Yellow", "Light Yellow" };
            var yellowShades = C.Where(c => c.Contains("Yellow"));
            Assert.That(yellowShades, Is.EqualTo(new[] { "Yellow", "Dark Yellow", "Light Yellow" }));
        }

        [Test]
        public void TestCarsWithFourPassengers()
        {
            var cars = new List<Car>
            {
                new Car { Model = "Sedan", PassengerCount = 4, Passengers = new List<Passenger>
                    {
                        new Passenger { Gender = "Male", Age = 35 },
                        new Passenger { Gender = "Female", Age = 28 },
                        new Passenger { Gender = "Male", Age = 42 },
                        new Passenger { Gender = "Female", Age = 19 }
                    }
                },
                new Car { Model = "SUV", PassengerCount = 5, Passengers = new List<Passenger>() },
            };

            var carsWithFourPassengers = cars.Where(c => c.PassengerCount == 4);
            Assert.That(carsWithFourPassengers.Count(), Is.EqualTo(1));
            Assert.That(carsWithFourPassengers.First().Model, Is.EqualTo("Sedan"));
        }

        [Test]
        public void TestProductsWithLowQuantity()
        {
            var products = new List<Product>
            {
                new Product { Name = "Apple", Quantity = 3, Description = "Fresh fruit" },
                new Product { Name = "Bread", Quantity = 2, Description = "Whole grain" },
                new Product { Name = "Milk", Quantity = 1, Description = "Low fat" },
                new Product { Name = "Cheese", Quantity = 4, Description = "Cheddar" },
                new Product { Name = "Orange", Quantity = 5, Description = "Fresh fruit" }
            };

            var productsWithLowQuantity = products.Where(p => p.Quantity < 5);
            Assert.That(productsWithLowQuantity.Count(), Is.EqualTo(4));
            Assert.That(productsWithLowQuantity.Select(p => p.Name), Is.EqualTo(new[] { "Apple", "Bread", "Milk", "Cheese" }));
        }

        [Test]
        public void TestCombinedCars()
        {
            List<string> myCars = new List<string> { "Yugo", "Aztec", "BMW" };
            List<string> yourCars = new List<string> { "BMW", "Saab", "Aztec" };
            
            var combinedCars = myCars.Concat(yourCars);
            
            Assert.That(combinedCars, Is.EqualTo(new[] { "Yugo", "Aztec", "BMW", "BMW", "Saab", "Aztec" }));
        }
    }
}
