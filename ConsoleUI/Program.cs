﻿using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //InMemoryTest();

            CarTest();

        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            carManager.Add(new Car() { Description = "nisan suv", BrandId = 4, ColorId = 3, DailyPrice = 15000, ModelYear = "2015" });

            foreach (var item in carManager.GetCarDetails())
            {
                Console.WriteLine("{0} {1} {2}  {3:0.00}$", item.Description, item.ColorName, item.BrandName, item.DailyPrice);
            }
            Console.WriteLine("Execute successfuly ended");
        }

        static void InMemoryTest()
        {
            //manager ve database oluşturma
            CarManager carManager = new CarManager(new InMemoryCarDal());
            Listele(carManager);

            //silme işlemi
            carManager.Delete(new Car() { Id = 2 });
            Listele(carManager);

            //güncelleme
            carManager.Update(new Car() { Id = 1, Description = "nisan suv", BrandId = 1, ColorId = 10, DailyPrice = 15000, ModelYear = "2015" });
            Listele(carManager);

            //ekleme
            carManager.Add(new Car() { Id = 5, Description = "mercedes suv", BrandId = 1, ColorId = 10, DailyPrice = 15000, ModelYear = "2015" });
            Listele(carManager);

                
        }
        static void Listele(CarManager carManager)
        {
            foreach (var item in carManager.GetAll())
            {
                Console.WriteLine(item.Description);
            }
            Console.WriteLine("Execute successfuly ended");
        }

    }
}
