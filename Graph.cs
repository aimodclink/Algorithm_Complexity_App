using System;
using System.Collections;
using System.Collections.Generic;

namespace Algorithm_Complexity_App
{
    public class Graph
    {
        //const int N = 100000;
        //int[] color = new int[N];
        //int[] par = new int[N];

        //// mark with unique numbers 
        //int[] mark = new int[N];

        //// store the numbers of cycle 
        //int cyclenumber = 0;

        //// A DFS based approach to find if  
        //// there is a cycle in a directed graph.  
        //// This approach strictly follows the  
        //// algorithm given in CLRS book.  
        //static int WHITE = 0, GRAY = 1, BLACK = 2;
        //public ArrayList<int>[] cycles;


        //// Graph class represents a directed graph  
        //// using adjacency list representation  
        //public int V;

        //public List<int>[] adjList;

        //// Constructor  
        //public Graph(int ver)
        //{
        //    V = ver;
        //    adjList = new List<int>[V];
        //    for (int i = 0; i < V; i++)
        //        adjList[i] = new List<int>();
        //}

        //// Utility function to add an edge  
        //public void addEdge(Graph g, int u, int v)
        //{
        //    g.adjList[u].Add(v);// Add v to u's list.  
        //}

        //// Recursive function to find if there is back edge  
        //// in DFS subtree tree rooted with 'u'  
        //static bool DFSUtil(Graph g, int u, int[] color)
        //{
        //    // GRAY : This vertex is being processed (DFS  
        //    // for this vertex has started, but not  
        //    // ended (or this vertex is in function  
        //    // call stack)  
        //    color[u] = GRAY;

        //    // Iterate through all adjacent vertices 
        //    foreach (int iN in g.adjList[u])
        //    {
        //        // If there is 
        //        if (color[iN] == GRAY)
        //            return true;

        //        // If v is not processed and there is a back  
        //        // edge in subtree rooted with v  
        //        if (color[iN] == WHITE &&
        //            DFSUtil(g, iN, color) == true)
        //            return true;
        //    }

        //    // Mark this vertex as processed  
        //    color[u] = BLACK;
        //    return false;
        //}

        //// Returns true if there is a cycle in graph 
        //static bool isCyclic(Graph g)
        //{
        //    // Initialize color of all vertices as WHITE 
        //    int[] color = new int[g.V];
        //    for (int i = 0; i < g.V; i++)
        //    {
        //        color[i] = WHITE;
        //    }

        //    // Do a DFS traversal beginning with all  
        //    // vertices  
        //    for (int i = 0; i < g.V; i++)
        //    {
        //        if (color[i] == WHITE)
        //        {
        //            if (DFSUtil(g, i, color) == true)
        //                return true;
        //        }
        //    }

        //    return false;

        //}

        //public void dfs_cycle(Graph g, int u, int p)
        //{

        //    // already (completely) visited vertex. 
        //    if (color[u] == 2)
        //    {
        //        return;
        //    }

        //    // seen vertex, but was not completely visited -> cycle detected. 
        //    // backtrack based on parents to find the complete cycle. 
        //    if (color[u] == 1)
        //    {

        //        cyclenumber++;
        //        int cur = p;
        //        mark[cur] = cyclenumber;

        //        // backtrack the vertex which are 
        //        // in the current cycle thats found 
        //        while (cur != u)
        //        {
        //            cur = par[cur];
        //            mark[cur] = cyclenumber;
        //        }

        //        return;
        //    }

        //    par[u] = p;

        //    // partially visited. 
        //    color[u] = 1;

        //    // simple dfs on graph 
        //    foreach (int v in g.adjList[u])
        //    {

        //        // if it has not been visited previously 
        //        if (v == par[u])
        //        {
        //            continue;
        //        }

        //        dfs_cycle(g, v, u);
        //    }

        //    // completely visited. 
        //    color[u] = 2;
        //}

        //public string printCycles(int edges)
        //{

        //    // push the edges that into the 
        //    // cycle adjacency list 
        //    for (int i = 1; i <= edges; i++)
        //    {
        //        if (mark[i] != 0)
        //            cycles[mark[i]].Add(i);
        //    }

        //    // print all the vertex with same cycle 
        //    for (int i = 1; i <= cyclenumber; i++)
        //    {
        //        // Print the i-th cycle 
        //        resultString += "Cycle Number " + i + ": ";
        //        foreach (int x in cycles[i])
        //            resultString += x + " ";
        //        resultString += Environment.NewLine;
        //    }

        //    return resultString;
        //}

        // C++ program to print all the cycles 
        // in an undirected graph 
        //C++ TO C# CONVERTER WARNING: The following #include directive was ignored:
        //#include <bits/stdc++.h>
        //private const int N = 100000;
        //    public Graph()
        //    {
        //        //graph = new List<int>[ver];
        //        for (int i = 0; i < N; i++)
        //            graph[i] = new List<int>();
        //        for (int i = 0; i < N; i++)
        //            cycles[i] = new List<int>();
        //}
        //// variables to be used 
        //// in both functions 
        //int[] color = new int[N];
        //int[] par = new int[N];

        //// mark with unique numbers 
        //int[] mark = new int[N];

        //// store the numbers of cycle 
        //int cyclenumber = 0;

        //private List<int>[] graph = new List<int>[N];
        //private List<int>[] cycles = new List<int>[N];

        //// Function to mark the vertex with 
        //// different colors for different cycles 
        //public void dfs_cycle(int u, int p)
        //{

        //    // already (completely) visited vertex. 
        //    if (color[u] == 2)
        //    {
        //        return;
        //    }

        //    // seen vertex, but was not completely visited -> cycle detected. 
        //    // backtrack based on parents to find the complete cycle. 
        //    if (color[u] == 1)
        //    {

        //        cyclenumber++;
        //        int cur = p;
        //        mark[cur] = cyclenumber;

        //        // backtrack the vertex which are 
        //        // in the current cycle thats found 
        //        while (cur != u)
        //        {
        //            cur = par[cur];
        //            mark[cur] = cyclenumber;
        //        }

        //        return;
        //    }

        //    par[u] = p;

        //    // partially visited. 
        //    color[u] = 1;

        //    // simple dfs on graph 
        //    foreach (int v in graph[u])
        //    {

        //        // if it has not been visited previously 
        //        if (v == par[u])
        //        {
        //            continue;
        //        }

        //        dfs_cycle(v, u);
        //    }

        //    // completely visited. 
        //    color[u] = 2;
        //}

        //// add the edges to the graph 
        //public void addEdge(int u, int v)
        //{
        //    graph[u].Add(v);
        //    graph[v].Add(u);
        //}

        // Function to print the cycles 
        //public string printCycles(int edges)
        //{

        //    // push the edges that into the 
        //    // cycle adjacency list 
        //    for (int i = 1; i <= edges; i++)
        //    {
        //        if (mark[i] != 0)
        //        {
        //            cycles[mark[i]].Add(i);
        //        }
        //    }

        //    string resultString = "";
        //    // print all the vertex with same cycle 
        //    for (int i = 1; i <= cyclenumber; i++)
        //    {
        //        // Print the i-th cycle 
        //        resultString += "Cycle Number " + i + ": ";
        //        foreach (int x in cycles[i])
        //            resultString += x + " ";
        //        resultString += Environment.NewLine;
        //    }

        //    return resultString;
        //}
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