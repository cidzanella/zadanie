using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;

namespace Calculator.UnitTests
{
    public class InstructionFileReaderTests
    {
        [SetUp]
        public void Setup()
        {
            OperatorsFactory.OperatorsDictionary();

        }

        [Test]
        public void GetInstructions_NonExistingFilePath_ExpectThrowException()
        {
            // Arrange
            string filePath = @"xxxxx";

            // Act
            ArgumentException ex = Assert.Throws<ArgumentException>(() => new InstructionRepositoryService().GetInstructions(filePath));

            // Assert
            Assert.AreEqual(ex.Message, "Input file path is not valid or lack of permissions to access.");
        }

        [Test]
        public void GetInstructions_NullFilePath_ExpectThrowException()
        {
            // Arrange
            string filePath = null;

            // Act
            ArgumentException ex = Assert.Throws<ArgumentException>(() => new InstructionRepositoryService().GetInstructions(filePath));

            // Assert
            Assert.AreEqual(ex.Message, "Input file path is not valid or lack of permissions to access.");
        }

        [Test]
        public void GetInstructions_WhitespacesFilePath_ExpectThrowException()
        {
            // Arrange
            string filePath = @"   ";

            // Act
            ArgumentException ex = Assert.Throws<ArgumentException>(() => new InstructionRepositoryService().GetInstructions(filePath));

            // Assert
            Assert.AreEqual(ex.Message, "Input file path is not valid or lack of permissions to access.");
        }

        [Test]
        public void GetInstructions_EmptyFilePath_ExpectThrowException()
        {
            // Arrange
            string filePath = @"";

            // Act
            ArgumentException ex = Assert.Throws<ArgumentException>(() => new InstructionRepositoryService().GetInstructions(filePath));

            // Assert
            Assert.AreEqual(ex.Message, "Input file path is not valid or lack of permissions to access.");
        }

        [Test]
        public void GetInstructions_EmptyInstructionFile_ExpectsThrowExepction()
        {
            // Arrange
            string filePath = $"TestFile{DateTime.Now.Ticks}.txt";
            File.Create(filePath).Close();

            // Act
            var ex = Assert.Throws<Exception>(() => new InstructionRepositoryService().GetInstructions(filePath));

            // Assert
            Assert.AreEqual(ex.Message, "Instructions Input file has no instructions.");

            //Tear Down
            File.Delete(filePath);
        }

        [Test]
        public void GetInstructions_EmptyInstructionString_ExpectsThrowExepction()
        {
            // Arrange
            List<string> instructionStringList = new List<string> { " " };
            string filePath = $"TestFile{DateTime.Now.Ticks}.txt";

            File.WriteAllLines(filePath, instructionStringList);

            // Act
            var ex = Assert.Throws<Exception>(() => new InstructionRepositoryService().GetInstructions(filePath));

            // Assert
            Assert.AreEqual(ex.Message, "Empty instruction line found in file.");

            //Tear Down
            File.Delete(filePath);
        }

        [Test]
        public void GetInstructions_WrongInstructionSeparator_ExpectsThrowExepction()
        {
            // Arrange
            List<string> instructionStringList = new List<string> { "multiply  3", "apply 10" };
            string filePath = $"TestFile{DateTime.Now.Ticks}.txt";

            File.WriteAllLines(filePath, instructionStringList);

            // Act
            var ex = Assert.Throws<Exception>(() => new InstructionRepositoryService().GetInstructions(filePath));

            // Assert
            Assert.AreEqual(ex.Message, "Wrong instruction format found in file, wrong separator found. Expected format: 'operator number'.");

            //Tear Down
            File.Delete(filePath);
        }

        [Test]
        public void GetInstructions_LastInstructionIsNotApply_ExpectsThrowExepction()
        {
            // Arrange
            List<string> instructionStringList = new List<string> { "multiply 3", "add -2", "percent 50" };
            string filePath = $"TestFile{DateTime.Now.Ticks}.txt";

            File.WriteAllLines(filePath, instructionStringList);

            // Act
            var ex = Assert.Throws<Exception>(() => new InstructionRepositoryService().GetInstructions(filePath));

            // Assert
            Assert.AreEqual(ex.Message, "Wrong instruction sequence. Expect Apply as last operator.");

            //Tear Down
            File.Delete(filePath);
        }

        [Test]
        public void GetInstructions_NonValidInstructionNumber_ExpectsThrowExepction()
        {
            // Arrange
            string nonValidNumber = "1a";
            List<string> instructionStringList = new List<string> { $"multiply {nonValidNumber}", "add -2", "percent 50", "apply 10" };
            string filePath = $"TestFile{DateTime.Now.Ticks}.txt";

            File.WriteAllLines(filePath, instructionStringList);

            // Act
            var ex = Assert.Throws<Exception>(() => new InstructionRepositoryService().GetInstructions(filePath));

            // Assert
            Assert.AreEqual(ex.Message, $"'{nonValidNumber}' is not a valid number for Instruction.");

            //Tear Down
            File.Delete(filePath);
        }

        [Test]
        public void GetInstructions_NonValidInstructionOperator_ExpectsThrowExepction()
        {
            // Arrange
            string nonValidOperator = "xMultiply";
            List<string> instructionStringList = new List<string> { $"{nonValidOperator} 3", "add -2", "percent 50", "apply 10" };
            string filePath = $"TestFile{DateTime.Now.Ticks}.txt";

            File.WriteAllLines(filePath, instructionStringList);

            // Act
            var ex = Assert.Throws<Exception>(() => new InstructionRepositoryService().GetInstructions(filePath));

            // Assert
            Assert.AreEqual(ex.Message, $"'{nonValidOperator}' is not a valid operator for Instruction.");

            //Tear Down
            File.Delete(filePath);
        }

        [Test]
        public void GetInstructions_ValidInstructionsInputFile_ExpectsInstructionList()
        {
            // Arrange
            List<string> instructionStringList = new List<string> { $"multiply 3", "add -2", "percent 50", "subtract 4", "divide 2", "apply 10" };
            string filePath = $"TestFile{DateTime.Now.Ticks}.txt";

            File.WriteAllLines(filePath, instructionStringList);

            // Act
            var instructions = new InstructionRepositoryService().GetInstructions(filePath);

            // Assert
            Assert.That(instructions.Count == instructionStringList.Count);

            //Tear Down
            File.Delete(filePath);
        }

    }


}