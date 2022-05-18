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
            for (int i = 1; i <= n; i++) {
                string j = new string('#', i);
                j = j.PadLeft(n, ' ');
                strings.Add(j);
            }
            Console.WriteLine(String.Join('\n', strings));
        }
        public static void miniMaxSum(List<long> arr) {
            arr.Sort();
            long tSum = arr.Sum();
            long minsSum = tSum - arr[arr.Count - 1];
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
            foreach (int i in arr) {
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
            foreach (int j in indexes) {
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

        public static int pointsBelong(int x1, int y1, int x2, int y2, int x3, int y3, int xp, int yp, int xq, int yq) {
            var side1 = solveLength(x1, y1, x2, y2);
            var side2 = solveLength(x1, y1, x3, y3);
            var side3 = solveLength(x2, y2, x3, y3);
            List<int> xax = new List<int> { x1, x2, x3 };
            List<int> yax = new List<int> { y1, y2, y3 };
            xax.Sort();
            yax.Sort();
            if (side1 + side2 <= side3) {
                return 0;
            }
            if (side1 + side3 <= side2) {
                return 0;
            }
            if (side2 + side3 <= side1) {
                return 0;
            }
            int qvalid = 0;
            int pvalid = 0;
            if (xax[0] <= xp && yax[2] >= yp) {
                pvalid = 1;
            }
            if (xax[0] <= xq && yax[2] >= yq) {
                qvalid = 2;
            }
            if (qvalid + pvalid == 0) {
                return 4;
            }
            return qvalid + pvalid;
        }
        public static double solveLength(int x1, int y1, int x2, int y2) {
            if (x1 == x2) {
                int l = y2 - y1;
                return l < 0 ? -1 * l : l;
            }
            if (y1 == y2) {
                int l = x2 - x1;
                return l < 0 ? -1 * l : l;
            }
            var xq = (x2 - x1);
            xq = xq * xq;
            var yq = (y2 - y1);
            yq = yq * yq;
            return Math.Sqrt((yq + xq));
        }
        public static void closestNumbers(List<int> numbers) {
            numbers.Sort();
            var number = numbers.ToArray();
            int[] difference = new int[number.Length - 1];
            int min = number[number.Length - 1];
            for (int i = 0; i < number.Length - 1; i++) {
                difference[i] = number[i + 1] - number[i];
                if (difference[i] < min) {
                    min = difference[i];
                }
            }
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < difference.Length; i++) {
                if (difference[i] <= min) {
                    sb.Append(number[i] + " " + number[i + 1] + "\n");
                }
            }
            Console.Write(sb.ToString());
        }

        public static List<int> getRanks(List<int> ranked, List<int> player) {
            List<int> rankingResult = new List<int>();
            SortedSet<int> ranks = new SortedSet<int>(ranked);
            int originalLen = ranks.Count;
            for (int i = 0; i < player.Count; i++) {
                ranks.Add(player[i]);
                int lc = ranks.Count;
                int ind = ranks.ToList<int>().IndexOf(player[i]);
                rankingResult.Add(lc - ind);
                if (originalLen < lc) {
                    ranks.Remove(player[i]);
                }
            }
            return rankingResult;
        }

        public static List<int> getRanks2(List<int> ranked, List<int> player) {
            int[] rankingResult = new int[player.Count];
            int[] ranks = new SortedSet<int>(ranked).ToArray<int>();
            int[] playerO = player.ToArray();
            for (int i = 0; i < playerO.Length; i++) {
                int pos = index(ranks, playerO[i]);
                rankingResult[i] = pos;
            }
            return new List<int>(rankingResult);
        }

        public static int index(int[] ol, int num) {
            for(int i = 0; i < ol.Length; i++) {
                if(ol[i] > num) {
                    int r = ol.Length + 1 - i;
                    return r;
                }
                if (ol[i] == num) {
                    int r = ol.Length - i;
                    return r;
                }
            }
            return 1;
        }

    }

}
