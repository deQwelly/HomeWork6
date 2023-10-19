using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork6_1_
{
    public enum BankAccountType { current, saving }
    class BankAccount
    {
        private ulong number;
        private double balance;
        private BankAccountType type;
        static List<ulong> numbers = new List<ulong>();
        public ulong Number
        {
            get
            {
                return number;
            }
            set
            {
                if (!numbers.Contains(value))
                {
                    number = value;
                    numbers.Add(value);
                }
                else
                {
                    Console.WriteLine("Такой номер уже существует");
                }
            }
        }
        public double Balance
        {
            get
            {
                return balance;
            }
            set
            {
                balance = Math.Round(value, 2);
            }
        }
        public BankAccountType Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }
        /// <summary>
        /// Повзволяет снять деньги со счета
        /// </summary>
        /// <param name="sum"></param>
        public void TakeSomeMoney(double sum)
        {
            try
            {
                double temp = checked(balance - sum);
                if (temp > 0)
                {
                    balance = temp;
                }
                else
                {
                    Console.WriteLine("Недостаточно средств");
                }
            }
            catch (OverflowException)
            {
                Console.WriteLine("Нельзя списать такую большую сумму");
            }
        }
        /// <summary>
        /// Вносит деньги на счет
        /// </summary>
        /// <param name="sum"></param>
        public void DepositSomeMoney(double sum)
        {
            try
            {
                balance += checked(sum);
            }
            catch (OverflowException)
            {
                Console.WriteLine("Нельзя внести такую большую сумму");
            }
        }
    }
}
