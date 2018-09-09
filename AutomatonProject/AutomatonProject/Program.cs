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
            string s = "aababba";
            int k = 1;
            Automaton automaton = Automaton.ReadAutomation();
            automaton.ShowAutomation();
            Console.WriteLine("------------------------");

            MaxStringResult result = new MaxStringImpl().MaxString(automaton, s, k);
            Console.WriteLine(result.Flag + " " + result.M);
        }
    }
}
