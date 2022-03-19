using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRankSolutionRepo.Problems {
    public class MergeSort {
        public static int numMovement = 0;
        public static int[] sort(int[] arr) {
            if (arr.Length <= 1)
                return arr;
            int midWay = arr.Length/2;
            int[] l = new int[midWay];
            int[] r = new int[arr.Length - midWay];            
            Array.Copy(arr, 0, l, 0, midWay);
            Array.Copy(arr, midWay, r, 0, arr.Length - midWay);
            var left = sort(l);
            var right = sort(r);
            return merge(left, right);
        }
        public static int[] merge(int[] a, int[] b) {
            int alength = a.Length;
            int blength = b.Length;
            int[] sorted = new int[a.Length + b.Length];
            int lMovement = 0;
            int rMovement = 0;
            int counter = 0;
            while (true) {
                if(lMovement >= alength && rMovement >= blength) {
                    break;
                }
                if(lMovement >= alength) {
                    sorted[counter] = b[rMovement];
                    counter++;
                    rMovement++;
                    continue;
                }
                if (rMovement >= blength) {
                    sorted[counter] = a[lMovement];
                    counter++;
                    lMovement++;
                    continue;
                }
                int l = a[lMovement]; int r = b[rMovement];
                if (l > r) {
                    sorted[counter] = r;
                    rMovement++;
                    numMovement = numMovement + (alength - lMovement);
                } else {
                    sorted[counter] = l;
                    lMovement++;
                }
                counter++;
            }
            return sorted;
        }
    }
    public class MergeSortII {
        static int mergeSort(int[] arr, int array_size) {
            int[] temp = new int[array_size];
            return _mergeSort(arr, temp, 0, array_size - 1);
        }

        /* An auxiliary recursive method that sorts the input
          array and returns the number of inversions in the
          array. */
        static int _mergeSort(int[] arr, int[] temp, int left,
                              int right) {
            int mid, inv_count = 0;
            if (right > left) {
                /* Divide the array into two parts and call
               _mergeSortAndCountInv() for each of the parts */
                mid = (right + left) / 2;

                /* Inversion count will be the sum of inversions
              in left-part, right-part
              and number of inversions in merging */
                inv_count += _mergeSort(arr, temp, left, mid);
                inv_count
                    += _mergeSort(arr, temp, mid + 1, right);

                /*Merge the two parts*/
                inv_count
                    += merge(arr, temp, left, mid + 1, right);
            }
            return inv_count;
        }

        /* This method merges two sorted arrays and returns
           inversion count in the arrays.*/
        static int merge(int[] arr, int[] temp, int left,
                         int mid, int right) {
            int i, j, k;
            int inv_count = 0;

            i = left; /* i is index for left subarray*/
            j = mid; /* j is index for right subarray*/
            k = left; /* k is index for resultant merged
                     subarray*/
            while ((i <= mid - 1) && (j <= right)) {
                if (arr[i] <= arr[j]) {
                    temp[k++] = arr[i++];
                } else {
                    temp[k++] = arr[j++];

                    /*this is tricky -- see above
                     * explanation/diagram for merge()*/
                    inv_count = inv_count + (mid - i);
                }
            }

            /* Copy the remaining elements of left subarray
           (if there are any) to temp*/
            while (i <= mid - 1)
                temp[k++] = arr[i++];

            /* Copy the remaining elements of right subarray
           (if there are any) to temp*/
            while (j <= right)
                temp[k++] = arr[j++];

            /*Copy back the merged elements to original array*/
            for (i = left; i <= right; i++)
                arr[i] = temp[i];

            return inv_count;
        }
    }
}