using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    // Handles reading instructions from the input file and generating the list of instructions to be executed
    // It's an static class once it doesn't has state, it's only processing and returning data
    public static class InstructionFileReader
    {
        
        // validate input file path: checks for null, whitespaces as well
        private static void CheckFileExists(string inputFile)
        {
            if (!File.Exists(inputFile))
                throw new ArgumentException("Input file path is not valid or lack of permissions to access.");
        }

        // reads lines from file and create a list of strings instructions
        private static List<string> ReadInstructionStringsFromFile(string inputFile)
        {
            // get all instructions lines from the file
            var instructionStrings = File.ReadAllLines(inputFile);

            // check if got any instruction from file 
            if (instructionStrings.Length == 0)
                throw new Exception("Instructions Input file has no instructions.");

            return new List<string>(instructionStrings);
        }

        // Generate instructions list from list of strings instructions read from the file
        public static List<IInstruction> GetInstructions(string inputFile)
        {
            CheckFileExists(inputFile);

            // read instructions strings from input file
            var instructionsStringList = ReadInstructionStringsFromFile(inputFile);

            var instructions = new List<IInstruction>();

            // loop string list from file checking format and creating instruction list 
            foreach (String instructionString in instructionsStringList)
            {
                CheckEmptyInstruction(instructionString);

                CheckInstructionSeparator(instructionString);

                var instruction = CreateInstruction(instructionString);
                if (instruction != null)
                    instructions.Add(instruction);
            }

            // verify that the instructions list has an Apply operator as last instruction
            CheckLastOperatorIsApply(instructions.Last());

            // return the list of instructions to be processed
            return instructions;
        }

        // Generate an instruction from string, spliting it into operator and number
        private static IInstruction CreateInstruction(string instructionString)
        {
            // split instruction string in two parts
            string[] instructionParts = instructionString.Split(' ');
            string operation = instructionParts[0];
            string number = instructionParts[1];

            // creates an Instruction object
            return new Instruction(operation, number);

        }

        //checks if there is one whitespace separator on string 
        private static void CheckInstructionSeparator(string instructionString)
        {
            if (instructionString.Count(c => c == ' ') != 1)
                throw new Exception("Wrong instruction format found in file, wrong separator found. Expected format: 'operator number'.");
        }

        // checks for empty string instruction
        private static void CheckEmptyInstruction(string instructionString)
        {
            if (string.IsNullOrWhiteSpace(instructionString))
                throw new Exception("Empty instruction line found in file.");
        }

        // check if last instruction operator is APPLY
        private static void CheckLastOperatorIsApply(IInstruction instruction)
        {
            if (instruction.Operator.GetType().Name != "OperatorApply")
                throw new Exception("Wrong instruction sequence. Expect Apply as last operator.");
        }

    }
}
