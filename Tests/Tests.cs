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
    }
}
