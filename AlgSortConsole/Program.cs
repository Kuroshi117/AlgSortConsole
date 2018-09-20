using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace AlgSortConsole
{
    class Program
    {
        //Guid->Decimal
        public static List<Tuple<int, Guid, double>> Tupperware = new List<Tuple<int, Guid, double>>();
        
        static void Main(string[] args)
        {
            ReadText(@"C:\workspace\FakeData.csv");
            Stopwatch sw = Stopwatch.StartNew();
            SortByDoubleUsingQuickSort(Tupperware, 0, 1000000);
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds+" ms");
            for (int i = 0; i < Tupperware.Count; i++)
            {
                Console.Write(i.ToString()+": ");
                Console.WriteLine(Tupperware[i].ToString());
            }
            Console.ReadKey();
        }

        public static void ReadText(string path)
        {
            string line;
            string[] words = new string[3];
            using (StreamReader sr = new StreamReader(path))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    words = line.Split(',');
                    Tupperware.Add(Tuple.Create(Convert.ToInt32(words[0]), Guid.Parse(words[1]), Convert.ToDouble(words[2])));

                }

            }
        }

        //int versions
        //Worse case scenario-if pivot = largest/smallest value, each successive list is n-1 size
        //So, for now, pivot is (high-low)/2+low
        public static void SortByIDUsingQuickSort(List<Tuple<int, Guid, double>> Sort, int low, int high)
        {
            if (low < high)
            {
                int pi = PartitionByID(Sort, low, high);
                SortByIDUsingQuickSort(Sort, low, pi - 1);
                SortByIDUsingQuickSort(Sort, pi + 1, high);
            }
      
        }
        public static int PartitionByID(List<Tuple<int, Guid, double>> Sort, int low, int high)
        {
            int pivot = Sort[(high-low)/2+low].Item1;
            int LIndex = (low - 1);
            for (int RIndex = low; RIndex < (high - 1); RIndex++)
            {
                if (Sort[RIndex].Item1 <= pivot)
                {
                    LIndex++;
                    Tuple<int, Guid, double> temp1 = Sort[LIndex];
                    Sort[LIndex] = Sort[RIndex];
                    Sort[RIndex] = temp1;
                }
                Tuple<int, Guid, double> temp2 = Sort[LIndex + 1];
                Sort[LIndex + 1] = Sort[high];
                Sort[high] = temp2;
            }
            return LIndex + 1;
        }

        //double versions
        public static void SortByDoubleUsingQuickSort(List<Tuple<int, Guid, double>> Sort, int low, int high)
        {
            if (low < high)
            {
                int pi = PartitionByDouble(Sort, low, high);
                SortByDoubleUsingQuickSort(Sort, low, pi - 1);
                SortByDoubleUsingQuickSort(Sort, pi + 1, high);
            }
            
        }
        public static int PartitionByDouble(List<Tuple<int, Guid, double>> Sort, int low, int high)
        {
            double pivot = Sort[high].Item3;
            int LIndex = (low - 1);
            for (int RIndex = low; RIndex < (high - 1); RIndex++)
            {
                if (Sort[RIndex].Item3 <= pivot)
                {
                    LIndex++;
                    Tuple<int, Guid, double> temp1 = Sort[LIndex];
                    Sort[LIndex] = Sort[RIndex];
                    Sort[RIndex] = temp1;
                }
                Tuple<int, Guid, double> temp2 = Sort[LIndex + 1];
                Sort[LIndex + 1] = Sort[high];
                Sort[high] = temp2;
            }
            return LIndex + 1;
        }


















    }
}