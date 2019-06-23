using System;

namespace DellChallenge.B
{
    class Program
    {
        static void Main(string[] args)
        {
            // Given the classes and interface below, please constructor the proper hierarchy.
            // Feel free to refactor and restructure the classes/interface below.
            // (Hint: Not all species and Fly and/or Swim)
        }
    }

    public interface ISpecies
    {
        void Eat();
        void Drink();
        void Fly();
        void Swim();
    }

    public class Species
    {
        private bool _alive = true;
        public bool Alive
        {
            get { return _alive; }
            set
            {
                _alive = value;
                if (!_alive)
                    Console.WriteLine("Oh no, you died!");
            }
        }

        private int _nutrition = 50;
        public int Nutrition
        {
            get { return _nutrition; }
            set
            {
                _nutrition = value;
                if (_nutrition <= 0)
                    Alive = false;
            }
        }

        private int _hydration = 50;
        public int Hydration
        {
            get { return _hydration; }
            set
            {
                _hydration = value;
                if (_hydration <= 0)
                    Alive = false;
            }
        }

        public virtual void GetSpecies()
        {
            Console.WriteLine($"Echo who am I?");
        }
    }

    public class Human : Species
    {
        public override void GetSpecies()
        {
            base.GetSpecies();
            Console.WriteLine("I am a human, a mammal and great ape. My closest relative is the chimpanzee. I am the only sentient species on Earth, and this planet is my domain.");
        }

        public void Drink()
        {
            if (!Alive)
                return;

            if (Hydration > 100)
            {
                Console.WriteLine("I'm good, don't need any water.");
                return;
            }

            Hydration += 20;
            Console.WriteLine("Ahh, refreshing.");
        }

        public void Eat()
        {
            if (!Alive)
                return;

            if (Nutrition > 100)
            {
                Console.WriteLine("No thanks, I'm full.");
                return;
            }

            Nutrition += 20;
            Console.WriteLine("Yum, tastes like chicken.");
        }

        public void Fly()
        {
            if (!Alive)
                return;

            Console.WriteLine("Uh oh, maybe jumping off a cliff was not a great idea.");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("*SPLAT*");
            Alive = false;
        }

        public void Swim()
        {
            if (!Alive)
                return;

            if (DateTime.Now.Month == 12 || DateTime.Now.Month == 1)
            {
                Console.WriteLine("Brrr, this water is freezing. Hypothermia is setting in.");
                Alive = false;
            }
            else
                Console.WriteLine("*splash* *splash*");
        }
    }

    public class Bird : Species
    {
        public override void GetSpecies()
        {
            base.GetSpecies();
            Console.WriteLine("CAW! CAW! CAW!");
        }

        public void Drink()
        {
            if (!Alive)
                return;

            if (Hydration > 100)
            {
                Console.WriteLine("caw!");
                return;
            }

            Hydration += 20;
            Console.WriteLine("*glub* *glub* *glub* Caaw!");
        }

        public void Eat()
        {
            if (!Alive)
                return;

            if (Nutrition > 100)
            {
                Console.WriteLine("Caaaw!");
                return;
            }

            Nutrition += 20;
            Console.WriteLine("*catches a mouse and eats it* Caw! Caw!");
        }

        public void Fly()
        {
            if (!Alive)
                return;

            Console.WriteLine("*flap* *flap* *flap* Caw! Caw!");
        }

        public void Swim()
        {
            if (!Alive)
                return;

            Console.WriteLine("*frantically splashing*");
            System.Threading.Thread.Sleep(1000);
            Alive = false;
        }
    }

    public class Fish : Species
    {
        public override void GetSpecies()
        {
            base.GetSpecies();
            Console.WriteLine("*glub glub glub*");
        }

        public void Drink()
        {
            if (!Alive)
                return;

            if (Hydration > 100)
            {
                Console.WriteLine("*glubglub*");
                return;
            }

            Hydration += 20;
            Console.WriteLine("*glubglubglub*");
        }

        public void Eat()
        {
            if (!Alive)
                return;

            if (Nutrition > 100)
            {
                Console.WriteLine("*glubglub*");
                return;
            }

            Nutrition += 20;
            Console.WriteLine("*munches plankton*");
        }

        public void Fly()
        {
            if (!Alive)
                return;

            Console.WriteLine("*jumps out of the water and swings its tail*");
            System.Threading.Thread.Sleep(500);
            Console.WriteLine("*bird happens to fly by and catches it*");
            System.Threading.Thread.Sleep(500);
            Alive = false;
        }

        public void Swim()
        {
            if (!Alive)
                return;

            Console.WriteLine("*swoosh swoosh swoosh*");
        }
    }
}

