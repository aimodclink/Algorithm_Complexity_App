//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace Algorithm_Complexity_App
//{
//    public class AllCyclesInDirectedGraphTarjan
//    {
//        private ISet<Graph.Vertex<int>> visited;
//        private LinkedList<Graph.Vertex<int>> pointStack;
//        private LinkedList<Graph.Vertex<int>> markedStack;
//        private ISet<Graph.Vertex<int>> markedSet;

//        public AllCyclesInDirectedGraphTarjan()
//        {
//            reset();
//        }

//        private void reset()
//        {
//            visited = new HashSet<Graph.Vertex<int>>();
//            pointStack = new LinkedList<Graph.Vertex<int>>();
//            markedStack = new LinkedList<Graph.Vertex<int>>();
//            markedSet = new HashSet<Graph.Vertex<int>>();
//        }

//        public virtual IList<IList<Graph.Vertex<int>>> findAllSimpleCycles(Graph<int> graph)
//        {
//            reset();
//            IList<IList<Graph.Vertex<int>>> result = new List<IList<Graph.Vertex<int>>>();
//            foreach (Graph.Vertex<int> vertex in graph.AllVertex)
//            {
//                findAllSimpleCycles(vertex, vertex, result);
//                visited.Add(vertex);
//                while (markedStack.Count > 0)
//                {
//                    markedSet.remove(markedStack.RemoveFirst());
//                }
//            }
//            return result;
//        }

//        private bool findAllSimpleCycles(Graph.Vertex<> start, Graph.Vertex<int> current, IList<IList<Graph.Vertex<int>>> result)
//        {
//            bool hasCycle = false;
//            pointStack.offerFirst(current);
//            markedSet.Add(current);
//            markedStack.offerFirst(current);

//            foreach (Graph.Vertex<int> w in current.AdjacentVertexes)
//            {
//                if (visited.Contains(w))
//                {
//                    continue;
//                }
//                else if (w.Equals(start))
//                {
//                    hasCycle = true;
//                    pointStack.offerFirst(w);
//                    IList<Graph.Vertex<int>> cycle = new List<Graph.Vertex<int>>();
//                    IEnumerator<Graph.Vertex<int>> itr = pointStack.GetReverse().GetEnumerator();
//                    while (itr.MoveNext())
//                    {
//                        cycle.Add(itr.Current);
//                    }
//                    pointStack.RemoveFirst();
//                    result.Add(cycle);
//                }
//                else if (!markedSet.Contains(w))
//                {
//                    hasCycle = findAllSimpleCycles(start, w, result) || hasCycle;
//                }
//            }

//            if (hasCycle)
//            {
//                while (!markedStack.First.Value.Equals(current))
//                {
//                    markedSet.remove(markedStack.RemoveFirst());
//                }
//                markedSet.remove(markedStack.RemoveFirst());
//            }

//            pointStack.RemoveFirst();
//            return hasCycle;
//        }

//        //public static void Main(string[] args)
//        //{
//        //    Graph<int> graph = new Graph<int>(true);
//        //    graph.addEdge(0, 1);
//        //    graph.addEdge(1, 4);
//        //    graph.addEdge(1, 7);
//        //    graph.addEdge(1, 6);
//        //    graph.addEdge(4, 2);
//        //    graph.addEdge(4, 3);
//        //    graph.addEdge(2, 4);
//        //    graph.addEdge(2, 7);
//        //    graph.addEdge(2, 6);
//        //    graph.addEdge(7, 8);
//        //    graph.addEdge(7, 5);
//        //    graph.addEdge(5, 2);
//        //    graph.addEdge(5, 3);
//        //    graph.addEdge(3, 7);
//        //    graph.addEdge(3, 6);
//        //    graph.addEdge(3, 4);
//        //    graph.addEdge(6, 5);
//        //    graph.addEdge(6, 8);

//        //    AllCyclesInDirectedGraphTarjan tarjan = new AllCyclesInDirectedGraphTarjan();
//        //    IList<IList<Graph.Vertex<int>>> result = tarjan.findAllSimpleCycles(graph);
//        //    result.ForEach(cycle =>
//        //    {
//        //        cycle.forEach(v => Console.Write(v.Id + " "));
//        //        Console.WriteLine();
//        //    });
//        //}
//    }

//}

