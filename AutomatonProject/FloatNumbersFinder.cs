using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatonProject
{
    public class FloatNumbersFinder
    {
        public void Find(string str, string inputFilePath)
        {
            Automaton automaton = Automaton.ReadAutomation(inputFilePath);
            for (int k=0; k <= str.Length - 1; )
            {
                MaxStringResult result = new MaxStringImpl().MaxString(automaton, str, k);
                if (result.Flag == true)
                {
                    k += result.M;
                }
                else
                {
                    k++;
                }
            }
        }
    }
}
