using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            IStream stream =new StringStream("Faculty of. Mathematics and Information Science, Warsaw. University of Technology");
            IStream another =new StringStream(" is the best place to learn about Decorators.Period.");
            IStream p1 = new LowerDecorator(stream);
            IStream p2 = new UpperDecorator(another);


            IStream przyklad =new DeszyfratorDecorator(new SzyfratorDecorator(new BigSmallDecorator( new PointUpperDecorator(new MergeDecorator(p1, p2))),7),7);

            while (!przyklad.AtEnd())
            {
                Console.Write(przyklad.ReadNext());

            }
            
            Console.WriteLine();
        }
    }
}
