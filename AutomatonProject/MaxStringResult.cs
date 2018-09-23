using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatonProject
{
    public class MaxStringResult
    {
        private bool flag; //есть ли символы после k
        private int m;    //количество символов в max подстроке после k, которые приводят к конечному состоянию

        public bool Flag { get => flag; set => flag = value; }
        public int M { get => m; set => m = value; }
    }
}
