using System;
using static System.Console;

namespace _009_Csharp_OperatorOverloading_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //1. Написать класс Money, предназначенный для хранения денежной суммы (в гривнах и копейках). Для класса реализовать
            //перегрузку операторов + (сложение денежных сумм), – (вычитание сумм), / (деление суммы на целое число), * (умножение
            //суммы на целое число), ++ (сумма увеличивается на 1 копейку), -- (сумма уменьшается на 1 копейку), ==, !=. Программа 
            //должна с помощью меню продемонстрировать все возможности класса Money.

            Money m1 = new Money(1, 50);
            Money m2 = new Money(0, 70);
            WriteLine("1,50 - 0,70 = " + (m1 - m2));
            WriteLine($"{m1} * 3 = " + (m1 * 3));
            WriteLine($"{m1} / {5} = " + (m1 / 5));
            WriteLine("1,50 == 0,70 " + (m1 == m2));
        }
    }
    class Money
    {
        int grn, kop;
        public Money() { }
        public Money(int grn, int kop)
        {
            this.grn = grn;
            this.kop = kop;
        }
        public int Grn { get { return this.grn; } set { this.grn = value; } }
        public int Kop { get { return this.kop; } set { this.kop = value; } }
        public override string ToString()
        {
            return $"{this.grn} грн {this.kop} коп";
        }
        public override bool Equals(object obj)
        {
            return this.ToString() == obj.ToString();
        }
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
        public static bool operator ==(Money obj1, Money obj2)
        {
            return obj1.Equals(obj2);
        }
        public static bool operator !=(Money obj1, Money obj2)
        {
            return !(obj1 == obj2);
        }
        public static Money operator +(Money obj1, Money obj2)
        {

            if ((obj1.Kop + obj2.Kop) > 99)
            {
                Money obj = new Money();
                obj.Kop = (obj1.Kop + obj2.Kop) - 100;
                obj.Grn = obj1.Grn + obj2.Grn + 1;
                return obj;
            }
            else
                return new Money { Grn = obj1.Grn + obj2.Grn, Kop = obj1.Kop + obj2.Kop };
        }
        public static Money operator -(Money obj1, Money obj2)
        {

            if ((obj1.Kop - obj2.Kop) < 0)
            {
                Money obj = new Money();
                obj.Kop = (obj1.Kop - obj2.Kop) + 100;
                obj.Grn = obj1.Grn - obj2.Grn - 1;
                return obj;
            }
            else
                return new Money { Grn = obj1.Grn - obj2.Grn, Kop = obj1.Kop - obj2.Kop };
        }
        public static Money operator *(Money obj, int num)
        {
            int res = (obj.Grn * 100 + obj.Kop) * num;
            obj.Grn = res / 100;
            obj.Kop = res % 100;
            return obj;
        }
        public static Money operator /(Money obj, int num)
        {
            int res = (obj.Grn * 100 + obj.Kop) / num;
            obj.Grn = res / 100;
            obj.Kop = res % 100;
            return obj;
        }

        public static Money operator ++(Money obj)
        {
            obj.Kop++;
            if (obj.Kop > 99)
            {
                obj.Kop -= 100;
                obj.Grn++;
                return obj;
            }
            else
                return obj;
        }
        public static Money operator --(Money obj)
        {
            obj.Kop--;
            if (obj.Kop < 0)
            {
                obj.Kop += 100;
                obj.Grn--;
                return obj;
            }
            else
                return obj;
        }
    }
}
