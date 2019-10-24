using System;
using Xunit;
using Calculator;



namespace TestCalculator
{
    public class UnitTest1
    {
        [Fact]
        public void AddSingle()
        {

            // Arrange  -- setup 

            string oneOperand           = "20";
            var c = new Calculator.Calculator(oneOperand);

            //string twoOperands          = "1,5000";
            //string twoOperansWithNegNum = "4,-3";
            //string eString              = String.Empty;
            //string numAndInvalidOperand = "5,tytyt";
            //string listOfNumbers        = "1,2,3,4,5,6,7,8,9,10,11,12";
            //string strWithNewLine = "1\n2,3";
            //string negNumExp = "4,-3";
            //string strWithValueGT1000 = "2,1001,6";
            //string oneDelimiter = "//#\n2#5";
            //string oneDelimiterWithLengthGTOne = "//[***]\n11***22***33";
            //string multiDelimiters = "//[*][!!][r9r]\n11r9r22*hh*33!!44";


   
            var result = c.addNumbers();

            // Assert   -- Make sure, as many as I want
            Assert.Equal(20, result);

        }

        [Fact]
        public void Add2WithOverwrtingUpperBound()
        {

            // Arrange  -- setup 


            string twoOperands = "1,5000";
            var c = new Calculator.Calculator(twoOperands, 6000);
            //string twoOperansWithNegNum = "4,-3";
            //string eString = String.Empty;
            //string numAndInvalidOperand = "5,tytyt";
            //string listOfNumbers = "1,2,3,4,5,6,7,8,9,10,11,12";
            //string strWithNewLine = "1\n2,3";
            //string negNumExp = "4,-3";
            //string strWithValueGT1000 = "2,1001,6";
            //string oneDelimiter = "//#\n2#5";
            //string oneDelimiterWithLengthGTOne = "//[***]\n11***22***33";
            //string multiDelimiters = "//[*][!!][r9r]\n11r9r22*hh*33!!44";


            // Act
            var result = c.addNumbers();

            // Assert   -- Make sure, as many as I want
            Assert.Equal(5001, result);

        }

        [Fact]
        public void AddWithNegNumber()
        {

            // Arrange  -- setup 
          
            string twoOperansWithNegNum = "4,-3";
            var c = new Calculator.Calculator(twoOperansWithNegNum);
   
            // Act
            var result = c.addNumbers();

            // Assert   -- Make sure, as many as I want
            Assert.Equal(1,result);

        }

        [Fact]
        public void AddWithEmptyString()
        {

            // Arrange  -- setup 
          
            string eString = String.Empty;
            var c = new Calculator.Calculator(eString);
         
            // Act
            var result = c.addNumbers();

            // Assert   -- Make sure, as many as I want
            Assert.Equal(0, result);

        }

        [Fact]
        public void AddnumAndInvalidOperand()
        {

            // Arrange  -- setup 
            string numAndInvalidOperand = "5,tytyt";
            var c = new Calculator.Calculator(numAndInvalidOperand);
          
            // Act
            var result = c.addNumbers();

            // Assert   -- Make sure, as many as I want
            Assert.Equal(5, result);

        }

        [Fact]
        public void AddlistOfNumbers()
        {

            // Arrange  -- setup 
   
            string listOfNumbers = "1,2,3,4,5,6,7,8,9,10,11,12";
            var c = new Calculator.Calculator(listOfNumbers);
  
            // Act
            var result = c.addNumbers();

            // Assert   -- Make sure, as many as I want
            Assert.Equal(78, result);

        }

        [Fact]
        public void AddstrWithNewLine()
        {

            // Arrange  -- setup 
           
            string strWithNewLine = @"1\n2,3";
            var c = new Calculator.Calculator(strWithNewLine);
       
            // Act
            var result = c.addNumbers();

            // Assert   -- Make sure, as many as I want
            Assert.Equal(6, result);

        }

        [Fact]
        public void AddnegNumExp()
        {

            // Arrange  -- setup 
            string negNumExp = "4,-3";
            var c = new Calculator.Calculator(negNumExp, false);
            // Act
           // var result = c.addNumbers();

            // Assert   -- Make sure, as many as I want
            Assert.Throws<NegativeNumberException>(() => c.addNumbers());

        }

        [Fact]
        public void AddstrWithValueGT1000()
        {

            // Arrange  -- setup 
            string strWithValueGT1000 = "2,1001,6";
            var c = new Calculator.Calculator(strWithValueGT1000);
            //string oneDelimiter = "//#\n2#5";
            //string oneDelimiterWithLengthGTOne = "//[***]\n11***22***33";
            //string multiDelimiters = "//[*][!!][r9r]\n11r9r22*hh*33!!44";


            // Act
            var result = c.addNumbers();

            // Assert   -- Make sure, as many as I want
            Assert.Equal(8, result);

        }

        [Fact]
        public void AddoneDelimiter()
        {

            // Arrange  -- setup 
                 
            string oneDelimiter = @"//#\n2#5";
            var c = new Calculator.Calculator(oneDelimiter);
          
            // Act
            var result = c.addNumbers();

            // Assert   -- Make sure, as many as I want
            Assert.Equal(7, result);

        }

        [Fact]
        public void AddoneDelimiterWithLengthGTOne()
        {

            // Arrange  -- setup 
               
            string oneDelimiterWithLengthGTOne = @"//[***]\n11***22***33";
            var c = new Calculator.Calculator(oneDelimiterWithLengthGTOne);
     

            // Act
            var result = c.addNumbers();

            // Assert   -- Make sure, as many as I want
            Assert.Equal(66, result);

        }

        [Fact]
        public void AddmultiDelimiters()
        {

            // Arrange  -- setup 

            
            string multiDelimiters = @"//[*][!!][r9r]\n11r9r22*hh*33!!44";
            var c = new Calculator.Calculator(multiDelimiters);

            // Act
            var result = c.addNumbers();

            // Assert   -- Make sure, as many as I want
            Assert.Equal(110, result);

        }


 


    }
}
