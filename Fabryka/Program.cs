using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatingSystem
{
    class Program
    {
        /*Dodac argument(y) definiujace typ system operacyjnego i programów*/
        static OperatingSystem CreateOS(IEnumerable<string> procesNames, FabrykaOS f,int ile, FabrykaProgram cp)
        {
            OperatingSystem os = f.Create(); //Stworzyc system operacyjny danego typu
            for(int i=0;i<ile;i++)
            {
                ComputerProgram c = cp.Create();
                os.Add(c);
            }
            
            return os;
        }
        
        static void Main(string[] args)
        {
           

            //Stworzyc system operacyjny Windows z błędem 3, który posiada 7 programów Painter o startowej wielkości 10
            var system1 = CreateOS(new List<string> { "Alpha", "Beta", "Gamma", "Delta", "Sigma", "Tau", "Zeta" },new FabrykaWindows(3),7, new FabrykaPainter(10));

            system1.StartAll();
            system1.StartAll();
            system1.UseTasks();
            system1.UseTasks();
            system1.CloseAll();
            system1.CloseAll();

            //Stworzyc system operacyjny Linux, który posiada 7 programów Browser o maksymalnej ilosci kart 5
            var system2 = CreateOS(new List<string> { "Alpha", "Beta", "Gamma", "Delta", "Sigma", "Tau", "Zeta" },new FabrykaLinuksa(),7,new FabrykaBrowser(5));

            system2.StartAll();
            system2.StartAll();
            system2.UseTasks();
            system2.UseTasks();
            system2.CloseAll();
            system2.CloseAll();

            Console.ReadLine();
        }
    }
}
