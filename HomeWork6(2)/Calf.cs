using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork6_2_
{
    class Calf: Cow
    {
        public enum Male { Male, Female }

        private Male male;

        public Calf(string name, Male male) : base(name) 
        { 
            this.male = male;
        }

    }
}
