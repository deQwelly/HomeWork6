using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork6_1_
{
    class Houses
    {
        static uint current_free_number = 0;
        private uint number;
        private uint heigh;
        private uint storeys;
        private uint appartments;
        private uint entrances;

        public uint Number
        {
            get
            {
                return number;
            }
        }
        public uint Heigh
        {
            get
            {
                return heigh;
            }
            set
            {
                heigh = value;
            }
        }
        public uint Storeys
        {
            get
            {
                return storeys;
            }
            set
            {
                storeys = value;
            }
        }
        public uint Appartments
        {
            get
            {
                return appartments;
            }
            set
            {
                appartments = value;
            }
        }
        public uint Entrances
        {
            get
            {
                return entrances;
            }
            set
            {
                entrances = value;
            }
        }

        public Houses(uint heigh, uint storeys, uint appartments, uint entrances)
        {
            current_free_number += 1;
            number = current_free_number;
            this.heigh = heigh;
            this.storeys = storeys;
            this.appartments = appartments;
            this.entrances = entrances;
        }

        public float ComputeFloorHeigh()
        {
            return (heigh / storeys);
        }
        
        public int CountAppartmentsInEntrance()
        {
            return (int)(appartments / Entrances);
        }

        public int CountAppartmentsInStorey()
        {
            return (int)(appartments / storeys);
        }

    }
}
