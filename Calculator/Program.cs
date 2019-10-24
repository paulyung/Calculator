using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            //  Calculator c = new Calculator();

            // ConsoleKeyInfo cki;
            string exp;
            do
            {
                //   Console.Write("Enter the string (2 Params) : ");

                
                Console.Write("Enter the string (No limit) : ");

               // cki = Console.ReadKey(true);
              //  Console.WriteLine($"  Key pressed: {cki.Key}\n");

                exp = Console.ReadLine();

                if (exp == "END")
                {
                    Console.WriteLine("Thank you for uisng the calculator.");
                    break;
                }
                // c.displayArr();
                Calculator c = new Calculator(exp);
                c.addNumbers();
            } while (exp != "END");



            //while (c.exp != "END")
            //{
            //    Console.Write("Enter the string : ");
            //    c.exp = Console.ReadLine();
            //    
            //}

            
        }
    }
}
