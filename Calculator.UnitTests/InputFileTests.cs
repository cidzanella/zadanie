using NUnit.Framework;

namespace Calculator.UnitTests
{
    public class InputFileTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            // Arrange
            InstructionFileReader fileReader = new InstructionFileReader()
            
            // Act

            // Assert
            Assert.Pass();
        }

        [Test]
        public void CanBeFound_FileExists_True()
        {
            // Arrange

            // Act

            // Assert
            Assert.Pass();
        }

        [Test]
        public void CanBeFound_FileDoesntExists_False()
        {
            // Arrange

            // Act

            // Assert
            Assert.Pass();
        }
    }

 
}