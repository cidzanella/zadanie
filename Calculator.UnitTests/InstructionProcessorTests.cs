using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Calculator.UnitTests
{
    public class InstructionProcessorTests
    {
        [SetUp]
        public void Setup()
        {
            OperatorsFactory.OperatorsDictionary();
        }

        [Test]
        public void Process_ValidInstructionsList_ReturnTheResultOfOperations()
        {
            // Arrange
            var instructions = new Collection<IInstruction>();
            instructions.Add(new Instruction("add", "2"));
            instructions.Add(new Instruction("multiply", "3"));
            instructions.Add(new Instruction("divide", "2"));
            instructions.Add(new Instruction("subtract", "4"));
            instructions.Add(new Instruction("percent", "50"));
            instructions.Add(new Instruction("apply", "10"));

            // Act
            double output = new InstructionProcessorService().Process(instructions);

            // Assert
            Assert.AreEqual(output, 7);
        }

        [Test]
        public void Process_ValidNegativeInstructionsList_ReturnTheResultOfOperations()
        {
            // Arrange
            var instructions = new Collection<IInstruction>();
            instructions.Add(new Instruction("add", "2"));
            instructions.Add(new Instruction("multiply", "-3"));
            instructions.Add(new Instruction("apply", "10"));

            // Act
            double output = new InstructionProcessorService().Process(instructions);

            // Assert
            Assert.AreEqual(output, -36);
        }

        [Test]
        public void Process_ValidDivideByZeroInstruction_ThrowException()
        {
            // Arrange
            var instructions = new Collection<IInstruction>();
            instructions.Add(new Instruction("divide", "0"));
            instructions.Add(new Instruction("apply", "10"));

            // Act
            var ex = Assert.Throws<Exception>(() => new InstructionProcessorService().Process(instructions));

            // Assert
            Assert.AreEqual(ex.Message, "Divide by zero error. Instruction 'divide 0' is not allowed.");
        }
    }
}
