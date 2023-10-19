using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork6_2_
{
    class Human: Entity
    {
        public Human(string name) : base(name) { }
        int buckets_of_milk = 0;
        private Random rnd = new Random();

        public void Feed(Cow cow)
        {
            if (cow.Status == Entity.LiveStatus.Alive)
            {
                Console.WriteLine($"Вы покормили корову {cow.Name}");
                Console.WriteLine("Ваша энергия уменьшилась на 1");
                energy--;
                if (cow.Energy == 10)
                {
                    Console.WriteLine($"У коровы {cow.Name} уже максимальная энергия");
                }
                else
                {
                    Console.WriteLine($"Энергия коровы {cow.Name} увеличилась на 1");
                    cow.Energy++;
                }
            }
            else
            {
                Console.WriteLine($"Корова {cow.Name} мертва: ее нельзя покормить");
            }
        }
        public void Milk(Cow cow)
        {
            if (cow.Status == Entity.LiveStatus.Alive)
            {
                buckets_of_milk++;
                energy--;
                Console.WriteLine($"Вы получили ведро молока. Ведер молока: {buckets_of_milk}");
                cow.Energy--;
                Console.WriteLine("Ваша энергия уменьшилась на 1");
                if (cow.Energy == 0)
                {
                    Console.WriteLine($"Энергия коровы {cow.Name} опустилась до 0: она умерла");
                    cow.Status = LiveStatus.Died;
                }
                else
                {
                    Console.WriteLine($"Энергия коровы {cow.Name} уменьшилась на 1");
                }
            }
            else
            {
                Console.WriteLine($"Корова {cow.Name} мертва: ее нельзя доить");
            }
        }
        public void Breed(Bull bull, Cow cow, Dictionary<string, Calf> calfs)
        {
            if ((bull.Status == Entity.LiveStatus.Alive) && (cow.Status == Entity.LiveStatus.Alive) &&
                (bull.Energy >= 3) && (cow.Energy >= 3))
            {
                energy--;
                bull.Energy -= 3;
                cow.Energy -= 5;
                Console.WriteLine($"Вы развели животных. Ваша энергия понизилась на 1.\n" +
                    $"Энергия быка {bull.Name} быка уменьшилась на 3 и стала равна {bull.Energy}\n" +
                    $"Энергия коровы {cow.Name} уменьшилась на 5 и стала равна {cow.Energy}");
                if (bull.Energy == 0)
                {
                    Console.WriteLine($"Бык {bull.Name} умер сразу после спаривания");
                }
                if (cow.Energy == 0)
                {
                    Console.WriteLine($"Корова {cow.Name} умерла во время родов");
                }
                Console.Write("Как хотите назвать коровенка?: ");
                bool temp = true;
                while (temp)
                {
                    string name_calf = Console.ReadLine();
                    if (!name_calf.Equals(""))
                    {
                        calfs = new Dictionary<string, Calf>();
                        calfs.Add(name_calf, new Calf(name_calf, (Calf.Male)rnd.Next(0, 2)));
                        temp = false;
                    }
                    if (temp)
                    {
                        Console.WriteLine("Вы ввели пустую строку");
                    }
                }
            }
            else if (bull.Status != Entity.LiveStatus.Alive)
            {
                Console.WriteLine($"Бык {bull.Name} мертв, разведение невозможно");
            }
            else if (cow.Status != Entity.LiveStatus.Alive)
            {
                Console.WriteLine($"Корова {cow.Name} мертва, разведение невозможно");
            }
            else if (bull.Energy < 3)
            {
                Console.WriteLine($"Быку {bull.Name} не хватает энергии для спаривания");
            }
            else if (cow.Energy < 5)
            {
                Console.WriteLine($"Корове {bull.Name} не хватает энергии для родов");
            }
        }
    }
}
