using HackerRankSolutionRepo.Problems;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests {
    [TestFixture]
    public class Tests {
        [SetUp]
        public void Setup() {

        }
        [TestCase]
        public void testMerge() {
            int[] a = new int[] { 1, 3, 6 };
            int[] b = new int[] { 2, 4, 5 };
            var c = MergeSort.merge(a, b);
            Assert.AreEqual(c, new int[] { 1, 2, 3, 4, 5, 6});
        }

        [TestCase]
        public void testMergeII() {
            int[] a = new int[] { 1, 3, 6 };
            int[] b = new int[] { 2, 4, 5, 6, 7, 9 };
            var c = MergeSort.merge(a, b);
            Assert.AreEqual(c, new int[] { 1, 2, 3, 4, 5, 6, 6, 7, 9 });
        }

        [TestCase]
        public void testMergeIII() {
            int[] a = new int[] { 1, 3, 6 };
            int[] b = new int[] { 2, 4, 5, 6 };
            var c = MergeSort.merge(a, b);
            Assert.AreEqual(c, new int[] { 1, 2, 3, 4, 5, 6, 6 });
        }

        [TestCase]
        public void mergeSort() {
            int[] a = new int[] { 2, 1, 3, 1, 2 };
            var c = MergeSort.sort(a);
            int numMove = MergeSort.numMovement;
            Assert.AreEqual(c, new int[] { 1, 1, 2, 2, 3 });
        }

        [TestCase]
        public void mergeSortII() {
            int[] a = new int[] { 4, 3, 2, 1 };
            var c = MergeSort.sort(a);
            int numMove = MergeSort.numMovement;
            Assert.AreEqual(c, new int[] { 1, 2, 3, 4 });
        }

        [TestCase]
        public void mergeSortIII() {
            int[] a = new int[] { 12, 15, 1, 5, 6, 14, 11 };
            var c = MergeSort.sort(a);
            int numMove = MergeSort.numMovement;
            Assert.AreEqual(c, new int[] { 1, 5, 6, 11, 12, 14, 15 });
        }

        [TestCase]
        public void insertAndSortTest() {
            int[] a = new int[] { 1, 5, 6, 11, 12, 14, 15 };
            var r = Activities.insertAndSort(a, 6, 3);
            Assert.AreEqual(r, new int[] { 1, 3, 5, 11, 12, 14, 15 });
        }

        [TestCase]
        public void insertAndSortTestII() {
            int[] a = new int[] { 1, 5, 6, 11, 12, 14, 15 };
            var r = Activities.insertAndSort(a, 11, 1);
            Assert.AreEqual(r, new int[] { 1, 1, 5, 6, 12, 14, 15 });
        }

        [TestCase]
        public void insertAndSortTestIII() {
            int[] a = new int[] { 1, 5, 6, 11, 12, 15 };
            var r = Activities.insertAndSort(a, 14, 16);
            Assert.AreEqual(r, new int[] { 1, 5, 6, 11, 12, 15, 16 });
        }

        [TestCase]
        public void insertAndSortTestIV() {
            int[] a = new int[] { 1, 5, 11, 12, 14, 15 };
            var r = Activities.insertAndSort(a, 6, 13);
            Assert.AreEqual(r, new int[] { 1, 5, 11, 12, 13, 14, 15 });
        }

        [TestCase]
        public void medianCal() {
            int[] a = new int[] { 1, 5, 6, 11, 12, 14, 15 };
            var r = Activities.median(a);
            Assert.AreEqual(r, 11);
        }

        [TestCase]
        public void medianCalII() {
            int[] a = new int[] { 1, 5, 6, 11, 12, 14, 15, 67 };
            var r = Activities.median(a);
            var expected = (double)((double)(11 + 12) / 2);
            Assert.AreEqual(r, expected);
        }

        [TestCase]
        public void fraudAlertTest() {
            int[] a = new int[] { 2, 3, 4, 2, 3, 6, 8, 4, 5 };
            var r = Activities.activityNotifications(new List<int>(a), 5);
            Assert.AreEqual(r, 2);
        }

    }
}
