using System;
using System.Collections;
using System.Collections.Generic;

namespace Algorithm_Complexity_App
{
    public class Graph
    {
        public int NE; // количество ребер и вершин
        private int NV;
        public int[][] graph;
        private int[][] p;
        private int[] color; // цвета вершин
        private int from = 0; // from - обозначает номер вершины, от которой мы пойдем в другую, т.е. вызовем ф-ию dfs
        private int n = 0;
        private int k = 0;
        public List<int[]> detectedCycles = new List<int[]>();
        //C++ TO C# CONVERTER NOTE: This was formerly a static local variable declaration (not allowed in C#):
        private int dfs_to;
        // k и n - вспомогательные переменные для занесения и удаления ребер из массива p.
        // Constructor  
        public Graph(int[][] edge, int edgesNum, int vehiclsNum)
        {
            graph = edge;
            NE = edgesNum;
            NV = vehiclsNum+2;
            p = new int[NE][];
            color = new int[NV];
            for (int i = 0; i < NE; ++i)
            {
                int[] temp = new int[2] {0, 0};
                p[i] = temp;
            }
            for (int i = 0; i < NV; ++i)
            {
                color[i] = 0;
            }
            dfs();

        }
       
        private List<int[]> dfs()
        {
            try
            {
                for (int i = 0; i < NE; i++)
                {
                    if (graph[i][1] < graph[i][0])
                    {
                        int[] temp = new int[2] { graph[i][1], graph[i][0] };
                        detectedCycles.Add(temp); 
                    }
                }
            }
            catch
            {
                
            }

            return detectedCycles;
        }

    }

}