using System;
using System.Collections.Generic;
using System.Text;


namespace Calculator
{
    public class Calculator
    {
        private string exp { get; set; }
        private int OPERAND_UPPER_BOUND = 1000;

        List<string> seperatorList = new List<string>();
        public const string SINGLE_CUSTOM_SEPERATOR = "\\n";
        public bool ALLOW_NEGATIVE = true;
      

        public Calculator(string value)
        {
            seperatorList.Add(",");
            exp = value;
     
        }

        public Calculator(string value, int value2)
        {
            seperatorList.Add(",");
            exp = value;
            OPERAND_UPPER_BOUND = value2;

        }


        public Calculator(string value, bool allowNeg)
        {
            seperatorList.Add(",");
            exp = value;
            ALLOW_NEGATIVE = allowNeg;

        }

        /// <summary>
        /// Requirement #1
        /// This method convert an expression into int array to perform calculation.  it only supports up to 2 parameters addition.
        /// </summary>
        /// <returns></returns>
        public List<int> convertExpWith2Params()
        {
            var paramArr = exp.Split(",");
            List<int> intList = new List<int>();

            if (paramArr.Length > 2)
                Console.WriteLine("ERROR : We only allow 2 parameters.  Explame 2,3 => 5");
       
            foreach(var x in paramArr)
            {
                int i = 0;
                bool result = int.TryParse(x, out i);
                if (result)
                    intList.Add(i);
                else
                    intList.Add(0);

            }
            return intList;

        }


        /// <summary>
        /// Requirement # 2
        /// </summary>
        /// <returns></returns>
        public List<int> convertExpToList()
        {
            List<int> intList = new List<int>();
            if (String.IsNullOrEmpty(exp))
            {
                intList.Add(0);
                return intList;
            }
            if (exp[0] == '/') // custome delimiter is used
            {
                int posOfEndMarker = exp.IndexOf("\\n");
                if (exp.Contains("["))   // support multiple delimiters are used   #6, #7, #8
                {
                    string sepList = exp.Substring(2, posOfEndMarker - 2);
                    var delimiterArr = sepList.Split(new char[] { '[', ']' });
                    for (int j=0; j < delimiterArr.Length; j++)
                    {
                        if (!String.IsNullOrEmpty(delimiterArr[j]))
                        {
                            seperatorList.Add(delimiterArr[j]);
                        }
                    }
                }
                else
                {
                    seperatorList.Add(exp.Substring(2, 1));
                }
                exp = exp.Substring(posOfEndMarker + 2);

            }
            else
            {
                exp = exp.Replace(SINGLE_CUSTOM_SEPERATOR, ",");      // #3
              //  exp = exp.Replace("\\n", ",");      // #3
            }
    
            var paramArr = exp.Split(seperatorList.ToArray(), 100, StringSplitOptions.RemoveEmptyEntries);

            List<int> negList = new List<int>();
            foreach (var x in paramArr)
            {
                int i = 0;
                bool result = int.TryParse(x, out i);
                if (result)
                {
                    if (i < 0 && !ALLOW_NEGATIVE)
                        negList.Add(i);         // #4
                    else if ( i <= OPERAND_UPPER_BOUND)       // #5
                            intList.Add(i);
                         else
                            intList.Add(0);
                }
                else
                    intList.Add(0);

            }
            if (negList.Count > 0)
                throw new NegativeNumberException(negList);  //#4

            return intList;

        }

        public int addNumbers()
        {
            int total = 0;
            //List<int> intArr = convertExpWith2Params();
            List<int> intArr = convertExpToList();
            string result = String.Empty;
            foreach (int x in intArr)
            {
                total += x;
                result += x.ToString() + "+";
            }
            result = result.Substring(0, result.Length - 1);  // remove the last +
            Console.WriteLine("{0} = {1}", result, total.ToString());
            return total;
        }


        // for debugging
        public void displayArr()
        {
            int cnt = 0;
            foreach(int x in convertExpWith2Params())
            {
                cnt++;
                Console.Write("The {0} number : ", cnt.ToString());
                Console.WriteLine(x.ToString());
            }

        }





    }
}
