using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Calculator.UnitTests
{
    public class InstructionProcessorTests
    {
        [SetUp]
        public void Setup()
        {
            Operators.SetUpOperatorsDictionary();
        }

        [Test]
        public void Process_ValidInstructionsList_ReturnTheResultOfOperations()
        {
            // Arrange
            var instructions = new List<IInstruction>();
            instructions.Add(new Instruction("add", "2"));
            instructions.Add(new Instruction("multiply", "3"));
            instructions.Add(new Instruction("divide", "2"));
            instructions.Add(new Instruction("apply", "10"));

            // Act
            double output = InstructionProcessor.Process(instructions);

            // Assert
            Assert.AreEqual(output, 18);
        }

        [Test]
        public void Process_ValidNegativeInstructionsList_ReturnTheResultOfOperations()
        {
            // Arrange
            var instructions = new List<IInstruction>();
            instructions.Add(new Instruction("add", "2"));
            instructions.Add(new Instruction("multiply", "-3"));
            instructions.Add(new Instruction("apply", "10"));

            // Act
            double output = InstructionProcessor.Process(instructions);

            // Assert
            Assert.AreEqual(output, -36);
        }

        [Test]
        public void Process_ValidDivideByZeroInstruction_ThrowException()
        {
            // Arrange
            var instructions = new List<IInstruction>();
            instructions.Add(new Instruction("divide", "0"));
            instructions.Add(new Instruction("apply", "10"));

            // Act
            var ex = Assert.Throws<Exception>(() => InstructionProcessor.Process(instructions));

            // Assert
            Assert.AreEqual(ex.Message, "Divide by zero error. Instruction 'divide 0' is not allowed.");
        }
    }
}
