using System;
using System.Threading.Channels;

namespace Interfaces
{
    class Program
    {
        public static void Main()
        {
            //SimpleGreeter simpleGreeter = new SimpleGreeter();
            //simpleGreeter.Greet();

            //IGreeter greeter = new SimpleGreeter();
            //greeter.Greet();

            IGreeter greeter = new NormalGreeter();
            greeter.Greet();

            greeter = new LoudGreeter();
            greeter.Greet();
        }
    }

    public interface IGreeter
    {
        void Greet();
    }

    class SimpleGreeter : IGreeter
    {
        public void Greet()
        {
            Console.WriteLine("Hello from Simple Greet");
        }
    }

    class NormalGreeter : IGreeter 
    { 
        public void Greet()
        {
            Console.WriteLine("Hello from NormalGreeter");
        }
    }

    class LoudGreeter : IGreeter
    {
        public void Greet()
        {
            Console.WriteLine("HELLO FROM LOUDGREETER");
        }
    }
}