using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatonProject
{
    public class MaxStringImpl
    {
        public MaxStringResult MaxString (Automaton automaton, string str, int k)
        {
            MaxStringResult result = new MaxStringResult();
            List<string> s = automaton.S;
            //если есть совпадения среди начальных и конечных состояний, значит нужная строка уже есть
            result.Flag = (automaton.S.Intersect(automaton.F).Count() > 0);           
            result.M = 0;

            for (int i=k; i < str.Length; i++)
            {
                s = automaton.Execute(s, str[i]);              

               if (s == null) { break; }
             
               if (s.Intersect(automaton.F).Count() > 0)
                {
                    result.Flag = true;
                    result.M = i - k + 1;
                }
            }
            return result;
        }
    }
}
