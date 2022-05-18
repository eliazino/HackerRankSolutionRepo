using HackerRankSolutionRepo.Problems;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static HackerRankSolutionRepo.Problems.BinaryTreeProblem;

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
            int[] a = new int[] { 1, 5, 6, 11, 12, 14, 15 };
            var r = Activities.insertAndSort(a, 14, 16);
            Assert.AreEqual(r, new int[] { 1, 5, 6, 11, 12, 15, 16 });
        }

        [TestCase]
        public void insertAndSortTestIV() {
            int[] a = new int[] { 1, 5, 6, 11, 12, 14, 15 };
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

        [TestCase]
        public void countSort() {
            int[] a = new int[] { 2, 3, 4, 2, 3, 6, 8, 4, 5 };
            int[] b = new int[] { 2, 3, 4, 5 };
            int i = Array.BinarySearch(b, 0, 4, 6);
            i = ~i;
            var r = Activities.countSort(a, 8, null, 0, 0);
            Assert.AreEqual(r.sortedA, new int[] {2, 2, 3, 3, 4, 4, 5, 6, 8});
        }

        [TestCase]
        public void TestNum2Roman() {
            var r = Activities.IntToRoman(21);
            Assert.AreEqual("XXI", r);
        }
        [TestCase]
        public void TestTreeDepth() {            
            TreeNode node = new TreeNode();
            node.value = 1;
            node.depth = 1;
            node = fillTree(node, 16);
            int d = BinaryTreeProblem.findMaxDepth(node);
            Assert.AreEqual(d, 4);
        }
        public static TreeNode fillTree(TreeNode tree, int maxValue) {
            int rightVal = (tree.value + tree.value);
            int leftVal = rightVal + 1;
            if (rightVal > maxValue)
                return tree;
            tree.right = new TreeNode { value = rightVal };
            tree.right = fillTree(tree.right, maxValue);
            if (leftVal <= maxValue) {
                tree.left = new TreeNode { value = leftVal };
                tree.left = fillTree(tree.left, maxValue);
            }
            return tree;
        }
        [TestCase]
        public void dayweekendTest() {
            var r = Activities.weekend("29-02");
            Assert.AreEqual(true, true);
        }

        [TestCase]
        public void movieTest() {
            var r = Activities.movieStack(3, 3, new int[3] { 3, 1, 1 });
            Assert.AreEqual("2,1,0", r);
        }
        [TestCase]
        public void Linq() {
            List<Employee> em = new List<Employee> {
                new Employee{ Company = "TA", Age = 3 },
                new Employee{ Company = "TJ", Age = 1 },
                new Employee{ Company = "TA", Age = 4 },
                new Employee{ Company = "TA", Age = 6 },
                new Employee{ Company = "TJ", Age = 9 },
                new Employee{ Company = "TA", Age = 1 },
                new Employee{ Company = "TA", Age = 2 },
                new Employee{ Company = "TK", Age = 4 },
                new Employee{ Company = "TB", Age = 9 },
                new Employee{ Company = "TK", Age = 7 },
            };
            var t = em.Select(emp => emp.Company).Distinct().ToList();
            var ti = em.Where(emp => emp.Company == "TK" && emp.Age == 7).ToList();
        }

        [TestCase]
        public void Ranker() {
            List<int> em = new List<int> {
                100, 100, 50, 40, 40, 20, 10
            };
            List<int> r = new List<int> {
                5, 25, 50, 120
            };
            var ri = Warmup1.getRanks2(em, r);
        }

        [TestCase]
        public void TestPivot() {
            int[] h = new int[] { 7, 3, 5, 2, 4, 1, 8, 6 };
            var j = SortingAlgorithms.Pivot(h,0, 7);
        }

        [TestCase]
        public void TestQS() {
            int[] h = new int[] { 1, 2, 3, 5, 6, 7, 8, 9 };
            var k = SortingAlgorithms.QuickSort(h, 0, 7);
        }
        [TestCase]
        public void TestQSII() {
            int[] h = new int[] { 2, 9, 5, 3, 7, 4, 7, 1 };
            var k = SortingAlgorithms.QuickSort(h, 0, 7);
            Assert.AreEqual(k, new int[] { 1, 2, 3, 4, 5, 7, 7, 9 });
        }
        public class Employee {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
            public string Company { get; set; }
        }
    }
}
