using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRankSolutionRepo.Problems {
    public static class SortingAlgorithms {
        public static int[] QuickSort(int[] input, int start, int end) {
            if(start < end) {
                var p = Pivot(input, start, end);
                input = p.swapped;
                input = QuickSort(input, start, p.np-1);
                input = QuickSort(input, p.np+1, end);
            }
            return input;
        }
        public static (int np, int[]swapped) Pivot(int[] arr, int startIndex, int pivotIndex) {            
            for(int i = startIndex; i < pivotIndex; i++) {
                if (arr[i] < arr[pivotIndex]) {
                    (arr[i], arr[startIndex]) = (arr[startIndex], arr[i]);
                    startIndex++;
                }
            }
            (arr[pivotIndex], arr[startIndex]) = (arr[startIndex], arr[pivotIndex]);
            return (startIndex, arr);
        }
    }
}
