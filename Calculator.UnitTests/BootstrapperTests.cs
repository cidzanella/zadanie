using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace Calculator.UnitTests
{
    public class BootstrapperTests
    {
        [Test]
        public void Initializa_EmptyArgs_ThrowException()
        {
            //Arrange
            BootstrapperService bootstrapper = new BootstrapperService();
            string[] args = { };

            //Act
            var ex = Assert.Throws<Exception>(() => bootstrapper.Initialize(args));

            // Assert
            Assert.AreEqual(ex.Message, "Calculator expects an Instructions Input file string path as an argument. \nEx: Calculator \"c:\\instructions.txt\"");
        }

        [Test]
        public void Initializa_NonValidPathString_ThrowException()
        {
            //Arrange
            BootstrapperService bootstrapper = new BootstrapperService();
            string[] args = {"abcd" };

            //Act
            var ex = Assert.Throws<ArgumentException>(() => bootstrapper.Initialize(args));

            // Assert
            Assert.AreEqual(ex.Message, "Input file path is not valid or lack of permissions to access.");
        }

        [Test]
        public void Initializa_ValidPathString_ThrowException()
        {
            //Arrange
            BootstrapperService bootstrapper = new BootstrapperService();
            string[] args = { @"c:\zadanieinstructionsinput.txt" };

            //Act
            bootstrapper.Initialize(args);

            // Assert
            Assert.That(bootstrapper.Output == 7);
        }
    }
}
