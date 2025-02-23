using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSandbox
{
    public static class GCDStrings
    {
        /*

    find a repeating string x such that x divides both str1 and str2

    Well if x divides both str1 and str2, then this must mean that str1 and str2 are just the same repeating string.

    this seems pretty straight forward

    Edge Cases:
        - str1 is null or str2 is empty or null return ""
        - str1 or str2 coud have multiple different GCD right? are we looking for the shortest GCD?
        for example str1 = ABABABAB and str2 = ABAB
        answer: we go for the largest substring
        - str1 is the GCD of str2 or vice versa
            in the above example if str1 = ABABABAB and str2= ABAB then str2 is actually the GCD

        then we have both GCD = ABAB and GCD = AB both are common devisors .. does greatest ? OOOH yes we are looking for the greatest one.

        1) identify a repeating pattern of strings by remembering the number of times we see each character in the string?

    Strategy:
        Dictionary<char, int> str1Count
        Dictionary<char, int> str2Count

        but this wouldnt really work because just because we see the chaacters in the string the same number of times doesnt necessarily mean that its a repeating sequence
        i.e. ABABABwould look the same as AAABBB no repeatin sequence

        we could build sequences as we go? like as we traverse str1 we build out substrings in some other string to identify a repeating sequence

        str1 = ABABAB
        Dictionary<str,int> map the substring => number of times it appears in the string
        A 3
        AB 3
        ABA 1
        ABAB 1
        ABABA 1
        ABABAB 1


*/
        public static string GcdOfStrings(string str1, string str2)
        {

            if (String.IsNullOrEmpty(str1) || String.IsNullOrEmpty(str2))
            {
                return "";
            }

            if (DivideString(str1, str2))
            {

                return str2;
            }
            else if (DivideString(str2, str1))
            {

                return str1;
            }

            List<int> commonFact = CommonFactorization(str1, str2);
            if (commonFact.Count() == 0)
            {
                return "";
            }

            commonFact.Sort((int a, int b) => b.CompareTo(a)); // we want the greatest GCD so test the greatest one first.
            string GCD = "";
            foreach (int fact in commonFact) // O(n^3) buttt there can really only be so many factorizations so like its more like O(Nxn^2) where N is much smaller than n ... but its still O(n3) time
            {
                GCD = str1.Substring(0, fact);
                if (DivideString(str1, GCD) && DivideString(str2, GCD))
                {
                    return GCD;
                }

            }

            return "";

            // now search for the GCD in str1 starting from the greatest ... divisor of str1. FOr example if str1.Length() == 9, then if a GCD exists it must be length 3.
            // or if str1.Length = 10, then it is divisible by 5 and 2 so first we look for a string of length 5 then a string of length 2.
            // basically we know that if str1.Length() and str2.Length() do not share a common factorization, then we know that they do not share a GCD string either.


        }

        // returns the common factorization of these two string lengths if one exists
        public static List<int> CommonFactorization(string str1, string str2)
        {
            HashSet<int> str1Fact = new HashSet<int>();
            str1Fact.Add(1);
            str1Fact.Add(str1.Count());
            HashSet<int> str2Fact = new HashSet<int>();
            str2Fact.Add(1);
            str2Fact.Add(str2.Count());

            int i = str1.Count() - 1;
            while (i > 1)
            {

                if (str1.Count() % i == 0)
                {
                    str1Fact.Add(i);
                    str1Fact.Add(str1.Count() / i);
                }
                --i;
            }

            i = str2.Count();
            while (i > 1)
            {
                if (str2.Count() % i == 0)
                {
                    str2Fact.Add(i);
                    str2Fact.Add(str2.Count() / i);
                }
                --i;
            }

            str1Fact.IntersectWith(str2Fact);
            return str1Fact.ToList();
        }

        /// return true if sub divides str1
        public static bool DivideString(string str1, string sub)
        {

            // llop over str1 and confirm that the first sub.Length() characters of str1 match sub.
            // then increment our startIterator and repeat until we reach the end of str1

            if (str1.Count() % sub.Count() != 0)
            {
                return false;
            }

            for (int i = 0; i < str1.Count(); i = i + sub.Count())
            {
                for (int j = 0; j < sub.Count(); ++j)
                {
                    if (str1[i + j] != sub[j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
