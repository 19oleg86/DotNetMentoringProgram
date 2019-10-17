﻿using System;

namespace StringTransformer
{
    public class IntMaker
    {
        public int ConvertToInt(string sourceString)
        {
            if (sourceString.Length == 0)
            {
                throw new EmptyStringException("The Input mustn't be empty");
            }
            for (int i = 0; i < sourceString.Length; i++)
            {
                if (sourceString[i] >= '0' && sourceString[i] <= '9' || sourceString[i] == '-')
                    continue;
                else
                {
                    throw new IncorrectFormatException("The Input must contain only digits from 0 to 9");
                }
            }
            int interimNumber = 0;
            char[] array = sourceString.ToCharArray();

            for (int i = 0; i < array.Length; i++)
                
                    if (array[array.Length - i - 1] == '-')
                    {
                        interimNumber *= -1;
                    }
                    else
                    {
                    checked
                    {
                        interimNumber += ((int)((array[array.Length - i - 1] - '0') * Math.Pow(10, i)));
                    }
                }
                

            if (interimNumber > int.MaxValue || interimNumber < int.MinValue)
            {
                throw new OverflowException();
            }
            return interimNumber;
        }
    }

    public class EmptyStringException : Exception
    {
        public EmptyStringException(string message) : base(message)
        { }
    }
    public class IncorrectFormatException : Exception
    {
        public IncorrectFormatException(string message) : base(message)
        { }
    }
}
