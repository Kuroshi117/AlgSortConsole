using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AlgSortConsole
{
    class Program
    {
        //Guid->Decimal
        public static List<Tuple<int, Guid, double>> Tupperware = new List<Tuple<int, Guid, double>>();
        static void Main(string[] args)
        {
            ReadText(@"C:\workspace\FakeData.csv");
        }

        public static void ReadText(string path)
        {
            string line;
            string[] words = new string[3];
            using (StreamReader sr=new StreamReader(path))
            {
                while((line = sr.ReadLine()) != null)
                {
                    words = line.Split(',');
                    Tupperware.Add(Tuple.Create(Convert.ToInt32(words[0]), Guid.Parse(words[1]) , Convert.ToDouble(words[2])));
                    
                }
               
            }
        }

        public static void QuickSort(int low, int high)
        {
            List<int> SortList = new List<int>();
            for (int i = 0; i < Tupperware.Count; i++)
            {
                SortList.Add(Tupperware[i].Item1);
            }

            
        }
        public static void Partition(List<int> Sort, int low, int high)
        {
            int RIndex = high;
            int LIndex = low;
            int PIndex = (high - low) / 2;
            int pivot = Sort[PIndex];
           
        }
            public static void swap(int a, int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

    }
}
