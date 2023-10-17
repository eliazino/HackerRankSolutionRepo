using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRankSolutionRepo.Problems {
    public static class TwoPointers {
        public static int[] pairWithTargetSum(int[] arrs, int target) {
            Dictionary<int, int> dic = new Dictionary<int, int>();            
            for(int i =0; i < arrs.Length; i++) {
                int diff = target - arrs[i];
                if (dic.ContainsKey(diff)) {
                    return new int[] { dic[diff], i };
                } else {
                    dic[arrs[i]] = i;
                }
            }
            return new int[] { };
        }

        public static int[] removeDuplicates(int[] arr) {            
            HashSet<int> di = new HashSet<int>();
            int lastUtilizedIndex = 0;
            for(int i = 0; i < arr.Length; i++) {
                if (di.Contains(arr[i])) {
                    
                } else {
                    di.Add(arr[i]);
                    if(lastUtilizedIndex < i) {
                        (arr[lastUtilizedIndex], arr[i]) = (arr[i], arr[lastUtilizedIndex]);
                    }
                    lastUtilizedIndex++;
                }
            }
            return arr;
        }

        public static int[] SortedSquares(int[] nums) {
            int[] newNum = new int[nums.Length];
            int startPos = 0;
            int endPos = nums.Length-1;
            int inserted = nums.Length -1;
            for(int i=0; i < nums.Length; i++) {
                if (inserted <= -1)
                    break;
                if (nums[startPos] < 0 && nums[endPos] >= 0) {
                    int neg = nums[startPos] * nums[startPos];
                    int pos = nums[endPos] * nums[endPos];
                    if(neg < pos) {
                        newNum[inserted] = pos;
                        inserted--;
                        newNum[inserted] = neg;
                        inserted--;
                    } else {
                        newNum[inserted] = neg;
                        inserted--;
                        newNum[inserted] = pos;
                        inserted--;
                    }
                    startPos++;
                    endPos--;
                } else {
                    if (nums[startPos] > 0) {
                        newNum[inserted] = nums[startPos] * nums[startPos];
                        inserted--;
                        startPos++;
                    } else {
                        newNum[inserted] = nums[endPos] * nums[endPos];
                        inserted--;
                        endPos--;
                    }
                        
                }
            }
            return newNum;
        }
    }
}
