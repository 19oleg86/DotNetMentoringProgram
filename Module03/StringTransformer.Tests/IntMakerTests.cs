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

        [TestMethod]
        public void ConvertToInt_ZeroIn_ZeroOut()
        {
            //Arrange
            string sample = "0";
            long expected = 0;

            //Act
            IntMaker intMaker = new IntMaker();
            long actual = intMaker.ConvertToInt(sample);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConvertToInt_NegativeIn_NegativeOut()
        {
            //Arrange
            string sample = "-15";
            long expected = -15;

            //Act
            IntMaker intMaker = new IntMaker();
            long actual = intMaker.ConvertToInt(sample);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConvertToInt_MinimumIn_MinimumOut()
        {
            //Arrange
            string sample = "-2147483648";
            long expected = -2147483648;

            //Act
            IntMaker intMaker = new IntMaker();
            long actual = intMaker.ConvertToInt(sample);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConvertToInt_MaximumIn_MaximumOut()
        {
            //Arrange
            string sample = "2147483647";
            long expected = 2147483647;

            //Act
            IntMaker intMaker = new IntMaker();
            long actual = intMaker.ConvertToInt(sample);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConvertToInt_MoreThanMaximumIn_TypeOverFlowExceptionOut()
        {
            //Arrange
            string sample = "2147483649";

            //Act
            IntMaker intMaker = new IntMaker();

            //Assert
            Assert.ThrowsException<TypeOverFlowException>(() => intMaker.ConvertToInt(sample));
        }

        [TestMethod]
        public void ConvertToInt_LessThanMinimumIn_TypeOverFlowExceptionOut()
        {
            //Arrange
            string sample = "-2147483650";

            //Act
            IntMaker intMaker = new IntMaker();

            //Assert
            Assert.ThrowsException<TypeOverFlowException>(() => intMaker.ConvertToInt(sample));
        }

        [TestMethod]
        public void ConvertToInt_NotNumberIn_IncorrectFormatExceptionOut()
        {
            //Arrange
            string sample = "abcde";

            //Act
            IntMaker intMaker = new IntMaker();

            //Assert
            Assert.ThrowsException<IncorrectFormatException>(() => intMaker.ConvertToInt(sample));
        }

        [TestMethod]
        public void ConvertToInt_EmptyStringIn_EmptyStringExceptionOut()
        {
            //Arrange
            string sample = string.Empty;

            //Act
            IntMaker intMaker = new IntMaker();

            //Assert
            Assert.ThrowsException<EmptyStringException>(() => intMaker.ConvertToInt(sample));
        }
    }
}
