using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatonProject
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "+1.23e+6";            
            string inputFilePath = @"automationsInput\inputSecondTask.txt";
            Automaton automaton = Automaton.ReadAutomation(inputFilePath);
            automaton.ShowAutomation();

            new FloatNumbersFinder().Find(str, inputFilePath);
            //MaxStringResult result = new MaxStringImpl().MaxString(automaton, s, k);
            //Console.WriteLine(result.Flag + " " + result.M);
        }
    }
}
