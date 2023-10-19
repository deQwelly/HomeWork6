using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork6_2_
{
    abstract class Entity
    {
        public enum LiveStatus { Alive, Died }

        protected string name;
        protected byte energy = 10;
        protected LiveStatus status = LiveStatus.Alive;

        public string Name
        {
            get
            {
                return name;
            }
        }
        public byte Energy
        {
            get
            {
                return energy;
            }
            set
            {
                energy = value;
            }
        }
        
        public LiveStatus Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
            }
        }

        public void Eat()
        {
            if (status == LiveStatus.Alive)
            {
                Console.WriteLine($"{name} ест");
                if (energy < 10)
                {
                    energy++;
                    Console.WriteLine("Энергия увеличилась на 1");
                }
                else
                {
                    Console.WriteLine("Энергия уже на максимуме");
                }
            }
            else
            {
                Console.WriteLine($"{name} умер, он не может есть");
            }
        }
        public void Move()
        {
            if (status == LiveStatus.Alive)
            {
                Console.WriteLine($"{name} движется");
                energy--;
                if (energy == 0)
                {
                    Console.WriteLine($"{name} умер");
                    status = LiveStatus.Died;
                }
                else
                {
                    Console.WriteLine("Энергия уменьшилась на 1");
                }
            }
            else
            {
                Console.WriteLine($"{name} умер, он не может ходить");
            }
            
        }
        public Entity(string name)
        {
            this.name = name;
        }
    }
}
