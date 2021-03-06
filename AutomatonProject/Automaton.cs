﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AutomatonProject
{
    public class Automaton
    { 
        private List<string> q;     //все возможные состояния (1,2,3,4,5,6,7,8,9)
        private List<string> e;     //сигналы (a/b) 
        private List<string> s;     //начальные состояния (1..9)
        private List<string> f;     //конечные состояния  (1..9)
        private List< List<string[]> > delta; //переходы

        private Automaton(List<string> qList, List<string> eList, List<string> sList,
                            List<string> fList, List<List<string[]>> deltaList)
        {
            this.Q = qList;
            this.E = eList;
            this.S = sList;
            this.F = fList;
            this.delta = deltaList;
        }

        public List<string> Q { get => q; set => q = value; }
        public List<string> E { get => e; set => e = value; }      
        public List<string> S { get => s; set => s = value; }
        public List<string> F { get => f; set => f = value; }
        public List<List<string[]>> Delta { get => delta; set => delta = value; }

        public static Automaton ReadAutomation(string filePath)
        {
            List<List<string>> argsList = new List<List<string>>();
            using (StreamReader reader = new StreamReader(filePath))
            {
                //считываем все строки в argsList
                while (!reader.EndOfStream)
                {
                    List<string> array = reader.ReadLine()
                        .Split('|')
                        //.Distinct()
                        .ToList();                 
                    argsList.Add(array);
                }            
            }

            //переходы
            List<List<string[]>> deltaList = new List<List<string[]>>();
            //это все строки после четвертой
            for (int i=4; i< argsList.Count; i++)
            {
                //список результатов переходов
                List<string[]> deltaListJ = new List<string[]>();
                deltaList.Add(deltaListJ);

                for (int j = 0; j < argsList[i].Count; j++)
                {
                    deltaListJ.Add(argsList[i][j].Split(','));  
                }
            }

            return new Automaton(argsList[0], argsList[1], argsList[2], argsList[3], deltaList);
        }

        public void ShowAutomation()
        {
            foreach (string str in Q)
            {
                Console.Write(str + ' ');
            }
            Console.WriteLine();
            foreach (string str in E)
            {
                Console.Write(str + ' ');
            }
            Console.WriteLine();
            foreach (string str in S)
            {
                Console.Write(str + ' ');
            }
            Console.WriteLine();
            foreach (string str in F)
            {
                Console.Write(str + ' ');
            }
            Console.WriteLine();

           //for (int i=0; i < Delta.Count; i++)
           // {
           //     for (int j=0; j < Delta[i].Count; j++)
           //     {
           //         for (int z = 0; z < Delta[i][j].Length; z++)
           //         {
           //             Console.Write(Delta[i][j][z] + ",");
           //         }
           //         Console.Write(" | ");
           //     }
           //     Console.WriteLine();
           // }
        }

        public List<string> Execute(List<string> s, char a)
        {
            List<string> result = new List<string>();
            int columnNumber = E.IndexOf(a.ToString()); //номер столбца в delta

            for (int i=0; i<s.Count; i++)
            {
                int lineNumber = Int32.Parse(s[i])-1;         //номер строки в delta                               
                string[] array = Delta[columnNumber][lineNumber];
                
                foreach (string str in array)
                {
                    if (!result.Contains(str))
                    {
                        result.Add(str);
                    }                        
                }
            }
            return result;
        }
    }
}
