﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringTransformer.Tests
{
    [TestClass]
    public class IntMakerTests
    {
        [TestMethod]
        public void ConvertToInt_12345AsString_12345AsNumber()
        {
            //Arrange
            string sample = "12345";
            long expected = 12345;

            //Act
            IntMaker intMaker = new IntMaker();
            long actual = intMaker.ConvertToInt(sample);

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
