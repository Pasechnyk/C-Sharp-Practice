using System;

namespace Musical_Instruments
{
    // Task - create Instrument hierarchy with inheritance using abstract class
    public enum Category { Woodwind, Brass, String, Keyboard, Percussion}
    public abstract class Instrument
    {
        // properties
        public string Name { get; set; }
        public Category Type { get; set; }
        public string Model { get; set; }

        // contructors
        public Instrument() { }
        public Instrument(string name, Category type, string model)
        {
            Name = name;
            Type = type;
            Model = model;
        }

        // abstract methods
        public abstract void Play();
        public abstract void SpecialInfo();
    }

    public class Piano : Instrument
    {
        // property
        public int Octaves { get; set; }

        // contructors
        public Piano() { }
        public Piano (string name, Category type, string model, int octave) : base (name, type, model)
        {
            Octaves = octave;
        }

        // override methods
        public override void Play()
        {
            Console.WriteLine("You've used the keyboard on the piano!");
        }
        public override void SpecialInfo()
        {
            Console.WriteLine($"This instrument has {Octaves} octaves!");
        }
    }

    public class Violin : Instrument
    {
        // properties
        public string Materials { get; set; }

        // contructors
        public Violin() { }
        public Violin(string name, Category type, string model, string materials) : base(name, type, model)
        {
            Materials = materials;
        }

        // override methods
        public override void Play()
        {
            Console.WriteLine("You've used the strings on the violin!");
        }
        public override void SpecialInfo()
        {
            Console.WriteLine($"This instrument is made out of {Materials}!");
        }
    }
    public class Trumpet : Instrument
    {
        // property
        public string TrumpetType { get; set; }

        // contructors
        public Trumpet() { }
        public Trumpet(string name, Category type, string model, string tType) : base(name, type, model)
        {
            TrumpetType = tType;
        }

        // override methods
        public override void Play()
        {
            Console.WriteLine("You've used the brass on the trumpet!");
        }
        public override void SpecialInfo()
        {
            Console.WriteLine($"This instrument is of {TrumpetType} type!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // initialize intruments

            Piano piano = new Piano("Yamaha", Category.Keyboard, "JU7225", 8);
            piano.Play();
            piano.SpecialInfo();

            Violin violin = new Violin("Eastar", Category.String, "UO85", "Acacia");
            violin.Play();
            violin.SpecialInfo();

            Trumpet trumpet = new Trumpet("Yamaha", Category.Brass, "B Trumpet", "B-flat");
            trumpet.Play();
            trumpet.SpecialInfo();
        }
    }
}
