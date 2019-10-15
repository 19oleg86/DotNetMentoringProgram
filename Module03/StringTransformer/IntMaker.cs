using System;

namespace StringTransformer
{
    public class IntMaker
    {
        public long CovertToInt(string sourceString)
        {
            if (sourceString.Length == 0)
            {
                throw new EmptyStringExc("The Input mustn't be empty");
            }
            for (int i = 0; i < sourceString.Length; i++)
            {
                if (sourceString[i] >= '0' && sourceString[i] <= '9')
                    continue;
                else
                {
                    throw new IncorrectFormatExc("The Input must contain only digits from 0 to 9");
                }
            }
            long interimNumber = Convert.ToInt64(sourceString);
            if (interimNumber > 2147483647 || interimNumber < -2147483648)
            {
                throw new TypeOverFlowExc("Your number too big, it must be between -2 147 483 648 and  2 147 483 647");
            }
            return interimNumber;
        }
    }

    public class EmptyStringExc : Exception
    {
        public EmptyStringExc(string message) : base(message)
        {}
    }
    public class IncorrectFormatExc : Exception
    {
        public IncorrectFormatExc(string message) : base(message)
        {}
    }
    public class TypeOverFlowExc : Exception
    {
        public TypeOverFlowExc(string message) : base(message) 
        {}
    }
}
