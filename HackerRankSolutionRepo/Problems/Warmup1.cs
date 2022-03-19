using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackerRankSolutionRepo.Problems {
    public class Warmup1 {
        public static void plusMinus(List<int> arr) {
            int length = arr.Count;
            int positives = arr.FindAll(F => F > 0).Count;
            int zeros = arr.FindAll(F => F == 0).Count;
            int negatives = length - positives - zeros;
            double posVal = Math.Round((positives / (double)length), 6);
            double zerVal = Math.Round((zeros / (double)length), 6);
            double negVal = Math.Round((negatives / (double)length), 6);
            Console.WriteLine(posVal);
            Console.WriteLine(negVal);
            Console.WriteLine(zerVal);
        }
        public static void staircase(int n) {
            List<string> strings = new List<string>();
            for(int i = 1; i <= n; i++) {
                string j = new string('#', i);
                j = j.PadLeft(n, ' ');
                strings.Add(j);
            }
            Console.WriteLine(String.Join('\n', strings));
        }
        public static void miniMaxSum(List<long> arr) {
            arr.Sort();
            long tSum = arr.Sum();
            long minsSum = tSum - arr[arr.Count -1];
            long maxsSum = tSum - arr[0];
            Console.WriteLine(minsSum + " " + maxsSum);
        }
        public static int birthdayCakeCandles(List<int> candles) {
            int max = candles.Max();
            return candles.FindAll(F => F == max).Count;
        }
        public static string timeConversion(string s) {
            if (s.EndsWith("AM")) {
                if (s.StartsWith("12")) {
                    s = s.Replace("12:", "00:");                    
                }
                return s.Replace("AM", "");
            }
            if (s.EndsWith("PM")) {
                int d = int.Parse(s.Substring(0, 2));                
                if (s.StartsWith("12")) {
                    s = s.Replace("12:", "00:");
                } else {
                    d = 12 + d;
                    s = s.Remove(0, 2);
                    s = s.Insert(0, d.ToString());
                }
                return s.Replace("PM", "");
            }
            return string.Empty;
        }
        public static int runningTime(List<int> arr) {
            int movement = 0;
            for (int i = 0; i < arr.Count; i++) {
                int j = i;
                while (j > 0) {
                    int a = arr[j - 1];
                    int b = arr[j];
                    if (a > b) {
                        arr[j] = a;
                        arr[j - 1] = b;
                        movement++;
                    }
                    j--;
                }
            }
            return movement;
        }
        public static List<int> quickSort(List<int> arr) {
            int pivot = arr[0];
            var l1 = arr.FindAll(F => F < pivot);
            var r1 = arr.FindAll(F => F > pivot);
            l1.Add(pivot);
            l1.AddRange(r1);
            return l1;
        }
        public static List<int> countingSort(List<int> arr) {
            int max = arr.Max();
            List<int> indexes = Enumerable.Repeat(0, 100).ToList<int>();
            foreach(int i in arr) {
                indexes[i] = indexes[i] + 1;
            }
            return indexes;
        }
        public static List<int> countingSort2(List<int> arr) {
            var arr2 = new List<int>();
            List<int> indexes = Enumerable.Repeat(0, 100).ToList<int>();
            foreach (int i in arr) {
                indexes[i] = indexes[i] + 1;
            }
            int counter = 0;
            foreach(int j in indexes) {
                List<int> n = Enumerable.Repeat(counter, j).ToList<int>();
                arr2.AddRange(n);
                counter++;
            }
            return arr2;
        }
        public static void countSort(string[][] arr) {
            int half = arr.Length / 2;
            var nlist = new string[100];
            StringBuilder[] sb = new StringBuilder[100];
            for (int i = 0; i < arr.Length; i++) {
                string[] strs = arr[i];
                int index = int.Parse(strs[0]);
                string str = strs[1];
                if (i < half) {
                    str = "-";
                }
                if (sb[index] == null) {
                    var builder = new StringBuilder(str);
                    sb[index] = builder;
                } else {
                    sb[index].Append(" " + str);
                }
            }
            Console.WriteLine(String.Join(" ", nlist).Trim());
        }
    }
}
