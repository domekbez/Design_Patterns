using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatingSystem
{
    public abstract class OperatingSystem
    {
        protected List<ComputerProgram> programs = new List<ComputerProgram>();

        public abstract void Add(ComputerProgram cp);

        public abstract void StartAll();
        public abstract void CloseAll();

        public void UseTasks()
        {
            Console.WriteLine("Running tasks:");
            foreach (var a in programs.Where(x => x.Working)) {
                a.Use();
            }
        }
    }

    public class Windows : OperatingSystem
    {
        public int errorTimes = 5;
        public int curErrors { get; set; }
        public Windows(int errors)
        {
            
            errorTimes = errors;
        }
        public override void Add(ComputerProgram cp)
        {
            if(curErrors%errorTimes==0)
            {
                programs.Add(cp);
                cp.Start();
            }
            else
            {
                programs.Add(cp);

            }
            curErrors++;
        }

        public override void CloseAll()
        {
            
            
            foreach (var el in programs)
            {
                if (curErrors % errorTimes == 0)
                {
                    Console.WriteLine("Special Case: ERROR");
                }
                else
                {
                    el.Close();
                }
                curErrors++;
               
            }
            
        }

        public override void StartAll()
        {
            foreach (var el in programs)
            {
                if (curErrors% errorTimes == 0)
                {
                    Console.WriteLine("Special Case: ERROR");
                }
                else
                {
                    el.Start();
                }
                curErrors++;

            }

        }
    }
    public class Linux : OperatingSystem
    {
        //public Linux(List<ComputerProgram> l)
        //{
        //    programs = l;
        //}
        public override void Add(ComputerProgram cp)
        {
            programs.Add(cp);
        }

        public override void CloseAll()
        {
            foreach (var el in programs)
            {
                el.Close();
            }
        }

        public override void StartAll()
        {
            foreach(var el in programs)
            {
                el.Start();
            }
        }
        
    }

    public abstract class FabrykaOS
    {
        public abstract OperatingSystem Create();
    }

    public class FabrykaWindows:FabrykaOS
    {
        public int a;
        public FabrykaWindows(int ile)
        {
            a = ile;
        }
        public override OperatingSystem Create()
        {
            return new Windows(a);
        }
        
    }
    public class FabrykaLinuksa : FabrykaOS
    {
        
        public override OperatingSystem Create()
        {
            return new Linux();
        }
    }

    public abstract class FabrykaProgram
    {
        public abstract ComputerProgram Create();
    }

    public class FabrykaPainter : FabrykaProgram
    {
        public double a;
        public FabrykaPainter(double ile)
        {
            a = ile;
        }
        public override ComputerProgram Create()
        {
            return new Painter(a, "Paint");
        }

    }
    public class FabrykaBrowser : FabrykaProgram
    {
        public int a;
        public FabrykaBrowser(int ile)
        {
            a = ile;
        }
        public override ComputerProgram Create()
        {
            return new Browser(a, "Brows");
        }
    }




}
