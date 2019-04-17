using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatingSystem
{
    public abstract class ComputerProgram
    {
        protected string fileName;
        protected bool working;

        public bool Working
        {
            get { return working; }
            set { }
        }

        public ComputerProgram(string fileName)
        {
            this.fileName = fileName;
            working = false;
        }

        public abstract void Start();
        public abstract void Use();
        public abstract void Close();
    }
    public class Painter : ComputerProgram
    {
        public Painter(double size, string name):base(name)
        {
            DefSize = CurSize = size;
        }

        public double DefSize { get; set; }
        public double CurSize { get; set; }



        public override void Close()
        {
            Working = false;
            Console.WriteLine("Last canvas size: {0}",CurSize);
            CurSize = DefSize;
            

        }

        public override void Start()
        {
            if(Working==true)
                Console.WriteLine("{0} is already working",fileName);
            else
            {
                
                Console.WriteLine("{0} started",fileName);
            }
        }

        public override void Use()
        {
            if (Working == true)
            {
                Console.WriteLine("{0} is doubling pictures size", fileName);
                CurSize *= 2;
            }
            else
            {

                Console.WriteLine("Please start {0} first", fileName);
            }
        }
    }
    public class Browser : ComputerProgram
    {
        public int Max { get; set; }
        public int Cur { get; set; }
        public Browser(int max, string name):base(name)
        {
            Max = max;
            Cur = 0;
        }

        public override void Close()
        {
            if (Cur >= 2)
                Cur -= 2;
            else
                Cur = 0;

            Console.WriteLine("Closing some tabs", Cur);

        }

        public override void Start()
        {
            Use();
        }

        public override void Use()
        {
            Cur++;
            Console.WriteLine("Current number of tabs: {0}",Cur);
            if(Cur==Max)
            {
                Close();
            }
        }
    }
}
