using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public abstract class Decorator : IStream
    {
        public IStream ist;

        public Decorator(IStream i)
        {
            ist = i;
        }
        public virtual bool AtEnd()
        {
            throw new NotImplementedException();
        }

        public virtual char ReadNext()
        {
            throw new NotImplementedException();
        }
    }
    

}
