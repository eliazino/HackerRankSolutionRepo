using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRankSolutionRepo.Problems {
    public static class SlidingWindowProblems {
        public static double findAverageOfContigK(int[] arr, int k) {
            double result = 0;
            int sessionAdd = 0;
            for(int i=0; i < arr.Length; i++) {
                sessionAdd += arr[i];
                if (i >= k-1) {
                    int slidedInd = i + 1 - k;
                    if (slidedInd > 0) {
                        sessionAdd = sessionAdd - arr[slidedInd - 1];
                    }
                    result += (sessionAdd / k);
                }
            }
            return result;
        }

        public static double findMaxSumOfContigK(int[] arr, int k) {
            double result = 0;
            int sessionAdd = 0;
            for (int i = 0; i < arr.Length; i++) {
                sessionAdd += arr[i];
                if (i >= k - 1) {
                    int slidedInd = i + 1 - k;
                    if (slidedInd > 0) {
                        sessionAdd = sessionAdd - arr[slidedInd - 1];
                    }
                    if (sessionAdd > result)
                        result = sessionAdd;
                }
            }
            return result;
        }

        public static int findSumofContigEqK(int[] arr, int k) {
            int maxLength = arr.Length + 1;
            int sum = 0;
            int removed = 0;
            for(int i=0; i < arr.Length; i++) {
                sum = sum + arr[i];                
                if(sum >= k) {                    
                    int newSum = sum;
                    int newRemoved = removed;
                    if(i < 1) {
                        return 1;
                    }
                    while(newSum >= k) {                        
                        newSum -= arr[newRemoved];
                        newRemoved++;
                    }
                    removed = newRemoved-1;
                    sum = newSum + arr[removed];
                    int len = i + 1 - removed;
                    if (len == 1)
                        return 1;
                    if (maxLength > len)
                        maxLength = len;
                }
            }
            return maxLength;
        }

        public static int findMaxContigousNum(int[] arr, int k) {
            Dictionary<int, int> chars = new Dictionary<int, int>();
            int maxCount = 0;
            int startIndex = 0;
            int c = 0;
            for(int i = 0; i < arr.Length; i++) {
                if (chars.ContainsKey(arr[i])) {
                    chars[arr[i]] += 1;
                } else {
                    chars[arr[i]] = 1;
                }
                c++;
                if (chars.Count > k) {
                    if (maxCount < c -1)
                        maxCount = c -1;
                    int removalCount = 0;
                    for (int j = startIndex; j < i; j++) {
                        if (chars.Count == k)
                            break;
                        chars[arr[j]] -= 1;
                        if (chars[arr[j]] == 0)
                            chars.Remove(arr[j]);
                        removalCount++;
                    }
                    c = c - removalCount;
                    startIndex += removalCount;                    
                }
            }
            if (maxCount < c)
                return c;
            return maxCount;
        }

        public static int findMaxNonRepeating(string arr) {
            int windowTruncate = 0;
            int maxSubstr = 0;
            int dynCounter = 0;
            Dictionary<char, int> d = new Dictionary<char, int>();
            for(int i =0; i < arr.Length; i++) {
                char c = arr[i];
                if (d.ContainsKey(c)) {
                    dynCounter = i - windowTruncate;
                    if (dynCounter > maxSubstr)
                        maxSubstr = dynCounter;
                    windowTruncate = d[c] + 1;
                }
                d[c] = i;
            }
            if (dynCounter > maxSubstr)
                return dynCounter;
            return maxSubstr;
        }

        public static int findLongestCharacterReplacement(string chars, int k) {
            int startWin = 0;
            int maxSubstr = 0;
            Dictionary<char, int> charMap = new Dictionary<char, int>();
            int maxLen = 0;
            for(int endWin =0; endWin < chars.Length; endWin++) {
                char c = chars[endWin];
                if (!charMap.ContainsKey(c))
                    charMap[c] = 0;
                charMap[c] += 1;
                maxLen = charMap[c] < maxLen ? maxLen : charMap[c];
                if(endWin + 1 - startWin - maxLen > k) {
                    charMap[chars[startWin]]--;
                    startWin++;                    
                }
                if (maxSubstr < endWin - startWin + 1)
                    maxSubstr = endWin - startWin + 1;
            }
            return maxSubstr;
        }

        public static int lengthOfLongestSubArray(int[] nums, int k) {            
            int startWin = 0;
            int maxSubArray = 0;
            Dictionary<int, int> maps = new Dictionary<int, int>();
            maps[1] = 0;
            for(int winEnd = 0; winEnd < nums.Length; winEnd++) {
                int n = nums[winEnd];
                if (!maps.ContainsKey(n))
                    maps[n] = 0;
                maps[n]++;
                int rem = winEnd + 1 - startWin - maps[1];
                if(rem > k) {
                    maps[nums[startWin]]--;
                    startWin++;
                }
                int maxOnes = winEnd + 1 - startWin;
                if (maxSubArray < maxOnes)
                    maxSubArray = maxOnes;
            }
            return maxSubArray;
        }

        public static bool stringPatternIsASubstr(string str, string substr) {
            Dictionary<char, int> charFreq = new Dictionary<char, int>();
            for(int i =0; i < substr.Length; i++) {
                char c = substr[i];
                if (!charFreq.ContainsKey(c))
                    charFreq[c] = 0;
                charFreq[c]++;
            }
            int isMatch = 0;
            int winStart = 0;
            for(int j =0; j < str.Length; j++) {
                char c = str[j];                
                int windowSize = j + 1 - winStart;
                if(windowSize > substr.Length) {
                    if (charFreq.ContainsKey(str[winStart])){
                        if (charFreq[str[winStart]] == 0) {
                            isMatch--;
                        }
                        charFreq[str[winStart]]++;                        
                    }
                    winStart++;                    
                }
                if (charFreq.ContainsKey(c)) {                    
                    charFreq[c]--;
                    if (charFreq[c] == 0)
                        isMatch++;
                }                
                if (isMatch == charFreq.Count)
                    return true;
            }
            return false;
        }

        public static int[] findStringAnagrams(string str, string substr) {
            Dictionary<char, int> charFreq = new Dictionary<char, int>();
            for (int i = 0; i < substr.Length; i++) {
                char c = substr[i];
                if (!charFreq.ContainsKey(c))
                    charFreq[c] = 0;
                charFreq[c]++;
            }
            int isMatch = 0;
            int winStart = 0;
            for (int j = 0; j < str.Length; j++) {
                char c = str[j];
                int windowSize = j + 1 - winStart;
                if (windowSize > substr.Length) {
                    if (charFreq.ContainsKey(str[winStart])) {
                        if (charFreq[str[winStart]] == 0) {
                            isMatch--;
                        }
                        charFreq[str[winStart]]++;
                    }
                    winStart++;
                }
                if (charFreq.ContainsKey(c)) {
                    charFreq[c]--;
                    if (charFreq[c] == 0)
                        isMatch++;
                }
                if (isMatch == charFreq.Count) {
                    var r = new int[substr.Length];
                    int lc = 0;
                    for(int i= j - substr.Length + 1; i <= j; i++) {
                        r[lc] = i;
                        lc++;
                    }
                    return r;
                }
                    
            }
            return new int[] { 0, 0};
        }

        public static string minSubStr(string str, string pattern) {
            Dictionary<char, int> freqTbl = new Dictionary<char, int>();
            foreach(char c in pattern) {
                if (!freqTbl.ContainsKey(c))
                    freqTbl[c] = 0;
                freqTbl[c]++;
            }
            int charFound = 0;
            int startWIn = 0;
            string minWind = "";
            for (int i=0; i < str.Length;i++) {
                char c = str[i];
                if (freqTbl.ContainsKey(c)) {
                    freqTbl[c]--;
                    if (freqTbl[c] == 0)
                        charFound++;
                }
                if(charFound == freqTbl.Count) {                    
                    //Shrink till one char drops
                    for(int j = startWIn; j < i; j++) {
                        startWIn++;
                        if (freqTbl.ContainsKey(str[j])) {
                            freqTbl[str[j]]++;
                            if (freqTbl[str[j]] > 0) {
                                charFound--;
                                break;
                            }
                        }                        
                    }
                    int substrSt = startWIn > 0 ? startWIn - 1 : 0;
                    var _minWind = str.Substring(substrSt, i + 1 - substrSt);
                    if (minWind == "" || _minWind.Length < minWind.Length)
                        minWind = _minWind;
                }
            }
            return minWind;
        }
    }
}

