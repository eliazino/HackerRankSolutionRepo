using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackerRankSolutionRepo.Problems {
    public class Activities {
        public static List<int> closestNumbers(List<int> arr) {
            arr.Sort();
            NumberLog[] nlogs = new NumberLog[arr.Count - 1];
            int minValue = arr[arr.Count -1];
            for(int i=0; i < arr.Count-1; i++) {
                int difference = arr[i + 1] - arr[i];
                minValue = minValue < difference ? minValue : difference;
                nlogs[i] = new NumberLog { difference = difference, left = arr[i], right = arr[i + 1] };
            }
            List<int> results = new List<int>();
            int y = 0;
            for(int c = 0; c < nlogs.Length; c++) {
                if(nlogs[c].difference == minValue) {
                    results.Add(nlogs[c].left);
                    results.Add(nlogs[c].right);
                    y++;
                }
            }
            return results;
        }
        public static int insertionSort(List<int> arr) {
            int count = 0;
            int arrCount = arr.Count;
            var arra = arr.ToArray();
            for (int i=0; i < arrCount-1; i++) {
                for(int j = i+1; j < arrCount; j++) {
                    if (arra[i] > arra[j])
                        count++;
                }
            }
            return count;
        }
        private static int getArray(int[] arr, int endIndex, int compararer) {
            int a = 0;
            for(int i=0; i <= endIndex; i++) {
                if (compararer < arr[i]) {
                    a++;
                }
            }
            return a;
        }
        public class NumberLog {
            public int right { get; set; }
            public int left { get; set; }
            public int difference { get; set; }
        }
        public static int RomanToInt(string s) {
            int sum = 0;
            int counter = 0;            
            int sLen = s.Length;
            int nextValue = sLen < 2 ? sLen : 2;
            while (true) {
                if (counter >= sLen)
                    break;
                string c = s.Substring(counter, nextValue);
                int j = 0;
                if(c.Length == 1) {
                    j = (int)(Romans)Enum.Parse(typeof(Romans), c);
                } else {
                    int a = (int)(Romans)Enum.Parse(typeof(Romans), c[0].ToString());
                    int b = (int)(Romans)Enum.Parse(typeof(Romans), c[1].ToString());
                    if(a < b) {
                        j = b - a;
                    } else {
                        j = a;
                        nextValue = 1;
                    }
                }
                sum = sum + j;
                counter = counter + nextValue;
                nextValue = sLen - counter;
                if(nextValue > 2) {
                    nextValue = 2;
                }
            }
            return sum;
        }
        public static int activityNotifications(List<int> expenditure, int d) {
            int arrLength = expenditure.Count;
            var newExpenditure = expenditure.ToArray();
            int[] lastSorted = new int[d];
            int[] thisHistory = new int[d];
            bool everSorted = false;
            int alerts = 0;
            for(int i = d; i < arrLength-1; i++) {
                thisHistory = new int[d];
                Array.Copy(newExpenditure, i-d, thisHistory, 0, d);
                if (!everSorted) {                    
                    lastSorted = iSort(thisHistory);
                    everSorted = true;
                } else {
                    int elToRemove = newExpenditure[i - d - 1];
                    //lastSorted = insertAndSort(lastSorted.Skip(0).ToArray(), newExpenditure[d]);
                }
                if(newExpenditure[d+1] >= 2 * median(lastSorted)) {
                    alerts++;
                }
            }
            return alerts;
        }
        public static int[] iSort(int[] numbers) {
            List<int> result = new List<int>(numbers);
            result.Sort();
            return result.ToArray();
        }
        public static int[] insertAndSort(int[] numbers, int num2Replace, int number) {
            int[] result = new int[numbers.Length];
            int nLen = numbers.Length;
            bool sorted = false;
            bool replaced = false;
            bool backTrack = false;
            if(numbers[0] >= number) {
                result[0] = number;
                Array.Copy(numbers, 0, result, 1, nLen);
                sorted = true;
            }
            if (numbers[nLen-1] <= number) {
                result[result.Length - 1] = number;
                Array.Copy(numbers, 0, result, 0, nLen);
                sorted = true;
            }
            if (sorted)
                return result;
            int rIndx = 0;
            for (int i=0; i < nLen; i++) {
                if(numbers[i] > number && !backTrack) {
                    result[rIndx] = number;
                    backTrack = true;
                    i = i - 1;
                } else {
                    if (numbers[i] == num2Replace && !replaced) {
                        replaced = true;
                        continue;
                    }
                    result[rIndx] = numbers[i];
                }
                rIndx++;
            }
            return result;
        }
        public static double median(int[] numbers) {
            int mid = numbers.Length / 2;
            if (numbers.Length%2 == 1) {
                return numbers[mid];
            }
            int v = numbers[mid] + numbers[mid -1];
            return (double)((double)v / 2);
        }
        public enum Romans{
            I = 1,
            V = 5,
            X = 10,
            L = 50,
            C = 100,
            D = 500,
            M = 1000
        }
    }
}
