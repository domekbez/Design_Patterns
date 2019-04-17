using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class UpperDecorator : Decorator
    {
        public UpperDecorator(IStream i):base(i)
        {

        }
        public override bool AtEnd()
        {
            return ist.AtEnd();
        }

        public override char ReadNext()
        {
            return Char.ToUpper(ist.ReadNext());
        }



    }
    public class LowerDecorator : Decorator
    {
        public LowerDecorator(IStream i) : base(i)
        {

        }
        public override bool AtEnd()
        {
            return ist.AtEnd();
        }

        public override char ReadNext()
        {
            return Char.ToLower(ist.ReadNext());
        }
    }
    public class SpacesDecorator : Decorator
    {
        public SpacesDecorator(IStream i) : base(i)
        {

        }
        public override bool AtEnd()
        {
            return ist.AtEnd();
        }

        public override char ReadNext()
        {
            char a = ist.ReadNext();
            if (a == ' ') a = '_';
            return a;
        }
    }
    public class MergeDecorator : Decorator
    {
        IStream second;
        public MergeDecorator(IStream i,IStream sec) : base(i)
        {
            second = sec;
        }
        public override bool AtEnd()
        {
            return ist.AtEnd() && second.AtEnd();
        }

        public override char ReadNext()
        {
            if (ist.AtEnd() == false)
                return ist.ReadNext();
            else
                return second.ReadNext();
        }
    }
    public class RemoveVowelDecorator : Decorator
    {
        public RemoveVowelDecorator(IStream i) : base(i)
        {
        }
        public override bool AtEnd()
        {
            return ist.AtEnd();
        }

        public override char ReadNext()
        {
            char a;
            char b;
            do
            {
                a = ist.ReadNext();
                b = char.ToLower(a);
            } while ((b == 'a' || b == 'e' || b == 'y' || b == 'u' || b == 'i' || b == 'o')&&ist.AtEnd()==false);
            return a;
            
        }
    }
    public class PointUpperDecorator : Decorator
    {
        bool flaga = false;
        public PointUpperDecorator(IStream i) : base(i)
        {
        }
        public override bool AtEnd()
        {
            return ist.AtEnd();
        }

        public override char ReadNext()
        {
            char a = ist.ReadNext();
            if(a=='.')
            {
                flaga = true;
                return a;
            }
            if(flaga==true&&char.IsLetter(a)==true)
            {
                flaga = false;
                return Char.ToUpper(a);
            }
            return a;

        }
    }
    public class SzyfratorDecorator : Decorator
    {
        int n;
    
        public SzyfratorDecorator(IStream i,int ile) : base(i)
        {
            n = ile;
        }
        public override bool AtEnd()
        {
            return ist.AtEnd();
        }

        public override char ReadNext()
        {
            char a = ist.ReadNext();
            if (Char.IsLetter(a) == true && Char.IsUpper(a)==true)
            {
                int b = Convert.ToInt32(a);
                b=(((b-Convert.ToInt32('A')) +n)%26) +Convert.ToInt32('A');
                return Convert.ToChar(b);
            }
            else if(Char.IsLetter(a) == true && Char.IsUpper(a) == false)
            {
                int b = Convert.ToInt32(a);
                b = (((b - Convert.ToInt32('a')) + n) % 26) + Convert.ToInt32('a');
                return Convert.ToChar(b);
            }
            else
                return a;

        }
    }
    public class DeszyfratorDecorator : Decorator
    {
        int n;
        public DeszyfratorDecorator(IStream i,int ile) : base(i)
        {
            n =26-ile;
        }
        public override bool AtEnd()
        {
            return ist.AtEnd();
        }

        public override char ReadNext()
        {
            char a = ist.ReadNext();
            if (Char.IsLetter(a) == true && Char.IsUpper(a) == true)
            {
                int b = Convert.ToInt32(a);
                b = (((b - Convert.ToInt32('A')) + n) % 26) + Convert.ToInt32('A');
                return Convert.ToChar(b);
            }
            else if (Char.IsLetter(a) == true && Char.IsUpper(a) == false)
            {
                int b = Convert.ToInt32(a);
                b = (((b - Convert.ToInt32('a')) + n) % 26) + Convert.ToInt32('a');
                return Convert.ToChar(b);
            }
            else
                return a;
        }
    }
    public class BigSmallDecorator : Decorator
    {
        bool flaga = false;
        public BigSmallDecorator(IStream i) : base(i)
        {
        }
        public override bool AtEnd()
        {
            return ist.AtEnd();
        }

        public override char ReadNext()
        {
            char a = ist.ReadNext();
            if (flaga==false)
            {
                flaga = true;
                return Char.ToUpper(a);
            }
            else
            {
                flaga = false;
                return Char.ToLower(a);
            }

        }
    }
    public class FirstNDecorator : Decorator
    {
        int n;
        int ob = 1;
        public FirstNDecorator(IStream i,int ile) : base(i)
        {
            n = ile;
        }
        public override bool AtEnd()
        {
            if (ist.AtEnd() == true || ob >= n) return true;
            return false;
        }

        public override char ReadNext()
        {
            ob++;
            return ist.ReadNext();
        }
    }
    public class SkipFirstNDecorator : Decorator
    {
        bool flaga = false;
        int n;
        public SkipFirstNDecorator(IStream i,int ile) : base(i)
        {
            n = ile;
        }
        public override bool AtEnd()
        {
            return ist.AtEnd();
        }

        public override char ReadNext()
        {
            if(flaga==false)
            {
                flaga = true;
                for (int i = 0; i < n; i++)
                    ist.ReadNext();
            }
            return ist.ReadNext();
        }
    }
}