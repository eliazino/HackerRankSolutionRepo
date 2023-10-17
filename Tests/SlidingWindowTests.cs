using HackerRankSolutionRepo.Problems;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests {
    [TestFixture]
    public class SlidingWindowTests {
        public void Setup() {

        }

        [TestCase]
        public void Test1() {
            var result = SlidingWindowProblems.findAverageOfContigK(new int[] { 1, 3, 2, 6, -1, 4, 1, 8, 2 }, 5);
        }

        [TestCase]
        public void Test2() {
            var result = SlidingWindowProblems.findMaxSumOfContigK(new int[] { 1, 3, 2, 6, -1, 4, 1, 8, 2 }, 5);
            Assert.AreEqual(result, 18);
            result = SlidingWindowProblems.findMaxSumOfContigK(new int[] { 2, 1, 5, 1, 3, 2 }, 3);
            Assert.AreEqual(result, 9);
            result = SlidingWindowProblems.findMaxSumOfContigK(new int[] { 2, 3, 4, 1, 5 }, 2);
            Assert.AreEqual(result, 7);
        }

        [TestCase]
        public void Test3() {
            var result = SlidingWindowProblems.findSumofContigEqK(new int[] { 1, 2, 3, 4, 5 }, 4);
            Assert.AreEqual(result, 1);
            result = SlidingWindowProblems.findSumofContigEqK(new int[] { 2, 1, 5, 2, 3, 2 }, 7);
            Assert.AreEqual(result, 2);
            result = SlidingWindowProblems.findSumofContigEqK(new int[] { 2, 1, 5, 2, 8 }, 7);
            Assert.AreEqual(result, 1);
            result = SlidingWindowProblems.findSumofContigEqK(new int[] { 3, 4, 1, 1, 6 }, 8);
            Assert.AreEqual(result, 3);
        }

        [TestCase]
        public void Test4() {
            var result = SlidingWindowProblems.findMaxContigousNum(new int[] { 1, 2, 1, 1, 3, 4 }, 2);
            Assert.AreEqual(result, 4);
            result = SlidingWindowProblems.findMaxContigousNum(new int[] { 1, 2, 1, 1, 3, 4 }, 1);
            Assert.AreEqual(result, 2);
            result = SlidingWindowProblems.findMaxContigousNum(new int[] { 1, 2, 2, 3, 2, 4 }, 3);
            Assert.AreEqual(result, 5);
            result = SlidingWindowProblems.findMaxContigousNum(new int[] { 1, 1, 2, 3, 3, 1, 4, 2, 1 }, 2);
            Assert.AreEqual(result, 3);
            result = SlidingWindowProblems.findMaxContigousNum(new int[] { 1, 2, 1 }, 2);
            Assert.AreEqual(result, 3);
            result = SlidingWindowProblems.findMaxContigousNum(new int[] { 0, 1, 2, 2 }, 2);
            Assert.AreEqual(result, 3);
            result = SlidingWindowProblems.findMaxContigousNum(new int[] { 1, 2, 3, 2, 2 }, 2);
            Assert.AreEqual(result, 4);
        }

        [TestCase]
        public void Test5() {
            var result = SlidingWindowProblems.findMaxNonRepeating("aabccbb");
            Assert.AreEqual(result, 3);
            result = SlidingWindowProblems.findMaxNonRepeating("abbbb");
            Assert.AreEqual(result, 2);
            result = SlidingWindowProblems.findMaxNonRepeating("abccde");
            Assert.AreEqual(result, 3);
        }

        [TestCase]
        public void Test6() {
            var result = SlidingWindowProblems.findLongestCharacterReplacement("aabccbb", 2);
            Assert.AreEqual(result, 5);
            result = SlidingWindowProblems.findLongestCharacterReplacement("abbcb", 1);
            Assert.AreEqual(result, 4);
            result = SlidingWindowProblems.findLongestCharacterReplacement("abccde", 1);
            Assert.AreEqual(result, 3);
        }

        [TestCase]
        public void Test7() {
            var result = SlidingWindowProblems.lengthOfLongestSubArray(new int[] { 0, 1, 1, 0, 0, 0, 1, 1, 0, 1, 1 }, 2);
            Assert.AreEqual(result, 6);
            result = SlidingWindowProblems.lengthOfLongestSubArray(new int[] { 0, 1, 0, 0, 1, 1, 0, 1, 1, 0, 0, 1, 1 }, 3);
            Assert.AreEqual(result, 9);
            result = SlidingWindowProblems.lengthOfLongestSubArray(new int[] { 1, 1, 0, 1, 0, 1, 0, 1 }, 1);
            Assert.AreEqual(result, 4);
        }

        [TestCase]
        public void Test8() {
            var result = SlidingWindowProblems.stringPatternIsASubstr("eliasino", "asi");
            Assert.AreEqual(result, true);
            result = SlidingWindowProblems.stringPatternIsASubstr("oidbcaf", "abc");
            Assert.AreEqual(result, true);
            result = SlidingWindowProblems.stringPatternIsASubstr("odicf", "dc");
            Assert.AreEqual(result, false);
            result = SlidingWindowProblems.stringPatternIsASubstr("bcdxabcdy", "bcdxabcdy");
            Assert.AreEqual(result, true);
            result = SlidingWindowProblems.stringPatternIsASubstr("aaacb", "abc");
            Assert.AreEqual(result, true);
            result = SlidingWindowProblems.stringPatternIsASubstr("aaagcb", "abc");
            Assert.AreEqual(result, false);
        }

        [TestCase]
        public void Test9() {
            var result = SlidingWindowProblems.findStringAnagrams("eliasino", "asi");
            Assert.AreEqual(result, new int[] { 2, 3, 4 });
            result = SlidingWindowProblems.findStringAnagrams("oidbcaf", "abc");
            Assert.AreEqual(result, new int[] { 3, 4, 5 });
            result = SlidingWindowProblems.findStringAnagrams("odicf", "dc");
            Assert.AreEqual(result, new int[] {0, 0});
            result = SlidingWindowProblems.findStringAnagrams("bcdxabcdy", "bcdxabcdy");
            Assert.AreEqual(result, new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 });
            result = SlidingWindowProblems.findStringAnagrams("aaacb", "abc");
            Assert.AreEqual(result, new int[] {2, 3, 4});
            result = SlidingWindowProblems.findStringAnagrams("aaagcb", "abc");
            Assert.AreEqual(result, new int[] { 0, 0 });
            result = SlidingWindowProblems.findStringAnagrams("ppqp", "pq");
            Assert.AreEqual(result, new int[] { 1, 2 });
            result = SlidingWindowProblems.findStringAnagrams("abbcabc", "abc");
            Assert.AreEqual(result, new int[] { 2, 3, 4});
        }

        [TestCase]
        public void Test10() {
            var result = SlidingWindowProblems.minSubStr("ADOBECODEBANC", "ABC");
            Assert.AreEqual(result, "BANC");
            result = SlidingWindowProblems.minSubStr("a", "a");
            Assert.AreEqual(result, "a");
            result = SlidingWindowProblems.minSubStr("a", "aa");
            Assert.AreEqual(result, "");
            result = SlidingWindowProblems.minSubStr("aabdec", "abc");
            Assert.AreEqual(result, "abdec");
            result = SlidingWindowProblems.minSubStr("abdbca", "abc");
            Assert.AreEqual(result, "bca");
            result = SlidingWindowProblems.minSubStr("adcad", "abc");
            Assert.AreEqual(result, "");
            result = SlidingWindowProblems.minSubStr("ppqp", "pq");
            Assert.AreEqual(result, "pq");
            result = SlidingWindowProblems.minSubStr("eliasino", "oia");
            Assert.AreEqual(result, "asino");
        }
    }
}
