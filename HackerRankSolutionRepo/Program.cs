using HackerRankSolutionRepo.Problems;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HackerRankSolutionRepo {
    class Program {
        static void Main(string[] args) {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);
            /*string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');
            int n = Convert.ToInt32(firstMultipleInput[0]);
            int d = Convert.ToInt32(firstMultipleInput[1]);*/
            //string text = System.IO.File.ReadAllText(@"stext.txt");
            //List<int> expenditure = text.TrimEnd().Split(' ').ToList().Select(expenditureTemp => Convert.ToInt32(expenditureTemp)).ToList();
            try {
                //int result = Activities.lilysHomework(new List<int> { 3, 4, 2, 5, 1 });
                int[] h = new int[] { 2, 9, 5, 3, 7, 4, 7, 1 };
                var k = SortingAlgorithms.MergeSort(h, 7, 0);
                Console.WriteLine(k);
            } catch (Exception err) {
                Console.WriteLine(err.ToString());
            }
            Console.ReadLine();
            //textWriter.Flush();
            //textWriter.Close();
        }
    }
}
