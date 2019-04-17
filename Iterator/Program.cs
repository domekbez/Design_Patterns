using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    class Program
    {
        public static void PrintEdges(IGraph g)
        {
            while(g.HasNext()==true)
            {
                Edge e = g.NextEdge();
                if (e.From == -1) continue;
                Console.WriteLine("{0} -> {1}",e.From,e.To);

            }
        }

        public static bool IsEuler(IGraph g)
        {
            g.ResetPos();
            int[] parzyste = new int[g.GetVertices()];
            while (g.HasNext() == true)
            {
                Edge e = g.NextEdge();
                if (e.From == -1) continue;
                int pom = e.From;
                int pom2 = e.To;
                if (parzyste[pom] == 0) parzyste[pom] = 1;
                else if (parzyste[pom] == 1) parzyste[pom] = 0;
                if (parzyste[pom2] == 0) parzyste[pom2] = 1;
                else if (parzyste[pom2] == 1) parzyste[pom2] = 0;


            }
            for(int i=0;i<parzyste.Length;i++)
            {
                if (parzyste[i] == 1) return false;
            }

            return true;
        }

        static void Main(string[] args)
        {
            Cycle cycle = new Cycle(new int[] { 0, 2, 1, 3 });
            PrintEdges(cycle);
            Console.WriteLine("Cycle - is Euler: " + IsEuler(cycle));
            Console.WriteLine("---");
            Console.WriteLine("---");
            //Grid grid = new Grid(4, 3);
            //PrintEdges(grid);
            //Console.WriteLine("Grid - is Euler: " + IsEuler(grid));
            Console.WriteLine("---");
            MatrixGraph matrixGraph1 = new MatrixGraph(4);
            matrixGraph1.AddEdge(0, 3);
            matrixGraph1.AddEdge(1, 2);
            matrixGraph1.AddEdge(3, 1);
            PrintEdges(matrixGraph1);
            Console.WriteLine("MatrixGraph1 - is Euler: " + IsEuler(matrixGraph1));
            Console.WriteLine("---");
            MatrixGraph matrixGraph2 = new MatrixGraph(4);
            matrixGraph2.AddEdge(0, 3);
            matrixGraph2.AddEdge(3, 2);
            matrixGraph2.AddEdge(2, 0);
            matrixGraph2.AddEdge(1, 3);
            matrixGraph2.AddEdge(3, 1);
            PrintEdges(matrixGraph2);
            Console.WriteLine("MatrixGraph2 - is Euler: " + IsEuler(matrixGraph2));
            Console.WriteLine("---");
        }
    }
}
