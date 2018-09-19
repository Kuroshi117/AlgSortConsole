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
            //ReadText(@"C:\workspace\FakeData.csv");
            List<int> Test = new List<int>(new int[] { 8, 0, 3, 4, 5, 6, 4 });
            Partition(Test, 0, Test.Count-1);

            Console.ReadKey();
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


        public static void QuickSort(List<int> Sort, int low, int high)
        {
            List<int> SortList = new List<int>();
            for (int i = 0; i < Sort.Count; i++)
            {
                SortList.Add(Sort[i].Item1);
            }

            
        }
        public static int Partition(List<int> Sort, int low, int high)
        {
            int pivot = Sort[high];//pivot = last value
            int LIndex = (low - 1);//Lower index initialized at low-1 so that when LIndex is needed, it will start at index 0 
            for (int RIndex = low; RIndex < (high - 1); RIndex++)//Higher Index that starts at low and goes to the value before pivot
            {
                if (Sort[RIndex] <= Sort[pivot])//if RIndex value is smaller/equal to pivot value
                {
                    LIndex++;//increment LIndex
                    int temp1 = Sort[LIndex];
                    Sort[LIndex] = Sort[RIndex];
                    Sort[RIndex] = temp1;
                    //what it does is that when Partition() finds a value less than pivot, it swaps it with the value after LIndex by having LIndex inrecrement to it and then swapping
                    //In doing so, it pushes the lesser value up the list, and should it push a high value up the list, it will eventually swap it as LIndex with a higher valie RIndex down the line
                }
                int temp2 = Sort[LIndex+1];
                Sort[LIndex+1] = Sort[high];
                Sort[high] = temp2;
                //Once done sorting through everything else, LIndex will eventually be at the index before where pivot should be, so LIndex+1 index has to be swapped with pivot index
                //Also have to swap in Partition because scopes
            }


            for (int i = 0; i < Sort.Count; i++)
            {
                Console.WriteLine(Sort[i].ToString());
            }

            return LIndex + 1;
        }

    }
}
