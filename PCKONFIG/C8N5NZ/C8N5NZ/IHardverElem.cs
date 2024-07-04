using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C8N5NZ
{
    enum Komponens { processzor, alaplap, ram, videokartya }
    interface IHardverElem
    {
        string Név { get; set; }
        int Minőség { get; set; }
        int Ár { get; set; }
        Komponens Típus { get; set; }
        void Beépít(Szamitogep elem);
        void Elromlik();
    }
}
