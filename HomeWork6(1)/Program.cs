using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HomeWork6_1_
{
    internal class Program
    {
        /// <summary>
        /// Создает случайный номер банковского счета
        /// </summary>
        /// <param name="rnd"></param>
        /// <returns></returns>
        static ulong GenerateRandomAccountNumber(Random rnd)
        {
            return ulong.Parse(rnd.Next(1000, 9999).ToString() + rnd.Next(1000, 9999).ToString() +
                rnd.Next(1000, 9999).ToString() + rnd.Next(1000, 9999).ToString());
        }

        static void Main(string[] args)
        {
            //Упражнение 7.1
            Console.WriteLine("Упражнение 7.1: Создать класс счет в банке с закрытыми полями: номер счета, баланс, тип банковского счета");
            BankAccount account1 = new BankAccount();
            account1.Number = 1000_0000_0000_0000;
            account1.Balance = 111.111;
            account1.Type = BankAccountType.saving;
            Console.WriteLine($"Номер счета: {account1.Number}\n" +
                $"Баланс счета: {account1.Balance}\n" +
                $"Тип счета: {account1.Type}");
            
            //Упражнение 7.2
            Console.WriteLine("\nУпражнение 7.2: Изменить класс счет в банке из упражнения 7.1 таким образом, чтобы" +
                "\nномер счета генерировался сам и был уникальным.");
            Random rnd = new Random();

            BankAccount account2 = new BankAccount();
            account2.Number = GenerateRandomAccountNumber(rnd);
            account2.Balance = 123123.1234;
            account2.Type = BankAccountType.saving;

            BankAccount account3 = new BankAccount();
            account3.Number = GenerateRandomAccountNumber(rnd);
            account3.Balance = 145.1456;
            account3.Type = BankAccountType.current;

            Console.WriteLine($"Первый счет: Номер счета: {account2.Number} | Баланс счета: {account2.Balance} | " +
                $"Тип счета: {account2.Type} \nВторой счет: {account3.Number} | Баланс счета: {account3.Balance} | " +
                $"Тип счета: {account3.Type}");

            //Упражнение 7.3
            Console.WriteLine("\nДобавить в класс счет в банке два метода: снять со счета и положить на\r\n" +
                "счет. Метод снять со счета проверяет, возможно ли снять запрашиваемую сумму, и в случае\r\n" +
                "положительного результата изменяет баланс.");
            account3.TakeSomeMoney(120);
            account3.TakeSomeMoney(15);
            account2.TakeSomeMoney(10000000);
            account1.DepositSomeMoney(500);
            Console.WriteLine($"{account1.Balance} | {account2.Balance} | {account3.Balance}");

            //Домашнее задание 7.1
            Console.WriteLine("\nДомашнее задание 7.1 Реализовать класс для описания здания.\n" +
                "Добавить методы вычисления высоты этажа, количества квартир в подъезде, количества\r\n" +
                "квартир на этаже и т.д. Предусмотреть возможность, чтобы уникальный номер здания\r\nгенерировался программно.");
            List<Houses> houses = new List<Houses>();
            Console.Write("Сколько домов вы хотите создать: ");
            if (int.TryParse(Console.ReadLine(), out int houses_count))
            {
                for (int i = 0; i < houses_count; i++)
                {
                    Houses temp = new Houses((uint)rnd.Next(500, 1000), (uint)rnd.Next(150, 200), (uint)rnd.Next(400, 800), (uint)rnd.Next(1, 5));
                    Console.WriteLine($"Дом №{temp.Number} | Высота: {temp.Heigh} | Этажность: {temp.Storeys} | " +
                    $"Квартир: {temp.Appartments} | Подъездов: {temp.Entrances} | Высота этажа: {temp.ComputeFloorHeigh()} | " +
                    $"Квартир в подъезде: {temp.CountAppartmentsInEntrance()} | Квартир на этаже: {temp.CountAppartmentsInStorey()}");
                    houses.Add(temp);
                }

            }
            else
            {
                Console.WriteLine("Ошибка! Необходимо ввести только одно целое число");
            }
        }
    }
}
