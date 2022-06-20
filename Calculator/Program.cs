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
                var bootStrapper = new BootstrapperService();
                bootStrapper.Initialize(args);
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occured while processing Calculator with the Instrucions Input file. \nPlease check the following information:\n{e.Message}");
            }

        }
    }
}
