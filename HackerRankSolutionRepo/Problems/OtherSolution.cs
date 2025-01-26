using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;

namespace HackerRankSolutionRepo.Problems {
    public static class OtherSolution {
        public static int findMissingNumberInSequentialArray(int[] arr, int n) {
            int sum = 0;
            int sumActual = (n * (n + 1)) / 2;
            for(int i = 0; i < n - 1; i++) {
                sum += arr[i];
            }
            return sumActual - sum;
        }

        public static bool findSuminArray(int[] arr, int n) {
            HashSet<int> itered = new HashSet<int>();            
            for(int i = 0; i < arr.Length; i++) {
                itered.Add(arr[i]);
                if (i == 0)
                    continue;
                var rem = n - arr[i];
                if (itered.Contains(rem))
                    return true;
            }
            return false;
        }

        public static LinkedList<int> linkLists(LinkedList<int> a, LinkedList<int> b) {
            LinkedList<int> final = new LinkedList<int>();            
            while (true) {
                int aCount = a.Count;
                int bCount = b.Count;
                if(aCount > 0 && bCount > 0) {
                    var el1 = a.First;
                    var el2 = b.First;
                    if (el1.Value <= el2.Value) {
                        final.AddLast(el1.Value);
                        a.RemoveFirst();
                    } else {
                        final.AddLast(el2.Value);
                        b.RemoveFirst();
                    }
                }else if(aCount > 0) {
                    final.AddLast(a.First.Value);
                    a.RemoveFirst();
                } else if(bCount > 0) {
                    final.AddLast(b.First.Value);
                    b.RemoveFirst();
                } else {
                    break;
                }
            }
            return final;
        }

        public static int countSolution(int[] coins, int n, int sum) {
            // If sum is 0 then there is 1 solution
            // (do not include any coin)
            if (sum == 0)
                return 1;

            // If sum is less than 0 then no
            // solution exists
            if (sum < 0)
                return 0;

            // If there are no coins and sum
            // is greater than 0, then no
            // solution exist
            if (n <= 0)
                return 0;

            // count is sum of solutions (i)
            // including coins[n-1] (ii) excluding coins[n-1]
            return countSolution(coins, n - 1, sum)
                + countSolution(coins, n, sum - coins[n - 1]);
        }

        public static List<List<int>> countSolutionWhile(int[] coins, int sum) {
            int l = coins.Length - 1;
            List<List<int>> solutions = new List<List<int>>();
            for(int i=l; i >= 0; i--) {
                int lsum = sum;
                List<int> thisSol = new List<int>();
                int nextIn = coins[i];
                while(lsum > 0) {
                    if(lsum >= nextIn) {
                        lsum -= nextIn;
                        thisSol.Add(nextIn);
                    } else {
                        int nextI = i - 1;
                        if (i < 0)
                            break; //No solution Exists
                        nextIn = coins[nextI];
                    }
                }
                if(lsum == 0) {
                    solutions.Add(thisSol);
                }
            }
            return solutions;
        }

        public static int stairsSolution(int n, int[] memo) {
            if (memo == null)
                memo = new int[n+1];
            if (memo[n] != default(int))
                return memo[n];
            if (n == 0 || n == 1)
                return 1;
            if (n < 0)
                return 0;            
            var result = stairsSolution(n - 1, memo) + stairsSolution(n-2, memo);
            memo[n] = result;
            return result;
        }

        public static int coinChangeProblemII(int[] coins, int sum) {
            int[] arrs = new int[sum +1];
            arrs[0] = 1;
            for(int i=0;i < coins.Length; i++) {
                int coin = coins[i];
                for(int j =1; j <= sum; j++) {
                    int r = j - coin;
                    int td = 0;
                    if (r >= 0)
                        td = arrs[r];
                    arrs[j] = arrs[j] + td;
                }
            }
            return arrs[sum];
        }

        public static (int largest, int second) SecondLargest(int[] arrs) {
            int l = 0;
            int s = 0;
            for(int i=0; i < arrs.Length; i++) {
                if (arrs[i] > l) {
                    s = l;
                    l = arrs[i];                    
                }
            }
            return (l, s);
        }

        public static bool ArraySoted(int[] arrs) {
            for (int i = 0; i < arrs.Length-1; i++) {
                if (arrs[i] > arrs[i + 1])
                    return false;
            }
            return true;
        }

        public static int[] UnionArray(int[] arr1, int[] arr2) {
            int lai = 0;
            int rai = 0;
            int lastInsert = -1;
            int maxArr = arr1.Length; maxArr = arr2.Length > maxArr ? arr2.Length : maxArr;
            HashSet<int> fa = new HashSet<int>();
            while (true) {
                bool onedown = lai > arr1.Length - 1;
                bool twodown = rai > arr1.Length - 1;
                if (onedown && twodown)
                    break;
                int l = -1, r = -1;
                if (!onedown) {
                    l = arr1[lai];
                }
                if (!twodown) {
                    r = arr1[rai];
                }
                if (l == r) {
                    fa.Add(l);
                    lastInsert = l;
                }
                if (l == -1) {
                    fa.Add(r);
                } else if (r == -1) {
                    fa.Add(l);
                } else {
                    if (l > r) {
                        fa.Add(r);
                        fa.Add(l);
                    } else if(r>l) {
                        fa.Add(l);
                        fa.Add(r);
                    }
                }
                lai++; rai++;
            }
            return  fa.ToArray();
        }

        public static int LengthOfMaxSubstring(string str) {
            int l, r;
            l = r = 0;
            int max = 0;
            Dictionary<char, int> indices = new Dictionary<char, int>();
            while(r < str.Length) {
                char c = str[r];
                if (indices.ContainsKey(c)) {
                    l = Math.Max(indices[c]+1, l);                    
                }
                indices[c] = r;
                max = Math.Max(max, r - l + 1);
                r++;
            }
            return max;
        }

        public static int GreedyAlgorithm(int[] child, int[] cookie) {
            Array.Sort(child);
            Array.Sort(cookie);
            int nextChild, nextCookie;
            nextChild = nextCookie = 1;
            while(true) {
                if (nextChild >= child.Length || nextCookie >= cookie.Length)
                    break;
                if (child[nextChild] <= cookie[nextCookie]) {
                    nextChild++;
                    nextCookie++;
                } else {
                    nextCookie++;
                }
            }
            return nextChild;
        }
    }
}
