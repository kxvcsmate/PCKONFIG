using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C8N5NZ
{
    class Graf<T>
    {
        public List<List<T>> szomszed = new List<List<T>>();
        public List<T> tartalom = new List<T>();
        public void AddNode(T node)
        {
            tartalom.Add(node);
            szomszed.Add(new List<T>());
        }
        public void AddEdge(T from, T to)
        {
            int From = tartalom.IndexOf(from);
            int To = tartalom.IndexOf(to);

            szomszed[From].Add(tartalom[To]);
            szomszed[To].Add(tartalom[From]);
        }
        public List<T> Neighbors(T node)
        {
            int index = tartalom.IndexOf(node);
            return szomszed[index];
        }
        public List<T> KonkretKereses(string keresett)
        {
            Console.WriteLine("A keresett eszközzel kompatibilis komponensek listája:");
            int index;
            foreach (IHardverElem x in tartalom)
            {
                if (x.Név == keresett)
                {
                    index = tartalom.IndexOf((T)x);
                    return szomszed[index];
                }
            }
            return null;
        }
        public void TipusKereses(Komponens tipus)
        {
            Console.WriteLine("A keresett típusú eszközök listája:");
            foreach (IHardverElem x in tartalom)
            {
                if (x.Típus == tipus)
                {
                    Console.WriteLine("Neve: " + x.Név + ", Ár: " + x.Ár + "Ft, minőség: " + x.Minőség);
                }
            }
        }
        public Szamitogep Legolcsobb(Graf<IHardverElem> g)
        {
            Szamitogep sz = new Szamitogep();
            int minindex = 0;
            int min = 0;
            int k = 0;
            for (int i = 0; i < g.tartalom.Count; i++)
            {
                if (g.tartalom[i].Típus == Komponens.alaplap)
                {
                    k++;
                    if (k == 1)
                    {
                        min = g.tartalom[i].Ár;
                        minindex = i;
                    }
                    if (g.tartalom[i].Ár < min)
                    {
                        min = g.tartalom[i].Ár;
                        minindex = i;
                    }
                }
            }
            int min1 = 0;
            int min2 = 0;
            int min3 = 0;

            int minindex1 = 0;
            int minindex2 = 0;
            int minindex3 = 0;

            int k1 = 0;
            int k2 = 0;
            int k3 = 0;
            for (int i = 0; i < g.szomszed[minindex].Count; i++)
            {
                if (g.szomszed[minindex][i].Típus == Komponens.processzor)
                {
                    k1++;
                    if (k1 == 1)
                    {
                        min1 = g.szomszed[minindex][i].Ár;
                        minindex1 = i;
                    }
                    if (g.szomszed[minindex][i].Ár < min1)
                    {
                        min1 = g.szomszed[minindex][i].Ár;
                        minindex1 = i;
                    }
                }
                else if (g.szomszed[minindex][i].Típus == Komponens.ram)
                {
                    k2++;
                    if (k2 == 1)
                    {
                        min2 = g.szomszed[minindex][i].Ár;
                        minindex2 = i;
                    }
                    if (g.szomszed[minindex][i].Ár < min2)
                    {
                        min2 = g.szomszed[minindex][i].Ár;
                        minindex2 = i;
                    }
                }
                else if (g.szomszed[minindex][i].Típus == Komponens.videokartya)
                {
                    k3++;
                    if (k3 == 1)
                    {
                        min3 = g.szomszed[minindex][i].Ár;
                        minindex3 = i;
                    }
                    if (g.szomszed[minindex][i].Ár < min3)
                    {
                        min3 = g.szomszed[minindex][i].Ár;
                        minindex3 = i;
                    }
                }
            }
            sz.alaplap = g.tartalom[minindex];
            sz.processzor = g.szomszed[minindex][minindex1];
            sz.ram = g.szomszed[minindex][minindex2];
            sz.videokartya = g.szomszed[minindex][minindex3];

            return sz;
        }
        public Szamitogep LegjobbMinoseg(Graf<IHardverElem> g)
        {
            Szamitogep sz = new Szamitogep();
            int maxindex = 0;
            int max = 0;
            int k = 0;
            for (int i = 0; i < g.tartalom.Count; i++)
            {
                if (g.tartalom[i].Típus == Komponens.alaplap)
                {
                    k++;
                    if (k == 1)
                    {
                        max = g.tartalom[i].Minőség;
                        maxindex = i;
                    }
                    if (g.tartalom[i].Minőség > max)
                    {
                        max = g.tartalom[i].Minőség;
                        maxindex = i;
                    }
                }
            }
            int max1 = 0;
            int max2 = 0;
            int max3 = 0;

            int maxindex1 = 0;
            int maxindex2 = 0;
            int maxindex3 = 0;

            int k1 = 0;
            int k2 = 0;
            int k3 = 0;
            for (int i = 0; i < g.szomszed[maxindex].Count; i++)
            {
                if (g.szomszed[maxindex][i].Típus == Komponens.processzor)
                {
                    k1++;
                    if (k1 == 1)
                    {
                        max1 = g.szomszed[maxindex][i].Minőség;
                        maxindex1 = i;
                    }
                    if (g.szomszed[maxindex][i].Minőség > max1)
                    {
                        max1 = g.szomszed[maxindex][i].Minőség;
                        maxindex1 = i;
                    }
                }
                else if (g.szomszed[maxindex][i].Típus == Komponens.ram)
                {
                    k2++;
                    if (k2 == 1)
                    {
                        max2 = g.szomszed[maxindex][i].Minőség;
                        maxindex2 = i;
                    }
                    if (g.szomszed[maxindex][i].Minőség > max2)
                    {
                        max2 = g.szomszed[maxindex][i].Minőség;
                        maxindex2 = i;
                    }
                }
                else if (g.szomszed[maxindex][i].Típus == Komponens.videokartya)
                {
                    k3++;
                    if (k3 == 1)
                    {
                        max3 = g.szomszed[maxindex][i].Minőség;
                        maxindex3 = i;
                    }
                    if (g.szomszed[maxindex][i].Minőség > max3)
                    {
                        max3 = g.szomszed[maxindex][i].Minőség;
                        maxindex3 = i;
                    }
                }
            }
            sz.alaplap = g.tartalom[maxindex];
            sz.processzor = g.szomszed[maxindex][maxindex1];
            sz.ram = g.szomszed[maxindex][maxindex2];
            sz.videokartya = g.szomszed[maxindex][maxindex3];

            return sz;
        }
    }
}
