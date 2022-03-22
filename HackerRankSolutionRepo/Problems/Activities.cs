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
        public static int activityNotificationso(List<int> expenditure, int d) {
            int arrLength = expenditure.Count;
            var newExpenditure = expenditure.ToArray();
            int[] lastSorted = new int[d];
            int[] freqTable = null;
            bool everSorted = false;
            int alerts = 0;
            int max = new List<int>(expenditure).Max();
            for(int i = d; i < arrLength-1; i++) {
                if (!everSorted) {
                    int[] thisHistory = new int[d];
                    Array.Copy(newExpenditure, i - d, thisHistory, 0, d);
                    var r = countSort(thisHistory, max, null, 0, 0);
                    lastSorted = r.sortedA;
                    freqTable = r.freqTable;
                    everSorted = true;
                } else {
                    int elToRemove = newExpenditure[i - d - 1];
                    int addition = expenditure[i - 1];
                    var r = countSort(lastSorted, max, freqTable, elToRemove, addition);
                    freqTable = r.freqTable;
                    lastSorted = r.sortedA;
                }
                int spent = newExpenditure[i];
                double check = 2 * median(lastSorted);
                if (spent >= check) {
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
            bool replaced = false;
            bool backTrack = false;
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
            if(rIndx < nLen) {
                result[nLen - 1] = number;
            }
            return result;
        }
        public static (int[] sortedA, int[] freqTable) countSort(int[] arr, int tableMax, int[] countArr, int removal, int insertion) {
            int[] result = new int[arr.Length];
            bool isContinuation = false;
            if (countArr is null) {
                int max = tableMax + 1; //new List<int>(arr).Max() + 1;                
                countArr = new int[max];
                for (int i = 0; i < arr.Length; i++) {
                    countArr[arr[i]] += 1;
                }
                int cumm = 0;
                for (int i = 0; i < countArr.Length; i++) {
                    countArr[i] = countArr[i] + cumm;
                    cumm = countArr[i];
                }
            } else {
                int leastIndex = removal < insertion ? removal : insertion;
                /*for(int i = leastIndex; i < tableMax; i++) {
                    if(i >= insertion) {
                        countArr[i] += 1;
                    }
                    if (i >= removal) {
                        countArr[i] -= 1;
                    }
                }*/
                countArr[insertion] += 1;
                countArr[removal] -= 1;
                isContinuation = true;
            }
            bool skipped = false;
            var original = new int[tableMax+1];
            countArr.CopyTo(original, 0);
            for (int i = 0; i < result.Length; i++) {
                if(arr[i] == removal && !skipped && isContinuation) {
                    skipped = true;
                    continue;
                }
                int pos = countArr[arr[i]] - 1;
                result[pos] = arr[i];
                countArr[arr[i]] -= 1;
            }
            if (isContinuation) {
                try {
                    int pos = countArr[insertion] - 1;
                    result[pos] = insertion;
                    countArr[insertion] -= 1;
                } catch(Exception err) {
                    Console.WriteLine(err.ToString());
                }                
            }
            
            return (sortedA:result, freqTable: original);
        }
        public static double median(int[] numbers) {
            int mid = numbers.Length / 2;
            if (numbers.Length%2 == 1) {
                return numbers[mid];
            }
            int v = numbers[mid] + numbers[mid -1];
            return (double)((double)v / 2);
        }
        public static int activityNotifications(List<int> expenditure, int d) {
            int alerts = 0;
            int[] history = new int[d];
            Array.Copy(expenditure.ToArray(), 0, history, 0, d);
            Array.Sort(history);
            for(int i = d; i < expenditure.Count; i++) {
                double check = 2 * median(history);
                if (expenditure[i] >= check) {
                    alerts++;
                }
                //Prepare next data
                //Define elements
                int elToRemove = expenditure[i - d]; //i-d element
                int addition = expenditure[i]; // ith element
                int remIndex = Array.BinarySearch(history, elToRemove);
                Array.Copy(history, remIndex+1, history, remIndex, d - remIndex - 1);
                int addIndex = Array.BinarySearch(history, 0, d - 1, addition);
                addIndex = addIndex >= 0 ? addIndex : ~addIndex;
                Array.Copy(history, addIndex, history, addIndex + 1, d - addIndex - 1);
                history[addIndex] = addition;                
            }
            return alerts;
        }
        public static int lilysHomework(List<int> arr) {
            SortedSet<int> sets = new SortedSet<int>();
            SortedSet<int> setsIn = new SortedSet<int>();
            int arrLen = arr.Count;
            int count = 0;
            int countIn = 0;
            int[] arrCopy = arr.ToArray();
            int[] arrCopyReversed = arr.ToArray();
            arr.Sort();
            for(int i=0; i < arrLen; i++) {
                if (arrCopy[i] == arr[i] && arrCopyReversed[i] == arr[arrLen - i - 1])
                    continue;                
                if(arrCopy[i] != arr[i]) {
                    int setLength = sets.Count;
                    sets.Add(arrCopy[i]);
                    sets.Add(arr[i]);
                    if (sets.Count > setLength)
                        count++;
                }
                if (arrCopyReversed[i] != arr[arrLen - i - 1]) {
                    int setLength = setsIn.Count;
                    setsIn.Add(arrCopy[i]);
                    setsIn.Add(arr[arrLen - i - 1]);
                    if (setsIn.Count > setLength)
                        countIn++;
                }
            }
            return count > countIn? countIn : count;
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
