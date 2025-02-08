// See https://aka.ms/new-console-template for more information
using LeetCodeSandbox;

Console.WriteLine("Hello, World!");


string beginWord = "hit";
List<string> wordList = new List<string>() { "hot", "dot", "dog", "lot", "log", "cog" };
int sequenceLength = WordLadder.LadderLength(beginWord, "cog", wordList); // answer should be 5

Console.WriteLine(sequenceLength);



Dictionary<int, int> positions = new Dictionary<int, int>();
positions.Add(1,2);


LinkedList<int> list = new LinkedList<int>();

var node0 = list.AddLast(0);
