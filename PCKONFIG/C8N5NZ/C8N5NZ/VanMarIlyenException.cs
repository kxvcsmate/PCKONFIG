using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C8N5NZ
{
    class VanMarIlyenException : Exception
    {
        IHardverElem komponens;
        public IHardverElem Komponens { get => komponens; }
        public VanMarIlyenException(string uzenet, IHardverElem komponens) : base(uzenet)
        {
            this.komponens = komponens;
        }
    }
    class NincsIlyenException : Exception
    {
        public NincsIlyenException(string uzenet) : base (uzenet)
        {

        }
    }
}
