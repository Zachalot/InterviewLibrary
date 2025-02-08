using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSandbox
{
    internal static class WordLadder
    {
        /*
            Edge cases
            1) Are we guaranteed that the wordList will contain a valid transformation sequence
            2) can wordList be empty
            3) can beginWord be an empty string, and can we have words in the transformation sequence of a different lenght?

            i.e. begnWord = "", wordList(1) = "a", wordList(2) = "ab"

            Thought process

            1) from the begin word, traverse the word list until we find end word
            2) compare the beginWord to the next word in the word list, use an index iterator to validate that the beginWord and next word differ by exactrly one character
            3) end condition
                - reach end of word listt without finding end word
                - reach a word which differs from last word by more than one character
                - 


            O(nm)
            n = length of word in the list
            m = length of the lsit itself i.e. number of words in list

            Okay this is way more complicated, the words dont have to be in order, we are just looking for a path from the begining word to the end word and it can
            traverse the words in ANY order to get to the destination word.

            1) build an adjacency "list"
            hit: hot,
            hot: hit, dot, lot
            dot: hot, dog
            dog: dot, log, cog
            lot: hot, log, 
            log: lot, dog, cog
            cog: log, dog

            visiting(hit)
            queue: hot, 

            visited: hit
            visiting(hot)
            queue: dot, lot

            visited: hit, hot
            visiting(dot)
            queue: lot, dog

            visited: hit, hot, dot
            visiting(lot)
            queue: dog, log

            visited: hit, hot, dot
            visiting(dog)
            queue: log, cog

            visited: hit, hot, dot, dog
            visiting(log) // TODO: visiting method needs to check visited list before actually visiting the target node. Visiting method is not guaranteed to recieve nodes which arent in the queue i.e. we coukld have duplicates IN the queue, we just cant have duplicates IN the visited array.
            queue: cog, lot, cog

            visted: hit, hot, dot, dog, log
            visiting(cog) <= here we add cog to the visited list, and return the length of the visited hasMap. return visited.Count()
            queue: lot, cog

        */

        static Dictionary<string, List<string>> adjMatrix = new Dictionary<string, List<string>>();
        static Queue<Tuple<string, int>> toVisit = new Queue<Tuple<string, int>>(); // cog, cog
        static HashSet<string> visited = new HashSet<string>(); // hit, hot, dot, lot, dog,  , cog

        public static int LadderLength(string beginWord, string endWord, IList<string> wordList) // { "hot", "dot", "dog", "lot", "log", "cog" };
        {

            if (beginWord == endWord || beginWord.Length != endWord.Length)
            {
                return 0;
            }

            // NOW we can get to work
            BuildAdjMatrix(beginWord, wordList);
            Tuple<string, int> currentWord = new Tuple<string, int>("", -1);
            toVisit.Enqueue(new Tuple<string, int>(beginWord, 1));
            while (toVisit.Count() > 0)
            {
                currentWord = toVisit.Dequeue();// cog
                visited.Add(currentWord.Item1); // TODO: does Hashmap have a TryAdd method? I hope so.

                if (currentWord.Item1 == endWord)
                {
                    return currentWord.Item2;
                }

                foreach (string word in adjMatrix[currentWord.Item1])
                {
                    if (!visited.Contains(word))
                    {
                        toVisit.Enqueue(new Tuple<string, int>(word, currentWord.Item2 + 1));
                    }
                }
            }


            return 0; // lose condition
        }

        public static void BuildAdjMatrix(string beginWord, IList<string> wordList)
        {
            adjMatrix.TryAdd(beginWord, new List<string>());
            for (int i = 0; i < wordList.Count(); ++i)
            {
                if (WordsAdjacent(beginWord, wordList[i]))
                {
                    CreateEdge(beginWord, wordList[i]);
                }
            }

            for (int i = 0; i < wordList.Count(); ++i)
            {
                adjMatrix.TryAdd(wordList[i], new List<string>());
                for (int j = i + 1; j < wordList.Count(); ++j)
                {
                    if (WordsAdjacent(wordList[i], wordList[j]))
                    {
                        CreateEdge(wordList[i], wordList[j]);
                    }
                }
            }
        }

        private static void CreateEdge(string word1, string word2)
        {
            if (!adjMatrix.TryAdd(word1, new List<string>() { word2 }))
            {
                adjMatrix[word1].Add(word2);
            }

            if (!adjMatrix.TryAdd(word2, new List<string>() { word1 }))
            {
                adjMatrix[word2].Add(word1);
            }
        }
        // true if words are adjacent otherwise false
        // words are adjacent if they are the same length and differ by only one letter
        public static bool WordsAdjacent(string word1, string word2)
        {
            if (word1.Length != word2.Length)
            {
                return false;
            }
            int diffCount = 0;
            for (int i = 0; i < word1.Length; ++i)
            {

                if (word1[i] != word2[i])
                {
                    ++diffCount;
                }
            }

            if (diffCount == 1)
            {
                return true;
            }
            return false;

        }
    }
}
