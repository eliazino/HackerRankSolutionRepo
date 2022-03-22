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
            string text = System.IO.File.ReadAllText(@"stext.txt");
            List<int> expenditure = text.TrimEnd().Split(' ').ToList().Select(expenditureTemp => Convert.ToInt32(expenditureTemp)).ToList();
            try {
                int result = Activities.lilysHomework(expenditure);
                Console.WriteLine(result);
            } catch (Exception err) {
                Console.WriteLine(err.ToString());
            }
            Console.ReadLine();
            //textWriter.Flush();
            //textWriter.Close();
        }
    }
}
