using HackerRankSolutionRepo.Problems;
using NUnit.Framework;

namespace Tests {
    [TestFixture]
    internal class TwoPointersTests {
        [TestCase]
        public void pairWithTargetSum() {
            var result = TwoPointers.pairWithTargetSum(new int[] { 1, 2, 3, 4, 6 }, 6);
            Assert.AreEqual(result, new int[] { 1, 3 });
            result = TwoPointers.pairWithTargetSum(new int[] { 2, 5, 9, 11 }, 11);
            Assert.AreEqual(result, new int[] { 0, 2 });
            result = TwoPointers.pairWithTargetSum(new int[] { 2, 7, 11, 15 }, 9);
            Assert.AreEqual(result, new int[] { 0, 1 });
            result = TwoPointers.pairWithTargetSum(new int[] { 3, 2, 4 }, 6);
            Assert.AreEqual(result, new int[] { 1, 2 });
            result = TwoPointers.pairWithTargetSum(new int[] { 3, 3 }, 6);
            Assert.AreEqual(result, new int[] { 0, 1 });
        }

        [TestCase]
        public void removeDuplicates() {
            var result = TwoPointers.removeDuplicates(new int[] { 2, 3, 3, 3, 6, 9, 9 });
            Assert.AreEqual(result, new int[] { 2, 3, 6, 9, 3, 3, 9 });
        }

        [TestCase]
        public void SortedSquares() {
            var result = TwoPointers.SortedSquares(new int[] { -7, -3, 2, 3, 11 });
            Assert.AreEqual(result, new int[] { 4, 9, 9, 49, 121 });
            result = TwoPointers.SortedSquares(new int[] { -4, -1, 0, 3, 10 });
            Assert.AreEqual(result, new int[] { 0, 1, 9, 16, 100 });
            result = TwoPointers.SortedSquares(new int[] { -2, -1, 0, 2, 3 });
            Assert.AreEqual(result, new int[] { 0, 1, 4, 4, 9 });
            result = TwoPointers.SortedSquares(new int[] { -3, -1, 0, 1, 2 });
            Assert.AreEqual(result, new int[] { 0, 1, 1, 4, 9 });
        }
    }
}
