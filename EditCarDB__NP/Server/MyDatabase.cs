using Bogus;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    internal static class MyDatabase
    {
        public static List<Car> Cars { get; set; }
        static MyDatabase()
        {
            var carFaker = new Faker<Car>()
                .RuleFor(c => c.Id, f => f.IndexFaker)
                .RuleFor(c => c.Make, f => f.Vehicle.Manufacturer())
                .RuleFor(c => c.Model, f => f.Vehicle.Model())
                .RuleFor(c => c.Year, f => f.Random.Short(2000, 2023))
                .RuleFor(c => c.Color, f => f.Commerce.Color());
            Cars = carFaker.Generate(200);
        }

        public static Ca﻿r? GetById(int id)
        {
            Car? WantedCar = null;
            foreach (var car in Cars)
            {
                if (car.Id == id)
                {
                    WantedCar = car;
                }
            }
            return WantedCar;
        }
        public static List<Car>? GetAll()
        {
            return Cars;
        }
        public static void Add(Car car)
        {
            var IDList = Cars.Select(car => car.Id).ToList();
            var MaxID = IDList.Max();
            var newCar = new Car()
            {
                Id = MaxID,
                Make= car.Make,
                Model= car.Model,
                Year = car.Year,
                Color= car.Color,
            };
            Cars.Add(newCar);
        }
        public static void Update(Car car)
        {
            var UpdatedCar = GetById(car.Id);
            UpdatedCar!.Make = car.Make;
            UpdatedCar!.Model = car.Model;
            UpdatedCar!.Year = car.Year;
            UpdatedCar!.Color = car.Color;
        }
        public static void Delete(int id)
        {
            Cars.Remove(GetById(id));
        }
    }
}
