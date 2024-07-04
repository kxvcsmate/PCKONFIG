using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C8N5NZ
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = File.ReadAllText("adatok.txt", Encoding.Default);
            string[] row = text.Split('#');
            int meret = row[0].Split('*').Length;
            string[][] eszkozok = new string[row.Length][];
            for (int i = 0; i < eszkozok.Length; i++)
            {
                eszkozok[i] = row[i].Split('*', ',');
            }
            Alaplap[] alaplap = new Alaplap[meret];
            Processzor[] cpu = new Processzor[meret];
            RAM[] ram = new RAM[meret];
            Videokartya[] gpu = new Videokartya[meret];
            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    alaplap[i] = new Alaplap(eszkozok[0][j], int.Parse(eszkozok[0][j + 1]), int.Parse(eszkozok[0][j + 2]), (Komponens)Enum.Parse(typeof(Komponens), eszkozok[0][j + 3]));
                }
                for (int j = 4; j < 5; j++)
                {
                    alaplap[i + 1] = new Alaplap(eszkozok[0][j], int.Parse(eszkozok[0][j + 1]), int.Parse(eszkozok[0][j + 2]), (Komponens)Enum.Parse(typeof(Komponens), eszkozok[0][j + 3]));
                }
                for (int j = 8; j < 9; j++)
                {
                    alaplap[i + 2] = new Alaplap(eszkozok[0][j], int.Parse(eszkozok[0][j + 1]), int.Parse(eszkozok[0][j + 2]), (Komponens)Enum.Parse(typeof(Komponens), eszkozok[0][j + 3]));
                }
                for (int j = 0; j < 1; j++)
                {
                    cpu[i] = new IntelProcesszor(eszkozok[1][j], int.Parse(eszkozok[1][j + 1]), int.Parse(eszkozok[1][j + 2]), (Komponens)Enum.Parse(typeof(Komponens), eszkozok[1][j + 3]));
                }
                for (int j = 4; j < 5; j++)
                {
                    cpu[i + 1] = new IntelProcesszor(eszkozok[1][j], int.Parse(eszkozok[1][j + 1]), int.Parse(eszkozok[1][j + 2]), (Komponens)Enum.Parse(typeof(Komponens), eszkozok[1][j + 3]));
                }
                for (int j = 8; j < 9; j++)
                {
                    cpu[i + 2] = new IntelProcesszor(eszkozok[1][j], int.Parse(eszkozok[1][j + 1]), int.Parse(eszkozok[1][j + 2]), (Komponens)Enum.Parse(typeof(Komponens), eszkozok[1][j + 3]));
                }
                for (int j = 0; j < 1; j++)
                {
                    ram[i] = new RAM(eszkozok[2][j], int.Parse(eszkozok[2][j + 1]), int.Parse(eszkozok[2][j + 2]), (Komponens)Enum.Parse(typeof(Komponens), eszkozok[2][j + 3]));
                }
                for (int j = 4; j < 5; j++)
                {
                    ram[i + 1] = new RAM(eszkozok[2][j], int.Parse(eszkozok[2][j + 1]), int.Parse(eszkozok[2][j + 2]), (Komponens)Enum.Parse(typeof(Komponens), eszkozok[2][j + 3]));
                }
                for (int j = 8; j < 9; j++)
                {
                    ram[i + 2] = new RAM(eszkozok[2][j], int.Parse(eszkozok[2][j + 1]), int.Parse(eszkozok[2][j + 2]), (Komponens)Enum.Parse(typeof(Komponens), eszkozok[2][j + 3]));
                }
                for (int j = 0; j < 1; j++)
                {
                    gpu[i] = new Videokartya(eszkozok[3][j], int.Parse(eszkozok[3][j + 1]), int.Parse(eszkozok[3][j + 2]), (Komponens)Enum.Parse(typeof(Komponens), eszkozok[3][j + 3]));
                }
                for (int j = 4; j < 5; j++)
                {
                    gpu[i + 1] = new Videokartya(eszkozok[3][j], int.Parse(eszkozok[3][j + 1]), int.Parse(eszkozok[3][j + 2]), (Komponens)Enum.Parse(typeof(Komponens), eszkozok[3][j + 3]));
                }
                for (int j = 8; j < 9; j++)
                {
                    gpu[i + 2] = new Videokartya(eszkozok[3][j], int.Parse(eszkozok[3][j + 1]), int.Parse(eszkozok[3][j + 2]), (Komponens)Enum.Parse(typeof(Komponens), eszkozok[3][j + 3]));
                }
            }

            Graf<IHardverElem> graf = new Graf<IHardverElem>();
            Szamitogep pc1 = new Szamitogep();
            
            alaplap[0].Beépít(pc1);
            cpu[1].Beépít(pc1);
            ram[2].Beépít(pc1);
            gpu[2].Beépít(pc1);
            Console.WriteLine();

            alaplap[0].Elromlik();
            ram[2].Elromlik();
            gpu[1].Elromlik();
            Console.WriteLine();

            graf.AddNode(alaplap[0]);
            graf.AddNode(alaplap[1]);
            graf.AddNode(alaplap[2]);
            graf.AddNode(cpu[0]);
            graf.AddNode(cpu[1]);
            graf.AddNode(cpu[2]);
            graf.AddNode(ram[0]);
            graf.AddNode(ram[1]);
            graf.AddNode(ram[2]);
            graf.AddNode(gpu[0]);
            graf.AddNode(gpu[1]);
            graf.AddNode(gpu[2]);

            graf.AddEdge(alaplap[0], cpu[0]);
            graf.AddEdge(alaplap[0], cpu[1]);
            graf.AddEdge(alaplap[0], ram[0]);
            graf.AddEdge(alaplap[0], ram[1]);
            graf.AddEdge(alaplap[0], ram[2]);
            graf.AddEdge(alaplap[0], gpu[2]);

            graf.AddEdge(alaplap[1], cpu[0]);
            graf.AddEdge(alaplap[1], cpu[1]);
            graf.AddEdge(alaplap[1], ram[0]);
            graf.AddEdge(alaplap[1], ram[2]);
            graf.AddEdge(alaplap[1], gpu[0]);
            graf.AddEdge(alaplap[1], gpu[1]);

            graf.AddEdge(alaplap[2], cpu[2]);
            graf.AddEdge(alaplap[2], ram[2]);
            graf.AddEdge(alaplap[2], gpu[0]);
            graf.AddEdge(alaplap[2], gpu[1]);
            graf.AddEdge(alaplap[2], gpu[2]);

            List<IHardverElem> keresett = graf.KonkretKereses("Intel");
            for (int i = 0; i < keresett.Count; i++)
            {
                Console.WriteLine("Neve: " + keresett[i].Név + " " + keresett[i].Típus + ", Ár: "
                    + keresett[i].Ár + "Ft, minőség: " + keresett[i].Minőség);
            }
            Console.WriteLine();

            graf.TipusKereses(Komponens.processzor);
            Console.WriteLine();

            Szamitogep pc2 = graf.Legolcsobb(graf);
            Console.WriteLine("A legolcsóbb összeállítás:");
            Console.WriteLine(pc2.alaplap.Név + " " + pc2.alaplap.Típus + " " + pc2.alaplap.Ár + "Ft, "
                + pc2.processzor.Név + " " + pc2.processzor.Típus + " " + pc2.processzor.Ár + "Ft, "
                + pc2.ram.Név + " " + pc2.ram.Típus + " " + pc2.ram.Ár + "Ft, "
                + pc2.videokartya.Név + " " + pc2.videokartya.Típus + " " + pc2.videokartya.Ár + "Ft");
            Console.WriteLine();

            Szamitogep pc3 = graf.LegjobbMinoseg(graf);
            Console.WriteLine("A legjobb minőségü összeállítás:");
            Console.WriteLine(pc3.alaplap.Név + " " + pc3.alaplap.Típus + " minőség: " + pc3.alaplap.Minőség + ", "
                + pc3.processzor.Név + " " + pc3.processzor.Típus + " minőség: " + pc3.processzor.Minőség + ", "
                + pc3.ram.Név + " " + pc3.ram.Típus + " minőség: " + pc3.ram.Minőség + ", "
                + pc3.videokartya.Név + " " + pc3.videokartya.Típus + " minőség: " + pc3.videokartya.Minőség);

            Console.ReadLine();
        }
    }
}
