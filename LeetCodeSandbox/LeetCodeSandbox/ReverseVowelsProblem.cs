using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSandbox
{
    public class ReverseVowelsProblem
    {
        /*
reverse the vowels basicaly means swap the first vowel from the right with the first vowel from the left. 2nd from the right 2nd from the left etc.

edge cases:
- empty string, return the string
- string with no vowels, return the string
- string with one letter which is a vowel, return the string

method:
- crawl from the begining to find the first vowel.
- then crawl fro the end to find the first vowel from the right.
- then swap the two.
- continue the above steps until the iterators run into eachother.
*/
        public string ReverseVowels(string s)
        {

            char[] result = s.ToCharArray();
            HashSet<char> vowels = new HashSet<char>() { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };

            int start = 0;
            int end = s.Length - 1;

            while (start < end)
            {
                // neither start nor end contain vowels
                if (!vowels.Contains(s[start]) && !vowels.Contains(s[end]))
                {
                    ++start;
                    --end;

                }
                else if (vowels.Contains(s[start]) && !vowels.Contains(s[end])) // start is a vowel but end is not
                {
                    --end;
                }
                else if (!vowels.Contains(s[start]) && vowels.Contains(s[end])) // start is not a vowel but end is
                {
                    ++start;
                }
                else
                { // both start and end are vowels

                    char t = result[start];
                    result[start] = result[end];
                    result[end] = t;

                    ++start;
                    --end;
                }
            }

            return new string(result);
        }
    }
}
