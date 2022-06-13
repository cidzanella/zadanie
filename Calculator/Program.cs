using System;
using System.IO;

namespace Calculator
{
    internal class Program
    {
        /// <summary>
        /// Calculator receives as argument the path for a text file with Instructions inputs to be processed
        /// </summary>
        /// <param name="args">Instructions Input file path</param>
        static void Main(string[] args)
        {
            try
            {
                // Validate instruction input file path
                if (args.Length == 0)
                    throw new Exception("Calculator expects an Instructions Input file string path as an argument. \nEx: Calculator \"c:\\instructions.txt\"");

                // Generate instructions list from input file
                var fileReader = new InstructionFileReader(args[0]);
                var instructions = fileReader.GetInstructionList();

                // Execute instructions
                double output = InstructionProcessor.Process(instructions);
                Console.WriteLine(output);
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occured while processing Calculator with the Instrucions Input file. \nPlease check the following information:\n{e.Message}");
            }

        }
    }
}
