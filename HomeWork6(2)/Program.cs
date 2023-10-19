using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HomeWork6_2_
{
    internal class Program
    {
        public static void ShowCows(Dictionary<string, Cow> cows)
        {
            Console.WriteLine();
            foreach (string k in cows.Keys)
            {
                Console.WriteLine($"{k} - {cows[k].Energy} энергии");
            }
            Console.WriteLine();
        }

        public static void ShowCalfs(Dictionary<string, Calf> calfs)
        {
            Console.WriteLine();
            foreach (string k in calfs.Keys)
            {
                Console.WriteLine(k);
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в коровник!");
            Console.Write("Введите имя персонажа: ");
            Human human = new Human(Console.ReadLine());
            if (!human.Name.Equals(""))
            {
                Console.WriteLine("У вашего персонажа 10 энергии. Любые действия тратят энергию. Персонаж ест - восполняет энергию\n" +
                "Коровы в коровнике так же имеют по 10 энергии каждая\n" +
                "Доить коров - значит тратить и энергию персонажа, и энергию коровы\n" +
                "Если энергия персонажа или коровы упадет до 0, он или она умирает\n" +
                "Помимо коров в коровнике есть 1 бык для разведения. Операция разведения тратит 5 энергии у выбранной коровы и 3 у быка\n" +
                "Раз в 7 ходов бык начинает двигаться и тратит единицу энергии. Успевайте кормить его вовремя!\n" +
                "Смерть персонажа или всех коров означает завершение игры");

                /*List<Cow> cows = new List<Cow>();
                cows.Add(new Cow("Ромашка"));
                cows.Add(new Cow("Василиса"));
                cows.Add(new Cow("Жучка"));
                cows.Add(new Cow("Маргоша"));*/

                Bull bull = new Bull("Бакенбард");
                Dictionary<string, Calf> calfs = new Dictionary<string, Calf>();
                Dictionary<string, Cow> cows = new Dictionary<string, Cow>();
                cows.Add("Ромашка", new Cow("Ромашка"));
                cows.Add("Василиса", new Cow("Василиса"));
                cows.Add("Жучка", new Cow("Жучка"));
                cows.Add("Маргоша", new Cow("Маргоша"));
                Console.WriteLine("Ваши коровы: ");
                ShowCows(cows);

                bool temp = true;
                string action;
                int action_count = 0;
                while (temp)
                {
                    if ((action_count == 7) && (bull.Status == Entity.LiveStatus.Alive))
                    {
                        Console.WriteLine();
                        bull.Move();
                        if (bull.Energy == 0)
                        {
                            Console.WriteLine($"Бык {bull.Name} умер");
                        }
                        else
                        {
                            Console.WriteLine($"Энергия быка {bull.Name} - {bull.Energy}");
                            Console.WriteLine();
                        }
                    }
                    /*
                    if (action_count == 10)
                    {
                        if (calfs.Count != 0)
                        {
                            foreach (string k in calfs.Keys)
                            {
                                if (calfs[k].Status == Entity.LiveStatus.Alive)
                                {
                                    Console.WriteLine();
                                    calfs[k].Move();
                                    Console.WriteLine();
                                }
                            }
                            ShowCalfs(calfs);
                        }
                    }
                    */
                    Console.WriteLine("Введите действие: (Введите 'помощь', если хотите ознакомиться со списком действий)");
                    if (human.Status == Entity.LiveStatus.Alive)
                    {
                        action = Console.ReadLine();
                        if (action.ToLower().Equals("помощь"))
                        {
                            Console.WriteLine("\tИдти - чтобы идти\n" +
                                "\tПоесть - чтобы поесть\n" +
                                "\tКормить - чтобы кормить коров\n" +
                                "\tДоить - чтобы доить коров\n" +
                                "\tМолоко - чтобы узнать, сколько ведер молока вы надоили\n" +
                                "\tРазводить - чтобы разводить коров\n" +
                                "\tСостояние коров - чтобы узнать энергию всех коров\n" +
                                "\tСостояние быка - чтобы узнать энергию быка\n" +
                                "\tСписок коровят - получить список коровят (телят)" +
                                "\tПомощь - вывести список комманд\n" +
                                "\tЗакрыть - завершить игру");
                        }
                        else if (action.ToLower().Equals("закрыть"))
                        {
                            temp = false;
                        }
                        else if (action.ToLower().Equals("состояние коров"))
                        {
                            ShowCows(cows);
                        }
                        else if (action.ToLower().Equals("состояние быка"))
                        {
                            Console.WriteLine($"Энергия быка {bull.Name} - {bull.Energy}");
                        }
                        else if (action.ToLower().Equals("список коровят"))
                        {
                            ShowCalfs(calfs);
                        }
                        else if (action.ToLower().Equals("идти"))
                        {
                            human.Move();
                            Console.WriteLine($"| Количество энергии: {human.Energy} |");
                            action_count++;
                        }
                        else if (action.ToLower().Equals("поесть"))
                        {
                            human.Eat();
                            Console.WriteLine($"| Количество энергии персонажа: {human.Energy} |");
                            action_count++;
                        }
                        else if (action.ToLower().Equals("кормить"))
                        {
                            ShowCows(cows);
                            Console.Write("Выберите, какую корову хотите покормить (соблюдайте регистр): ");
                            bool temp2 = true;
                            while (temp2)
                            {
                                string cow = Console.ReadLine();
                                if (cows.Keys.Contains(cow))
                                {
                                    human.Feed(cows[cow]);
                                    Console.WriteLine($"| Количество энергии персонажа: {human.Energy} |");
                                    temp2 = false;
                                }
                                if (temp2)
                                {
                                    Console.WriteLine("Неправильный вводд имени");
                                }
                            }
                            action_count++;
                        }
                        else if (action.ToLower().Equals("доить"))
                        {
                            ShowCows(cows);
                            Console.Write("Выберите, какую корову хотите подоить: ");
                            bool temp2 = true;
                            while (temp2)
                            {
                                string cow = Console.ReadLine();
                                if (cows.Keys.Contains(cow))
                                {
                                    human.Milk(cows[cow]);
                                    Console.WriteLine($"| Количество энергии персонажа: {human.Energy} |");
                                    temp2 = false;
                                }
                                if (temp2)
                                {
                                    Console.WriteLine("Неправильный ввод имени");
                                }
                            }
                            action_count++;
                        }
                        else if (action.ToLower().Equals("разводить"))
                        {
                            ShowCows(cows);
                            Console.Write("Выберите, какую корову хотите подоить: ");
                            bool temp2 = true;
                            while (temp2)
                            {
                                string cow = Console.ReadLine();
                                if (cows.Keys.Contains(cow))
                                {
                                    human.Breed(bull, cows[cow], calfs);
                                    Console.WriteLine($"| Количество энергии персонажа: {human.Energy} |");
                                    temp2 = false;
                                }
                                if (temp2)
                                {
                                    Console.WriteLine("Неправильный ввод имени");
                                }
                            }
                            action_count++;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{human.Name} умер. Игра завершилась");
                        Thread.Sleep(3000);
                        temp = false;
                    }
                }
            }
            else
            {
                Console.WriteLine("Пустое имя персонажа");
            }
        }
    }
}
