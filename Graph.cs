using System;
using System.Collections;
using System.Collections.Generic;

namespace Algorithm_Complexity_App
{
    public class Graph
    {
        private int NE; // количество ребер и вершин
        private int NV;
        private int[][] graph;
        private int[][] p;
        private int[] color; // цвета вершин
        private int from = 0; // from - обозначает номер вершины, от которой мы пойдем в другую, т.е. вызовем ф-ию dfs
        private int n = 0;
        private int k = 0;
        public string resultString = "";
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

        //private int[,] g =
        //{
        //    {0,1},
        //    {1,2},
        //    {2,3},
        //    {3,0},
        //    {4,0},
        //    {1,4},
        //    {4,2},
        //    {3,4}
        //}; // g - сам граф, заданный ребрами,
        //private int[,] p =
        //            {
        //        {0,0},
        //        {0,0},
        //        {0,0},
        //        {0,0},
        //        {0,0},
        //        {0,0},
        //        {0,0}
        //    };
        //например 0-1 значит что ребро направлено от вершины 0 к вершине 1, p - буфер, для хранения ребер по ходу поиска


        //private void dfs(int v)
        //{
        //    try
        //    {
        //        n++;
        //        int to; // to - номер вершины, в которую собираемся пойти
        //        //int from = 0;
        //        color[v] = 1;
        //        for (int i = 0; i < NE; i++)
        //        {
        //            if (graph[i][0] == v)
        //            {
        //                to = graph[i][1];
        //                if (color[to] == 0)
        //                {
        //                    p[n][0] = graph[i][0]; p[n][1] = graph[i][1]; //
        //                    from = v;
        //                    dfs(to);
        //                    while (p[n][1] != v)       //!!!!!
        //                        n--;
        //                    n++;
        //                }
        //                else if (color[to] == 1)
        //                {

        //                    p[n][0] = graph[i][0]; p[n][1] = graph[i][1];
        //                    k = n;
        //                    while (p[k][0] != to)
        //                    {
        //                        resultString+=(p[k][0]);
        //                        resultString += ('-');
        //                        resultString += (p[k][1]);
        //                        resultString += (' ');
        //                        k--;
        //                    }
        //                    resultString += (p[k][0]);
        //                    resultString += ('-');
        //                    resultString += (p[k][1]);
        //                    resultString += (' ');
        //                    resultString += ("\n");
        //                    //n--;

        //                }
        //            }
        //        }
        //        if (v == 0) color[v] = 2;
        //        else
        //        if (color[from] == 1)
        //            color[v] = 0;
        //        else color[v] = 2;
        //    }
        //    catch
        //    {
        //        resultString += "error";
        //    }
        //}

        private void dfs()
        {
            try
            {
                for (int i = 0; i < NE; i++)
                {
                    if (graph[i][1] < graph[i][0])
                    {
                        resultString += (graph[i][1]);
                        resultString += ('-');
                        resultString += (graph[i][0]);
                        resultString += (' ');
                    }
                }
            }
            catch
            {
                resultString = "Цыклы не найдены";
            }
        }


        //static int Main()
        //{

        //    for (int i = 0; i < NV; i++)
        //    {
        //        if (color1[i] == 0)
        //        {
        //            dfs(i);
        //        }
        //    }
        //    Console.Write("\n");
        //    system("pause");
        //    return 0;
        //}


    }

}