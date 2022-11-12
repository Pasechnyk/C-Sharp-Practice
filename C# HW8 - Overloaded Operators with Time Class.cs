using System;

namespace Time
{
    // Task - create Time class using overloaded operators
    public class Time
    {
        // properties
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }

        // constructors
        public Time() { }
        public Time(int hour, int minute, int second)
        {
            Hours = hour;
            Minutes = minute;
            Seconds = second;
        }

        // turn the seconds into hh:mm:ss
        public Time(int second)
        {
            Hours = second / 3600;
            Minutes = (second - Hours * 3600) / 60;
            Seconds = second - Hours * 3600 - Minutes * 60;
        }

        // operators
        public static Time operator ++(Time t)
        {
            if (t.Seconds < 59)
            {
                t.Seconds += 1;
            }
            else { t.Seconds = 00; t.Minutes += 1; }
            return t;
        }
        public static Time operator --(Time t)
        {
            if (t.Seconds > 00)
            {
                t.Seconds -= 1;
            }
            else { t.Seconds = 59; t.Minutes -= 1; }
            return t;
        }

        // > >= <= <
        public static bool operator >(Time left, Time right)
        {
            return left.Hours > right.Hours;
        }
        public static bool operator <(Time left, Time right)
        {
            return !(left.Hours > right.Hours);
        }
        public static bool operator >=(Time left, Time right)
        {
            return left.Hours >= right.Hours;
        }
        public static bool operator <=(Time left, Time right)
        {
            return !(left.Hours >= right.Hours);
        }

        // equals operator with hash code
        public override bool Equals(object obj)
        {
            return obj is Time t && Hours == t?.Hours;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Hours);
        }
        public static bool operator ==(Time left, Time right)
        {
            return left.Equals(right);
        }
        public static bool operator !=(Time left, Time right)
        {
            return !(left == right);
        }

        // ariphmetic operators + and -
        public static Time operator +(Time left, Time right)
        {
            Time t = new(left.Hours, right.Minutes)
            {
                Seconds = left.Seconds + right.Seconds
            };
            return t;
        }
        public static Time operator -(Time left, Time right)
        {
            Time t = new(left.Hours, right.Minutes)
            {
                Seconds = left.Seconds - right.Seconds
            };
            return t;
        }

        // methods
        public void ShowTime()
        {
            Console.WriteLine($"Your given time is {Hours}:{Minutes}:{Seconds}");
        }
        public void Reset()
        {
            Hours = 0;
            Minutes = 0;
            Seconds = 0;

            Console.WriteLine("Time has benn reset!");
            Console.WriteLine($"Reset time - {Hours}:{Minutes}:{Seconds}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Time t1 = new Time(14, 26, 02);
            ++t1;
            t1.ShowTime();

            Time t2 = new Time(2966);
            t2.ShowTime();

            Time t3 = t1 + t2;
            t3.ShowTime();

            if (t1 > t2)
            {
                Console.WriteLine("Time 1 has bigger hour value than Time 2!");
            }

            if (t1 == t2)
            {
                Console.WriteLine("Time 1 and Time 2 are equal!");
            }

            t2.Reset();
        }
    }
}
