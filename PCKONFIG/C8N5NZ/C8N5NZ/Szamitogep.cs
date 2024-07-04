using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C8N5NZ
{
    delegate void ElromlikKezelo();
    class Szamitogep
    {
        public Szamitogep()
        {

        }
        public Szamitogep(IHardverElem alaplap, IHardverElem processzor, IHardverElem ram, IHardverElem videokartya)
        {
            this.alaplap=alaplap;
            this.processzor = processzor;
            this.ram = ram;
            this.videokartya = videokartya;
        }
        public IHardverElem alaplap;
        public IHardverElem processzor;
        public IHardverElem ram;
        public IHardverElem videokartya;
    }
    class Alaplap : IHardverElem
    {
        public event ElromlikKezelo AlaplapRomlik;
        public Alaplap(string nev, int ar, int minoseg, Komponens tipus)
        {
            this.nev = nev;
            this.ar = ar;
            this.minoseg = minoseg;
            this.tipus = tipus;
        }
        public string Név { get { return nev; } set { nev = value; } }
        public int Minőség { get { return minoseg; } set { minoseg = value; } }
        public int Ár { get { return ar; } set { ar = value; } }
        public Komponens Típus { get { return tipus; } set { tipus = value; } }
        string nev;
        int ar;
        int minoseg;
        Komponens tipus;

        public void Beépít(Szamitogep gep)
        {
            if (gep.alaplap == this)
            {
                throw new VanMarIlyenException($"Van már egy {this.Típus} beépítve a gépbe!",this);
            }
            else
            {
                gep.alaplap = this;
                Console.WriteLine($"A(z) {this.nev} {this.tipus} beépítve a számítógépbe!");
            }
        }

        public void Elromlik()
        {
            if (AlaplapRomlik != null)
                AlaplapRomlik();
            Console.WriteLine($"A(z) {this.Név} nevű {this.Típus} elromlott!");
        }
    }
    abstract class Processzor : IHardverElem
    {
        public event ElromlikKezelo ProcesszorRomlik;
        public Processzor(string nev, int ar, int minoseg, Komponens tipus)
        {
            this.nev = nev;
            this.ar = ar;
            this.minoseg = minoseg;
            this.tipus = tipus;
        }
        public string Név { get { return nev; } set { nev = value; } }
        public int Minőség { get { return minoseg; } set { minoseg = value; } }
        public int Ár { get { return ar; } set { ar = value; } }
        public Komponens Típus { get { return tipus; } set { tipus = value; } }
        string nev;
        int ar;
        int minoseg;
        Komponens tipus;

        public void Beépít(Szamitogep gep)
        {
            if (gep.processzor == this)
            {
                throw new VanMarIlyenException($"Van már egy {this.Típus} beépítve a gépbe!", this);
            }
            else
            {
                gep.processzor = this;
                Console.WriteLine($"A(z) {this.nev} {this.tipus} beépítve a számítógépbe!");
            }
        }

        public void Elromlik()
        {
            if (ProcesszorRomlik != null)
                ProcesszorRomlik();
            Console.WriteLine($"A(z) {this.Név} nevű {this.Típus} elromlott!");
        }
    }
    class IntelProcesszor : Processzor
    {
        public IntelProcesszor(string nev, int ar, int minoseg, Komponens tipus) : base(nev, ar, minoseg, tipus)
        {

        }
    }
    class RAM : IHardverElem
    {
        public event ElromlikKezelo RAMRomlik;
        public RAM(string nev, int ar, int minoseg, Komponens tipus)
        {
            this.nev = nev;
            this.ar = ar;
            this.minoseg = minoseg;
            this.tipus = tipus;
        }
        public string Név { get { return nev; } set { nev = value; } }
        public int Minőség { get { return minoseg; } set { minoseg = value; } }
        public int Ár { get { return ar; } set { ar = value; } }
        public Komponens Típus { get { return tipus; } set { tipus = value; } }
        string nev;
        int ar;
        int minoseg;
        Komponens tipus;

        public void Beépít(Szamitogep gep)
        {
            if (gep.ram == this)
            {
                throw new VanMarIlyenException($"Van már egy {this.Típus} beépítve a gépbe!", this);
            }
            else
            {
                gep.ram = this;
                Console.WriteLine($"A(z) {this.nev} {this.tipus} beépítve a számítógépbe!");
            }
        }

        public void Elromlik()
        {
            if (RAMRomlik != null)
                RAMRomlik();
            Console.WriteLine($"A(z) {this.Név} nevű {this.Típus} elromlott!");
        }
    }
    class Videokartya : IHardverElem
    {
        public event ElromlikKezelo KartyRomlik;
        public Videokartya(string nev, int ar, int minoseg, Komponens tipus)
        {
            this.nev = nev;
            this.ar = ar;
            this.minoseg = minoseg;
            this.tipus = tipus;
        }
        public string Név { get { return nev; } set { nev = value; } }
        public int Minőség { get { return minoseg; } set { minoseg = value; } }
        public int Ár { get { return ar; } set { ar = value; } }
        public Komponens Típus { get { return tipus; } set { tipus = value; } }
        string nev;
        int ar;
        int minoseg;
        Komponens tipus;

        public void Beépít(Szamitogep gep)
        {
            if (gep.videokartya == this)
            {
                throw new VanMarIlyenException($"Van már egy {this.Típus} beépítve a gépbe!", this);
            }
            else
            {
                gep.videokartya = this;
                Console.WriteLine($"A(z) {this.nev} {this.tipus} beépítve a számítógépbe!");
            }
        }

        public void Elromlik()
        {
            if (KartyRomlik != null)
                KartyRomlik();
            Console.WriteLine($"A(z) {this.Név} nevű {this.Típus} elromlott!");
        }
    }
}
