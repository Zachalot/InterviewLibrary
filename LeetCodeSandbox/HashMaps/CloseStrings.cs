namespace HashMaps
{
    public class CloseStrings
    {
    /*
        Two strings are considered close if you can attain one from the other using the following operations:

        Operation 1: Swap any two existing characters.
        For example, abcde -> aecdb
        Operation 2: Transform every occurrence of one existing character into another existing character, and do the same with the other character.
        For example, aacabb -> bbcbaa (all a's turn into b's, and all b's turn into a's)
        You can use the operations on either string as many times as necessary.

        Given two strings, word1 and word2, return true if word1 and word2 are close, and false otherwise.

 

        Example 1:

        Input: word1 = "abc", word2 = "bca"
        Output: true
        Explanation: You can attain word2 from word1 in 2 operations.
        Apply Operation 1: "abc" -> "acb"
        Apply Operation 1: "acb" -> "bca"
        Example 2:

        Input: word1 = "a", word2 = "aa"
        Output: false
        Explanation: It is impossible to attain word2 from word1, or vice versa, in any number of operations.
        Example 3:

        Input: word1 = "cabbba", word2 = "abbccc"
        Output: true
        Explanation: You can attain word2 from word1 in 3 operations.
        Apply Operation 1: "cabbba" -> "caabbb"
        Apply Operation 2: "caabbb" -> "baaccc"
        Apply Operation 2: "baaccc" -> "abbccc"
         
    */
        /*
        two conditions
        1: word1 => word 2 if we can swap a character within word1 with another character within word1
        2: word1 => word2 if we swap ALL of a certain type of character to another type of characeter and vice versa within word1

        base conditions:
        - if not same length return false


        condition 1
        word1 = a b c d b
        word2 = a d c b d

        int diff1 = -1000
        int diff2 = -1000

        TIme: O(n)
        1) dictionary<char, int>() {a:1, b:2, c:3 ..... z:26}
        2) iterate over word1 and word2 and compute the difference between each character
        3) when we come accross a difference, store the value of the difference in diffhit
        4) as we come accross new differences, we just keep adding them to the dicitonary.
        5) if we get to the end, and diffHit.COunt() == 1, no solution
        6) if diffHit.COunt() == 2, and diffHit.Keys .... whatever if the two keys are NOT inverse of eachother, return false
        7) if diff1 == -1*diff2, return true


        condition 2
        word1 =  aaba
        word2 = bbab
        TIme O(n)

        Dictionary<int,int> diffHit

        {
            -1: 3
            1: 1

        }

        word1 = a b c d b
        word2 = a d c b d



        word1Dict 
        {

            a: 2
            b: 2
            c: 1
            z: 2
        }

        word2Dict
        {
            a: 1
            b: 2
            z: 3
            c: 1

        }


        bucketDIct1
        {
            2: 3
            1: 1

        }

        bucketDIct2
        {
            1: 2
            2: 1
            3: 1

        }

    */
        public bool CloseStringsExecute(string word1, string word2)
        {

            Dictionary<char, int> charTracker1 = new Dictionary<char, int>();
            Dictionary<char, int> charTracker2 = new Dictionary<char, int>();

            if (word1.Length != word2.Length)
            {
                return false;
            }

            // index all of the characters in word1
            foreach (char elt in word1)
            {
                if (!charTracker1.TryAdd(elt, 1))
                {

                    charTracker1[elt] += 1;
                }
            }

            // index all of the characters in word2
            foreach (char elt in word2)
            {
                if (!charTracker2.TryAdd(elt, 1))
                {
                    charTracker2[elt] += 1;
                }
            }

            // take the set exclusion of word1 and word2. it should => an empty hashSet
            foreach (var key in charTracker1.Keys)
            {
                if (!charTracker2.ContainsKey(key))
                {
                    return false;
                }
            }

            // only way ofr 2 to have keys 1 does not have is if it has MORE total keys
            if (charTracker2.Count() > charTracker1.Count())
            {
                return false;
            }

            // check for buckets. BOth dictionarys must have the same value buckets.
            Dictionary<int, int> bucketCount1 = new Dictionary<int, int>();
            Dictionary<int, int> bucketCount2 = new Dictionary<int, int>();

            foreach (char elt in charTracker1.Keys)
            {
                if (!bucketCount1.TryAdd(charTracker1[elt], 1))
                {
                    bucketCount1[charTracker1[elt]] += 1;
                }
            }

            foreach (char elt in charTracker2.Keys)
            {
                if (!bucketCount2.TryAdd(charTracker2[elt], 1))
                {
                    bucketCount2[charTracker2[elt]] += 1;
                }
            }

            if (bucketCount1.Keys.ToList().Count() != bucketCount2.Keys.ToList().Count())
            {
                return false;
            }

            foreach (var bucket in bucketCount1.Keys)
            {
                if (!bucketCount2.ContainsKey(bucket) || bucketCount1[bucket] != bucketCount2[bucket])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
