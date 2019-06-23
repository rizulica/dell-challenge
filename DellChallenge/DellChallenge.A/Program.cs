using System;

namespace DellChallenge.A
{
    class Program
    {
        static void Main(string[] args)
        {
            // State and explain console output order.
            new B();
            Console.ReadKey();

            /*
            Line 1: A.A()
            Class 'B' inherits class 'A'. When a new instance of `B` is initialized, the constructor of 'A' will be called first. This constructor calls 'Console.WriteLine("A.A()");', which is what is outputted first.

            Line 2: B.B()
            After the constructor of the parent class is called, the constructor of the child class, 'B', follows. This constructor calls 'Console.WriteLine("B.B()");', which is outputted second.

            Line 3: A.Age
            The code to output this text is inside the setter of the 'Age' property of the 'A' class. After line 2 is outputted from B's constructor, 'Age = 0;' is executed.
            Since the Age property is inherited by B from its parent class, A, setting a new value will access the property's setter, which contains 'Console.WriteLine("A.Age");'.
            */
        }
    }

    class A
    {
        private int _age;
        public int Age
        {
            get { return _age; }
            set
            {
                _age = value;
                Console.WriteLine("A.Age");
            }
        }


        public A()
        {
            Console.WriteLine("A.A()");
        }
    }

    class B : A
    {
        public B()
        {
            Console.WriteLine("B.B()");
            Age = 0;
        }
    }
}
