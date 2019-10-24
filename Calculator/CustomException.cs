using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    public class NegativeNumberException : Exception
    {

        public NegativeNumberException(List<int> negList) : base()
        {
            Console.Write("ERROR : Found negative number(s) in the list - ");
            foreach(var x in negList)
            {
                Console.Write(x.ToString() + " ");
            }
           
        }

    }
}
