using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    public interface IGraph
    {
        Edge NextEdge();
        int GetVertices();
        bool HasNext();
        void ResetPos();

    }
    public struct Edge
    {
       
        public int From { get; set; }
        public int To { get; set; }

        public Edge(int from, int to)
        {
            this.From = from;
            this.To = to;
        }
    }

    public class Cycle : IGraph
    {
        private int[] vertices;
        private int pos;
   
        public Cycle(int[] vertices)
        {
            this.vertices = vertices;
            pos = 0;
        }
        public int GetVertices()
        {
            return vertices.Length;
        }

        public bool HasNext()
        {
            if (pos == vertices.Length) return false;
            return true;
        }

        public Edge NextEdge()
        {
            if(pos<vertices.Length-1)
            {
                Edge el = new Edge(pos, pos + 1);
                pos++;
                return el;
            }

            Edge e = new Edge(pos, 0);
            pos++;
            return e;
            
            
        }

        public int[] NextVertices(int v)
        {
            List<int> l = new List<int>();
            int i = 0;
            for (; i < vertices.Length; i++)
            {
                if (vertices[i] == v) break;
            }
            if (v == vertices.Length) return null;
            if(v==vertices.Length-1)
            {
                l.Add(vertices[0]);
                return l.ToArray();
            }
            l.Add(vertices[i + 1]);
            return l.ToArray();
        }

        public void ResetPos()
        {
            pos = 0;
        }
    }


    public class Grid:IGraph
    {
        int width;
        int height;
        int pos = 0;
        public Grid(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public int GetVertices()
        {
            return width * height;
        }

        public bool HasNext()
        {
            if (pos == width * height - 1) return false;
            return true;
        }

        public Edge NextEdge()
        {
            return new Edge(-1, -1);
        }

        public void ResetPos()
        {
            pos = 0;
        }
    }

    public class MatrixGraph:IGraph
    {
    
        int[,] matrix;
        int pos = 0;
        
        public int GetVertices()
        {
            return matrix.GetLength(0);
        }
        public MatrixGraph(int vertices)
        {
            matrix = new int[vertices, vertices];
        }

        public void AddEdge(int from, int to)
        {
            matrix[from, to] = 1;
        }

        public int[] NextVertices(int v)
        {
            List<int> l = new List<int>();
            for(int i=0;i<matrix.Length;i++)
            {
                if (matrix[v, i] == 1) l.Add(i);
            }
            return l.ToArray();
        }

        public Edge NextEdge()
        {

            if (matrix[(int)(pos/(matrix.GetLength(0))),pos%matrix.GetLength(0)]!=0)
            {
                Edge el = new Edge((int)(pos / (matrix.GetLength(0))), pos % matrix.GetLength(0));
                pos++;
                return el;
            }
            Edge e = new Edge(-1,-1);
            pos++;
            return e;
        }

        public bool HasNext()
        {
            if (pos == matrix.GetLength(0) * matrix.GetLength(0)) return false;
            return true;
        }

        public void ResetPos()
        {
            pos = 0;
        }
    }

}
