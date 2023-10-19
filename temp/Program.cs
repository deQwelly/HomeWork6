using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace temp
{
    class Houses
    {
        private uint number;
        private uint heigh;
        private uint storeys;
        private uint appartments;
        private uint entrances;

        public Houses(uint number, uint heigh, uint storeys, uint appartments, uint entrances)
        {
            this.number = number;
            this.heigh = heigh;
            this.storeys = storeys;
            this.appartments = appartments;
            this.entrances = entrances;
        }

        public uint Number { get { return number; } }
        public uint Heigh { get {  return heigh; } }
        public uint Storeys { get {  return storeys; } }
        public uint Appartments { get { return appartments; } }
        public uint Entrances { get {  return entrances; } }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Houses house = new Houses(1, 1000, 10, 150, 5);
            Console.WriteLine(house.Number);
            Random rnd = new Random();
            Console.WriteLine();
            Console.WriteLine(rnd.Next(0, 2));
        }
    }
}
