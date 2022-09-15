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
        public static int[] InsertSort(int[] data) {
            for(int i = 1; i < data.Length; i++) {
                int j = i;
                while(j > 0) {
                    if(data[j] < data[j - 1]) {
                        (data[j - 1], data[j]) = (data[j], data[j - 1]);
                    }
                    j--;
                }
            }
            return data;
        }

        public static int[] SelectionSort(int[] data) {
            for(int i = 0; i < data.Length; i++) {
                int minIndex = i;
                int minValue = data[i];
                for(int j = i; j < data.Length; j++) {
                    if(data[j] < minValue) {
                        minIndex = j;
                        minValue = data[j];
                    }
                }
                (data[i], data[minIndex]) = (data[minIndex], data[i]);
            }
            return data;
        }

        public static int[] BubbleSort(int[] data) {
            while (true) {
                bool swapped = false;
                for (int i = 0; i < data.Length - 1; i++) {
                    if(data[i] > data[i + 1]) {
                        swapped = true;
                        (data[i], data[i + 1]) = (data[i + 1], data[i]);
                    }
                }
                if (!swapped)
                    break;
            }
            return data;
        }
        public static int[] HeapSort(int[] data) {
            int i = 0;
            int n = data.Length;
            int numParents = (n / 2) -1;
            while(numParents >= i) {
                data = heapify(data, n, numParents);
                numParents--;
            }
            for(int j = n -1; j > 0; j--) {
                (data[j], data[0]) = (data[0], data[j]);
                data = heapify(data, j, 0);
            }
            return data;
        }

        public static int[] heapify(int[] data, int size, int rootNode) {
            int leftNode = ((rootNode * 2) + 1);
            int rightNode = ((rootNode * 2) + 2);
            int largestIndex = rootNode;
            if (leftNode < size)
                if (data[leftNode] > data[rootNode])
                    largestIndex = leftNode;
            if (rightNode < size)
                if (data[rightNode] > data[largestIndex])
                    largestIndex = rightNode;
            if (largestIndex != rootNode) {
                (data[largestIndex], data[rootNode]) = (data[rootNode], data[largestIndex]);
                return heapify(data, size, largestIndex);
            }
            return data;
            /*return data;
            int parent = (int)(Math.Ceiling(((decimal)rootNode / 2)) -1);
            return heapify(data, parent);*/
        }

        public static int[] MergeSort(int[] data, int end, int start = 0) {
            if(start < end) {
                int middle = ((start + end + 1) / 2) - 1;
                data = MergeSort(data, middle, start);
                data = MergeSort(data, middle+1, end);
                data = Merge(data, start, middle, end);
            }
            return data;
        }
        public static int[] Merge(int[] data, int lIndex, int midIndex, int rIndex) {
            Console.WriteLine(lIndex+" "+midIndex+" "+rIndex);
            int leftCount = midIndex - lIndex + 1;
            int rightCount = -midIndex + rIndex;
            leftCount = leftCount >= 0 ? leftCount : 0;
            rightCount = rightCount >= 0 ? rightCount : 0;
            int[] subsetr = new int[rightCount];
            int[] subsetl = new int[leftCount];
            Array.Copy(data, lIndex, subsetl, 0, leftCount);
            Array.Copy(data, midIndex+1, subsetr, 0, rightCount);
            int lc = 0;
            int rc = 0;
            for(int tcounter = 0; tcounter < (leftCount + rightCount); tcounter++) {
                if (lc >= leftCount) {
                    data[lIndex + tcounter] = subsetr[rc];
                    rc++;
                    continue;
                }                    
                if (rc >= rightCount) {
                    data[lIndex + tcounter] = subsetl[lc];
                    lc++;
                    continue;
                }
                if(subsetr[rc] >= subsetl[lc]) {
                    data[lIndex + tcounter] = subsetl[lc];
                    lc++;
                    continue;
                }
                if (subsetr[rc] < subsetl[lc]) {
                    data[lIndex + tcounter] = subsetr[rc];
                    rc++;
                    continue;
                }
            }
            return data;
        }
    }
}
