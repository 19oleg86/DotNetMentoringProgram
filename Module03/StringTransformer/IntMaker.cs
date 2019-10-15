using System;

namespace StringTransformer
{
    public class IntMaker
    {
        public long CovertToInt(string sourceString)
        {
            if (sourceString.Length == 0)
            {
                throw new EmptyStringException("The Input mustn't be empty");
            }
            for (int i = 0; i < sourceString.Length; i++)
            {
                if (sourceString[i] >= '0' && sourceString[i] <= '9')
                    continue;
                else
                {
                    throw new IncorrectFormatException("The Input must contain only digits from 0 to 9");
                }
            }
            long interimNumber = Convert.ToInt64(sourceString);
            if (interimNumber > int.MaxValue || interimNumber < int.MinValue)
            {
                throw new TypeOverFlowException("Your number is too big, it must be between -2 147 483 648 and  2 147 483 647");
            }
            return interimNumber;
        }
    }

    public class EmptyStringException : Exception
    {
        public EmptyStringException(string message) : base(message)
        {}
    }
    public class IncorrectFormatException : Exception
    {
        public IncorrectFormatException(string message) : base(message)
        {}
    }
    public class TypeOverFlowException : Exception
    {
        public TypeOverFlowException(string message) : base(message) 
        {}
    }
}
