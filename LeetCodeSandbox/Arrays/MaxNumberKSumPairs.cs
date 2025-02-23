using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    public class MaxNumberKSumPairs
    {
        /*
        int[] num = {1, 0, 8 ,8 ,5}
        int k = 9

        count the number of pairs of numbers whose sum = 9 DO NOT re-use pairs. COnsider them removed after using them

        - cannot reuse pairs (i.e. consider pairs removed)
        - we CAN reuse numbers if there are duplicates of the smae number. JUst not that particular index
        
        edge cases:
        1) possible that NO pairs sum to 9
        2) can nums = []?
        3) negative numbers allowed?

        Approach:

        brute force:
        try all combinations of numbers.
        when we find a combination summing up to k, 
            - we increment the count 
            - and store the INDEX where we found the numbers in a HashSet<> removed so we dont reuse that index

        O(n2)

        O(n) calculate the desired pair as we traverse the array:

        [1 2 2 12 8 9, 9]

        k = 11
        1 => 10
        2 => 9
        12 => -1 (12 > 11 therefore there is no solution)
        8 => 3
        9 => 2

        as we traverse the solution and build maps, first check if the current number exists in our HashMap<> solutions
        if so, we have found a solution! add the solution and its counterpart to HashMap<> used (so we dnt reuse solutions) and
        increment the count

        [1 2 2 12 8 9, 9]

        {10: [0]
        9: []
        3: [4]
        }
        1) traverse the array from left to right
        2) as we find new numbers with no solution, calculate the solution for that nuber and store in Dictionary<int, List<int>> solutions (solutionValue => [index, index] where we saw the first number)
        3) if the new number is a solution, increment count and store the 






        problem: we cannot re-use indexes 
        problem: we can have duplicates in the nums array. We could have one solution for multiple indexes


        nums[]
        HashMap<int> solutions; pairs we are looking for to pair with numbers we've already seen
        int Count; // return the count of pairs we have found

[1 2 2 12 8 9, 9, 9, 2]

    { 9: []
        2: [7]

    }
        conditionals:

            - if nums[i] contains solution not yet seen, and nums[i] is not a solution then add solution to Dictionary with a value of [i]
            - if nums[i] contains solution not yet seen, AND this is our second time seeig vlaue nums[i], append i to the dictionar list
            - if nums[i] is a solution to a preiously seen nums[iprevious], remove an index from the List<> in dictionary, increment count, 
            - if nums[i] is a solution previously seen nums[iprevious, but List<int> is empty i.e. we have used up all of our numbers, 
            BUT now we can continue to look for the inverse of the solution
            - 

    */
        public int MaxOperations(int[] nums, int k)
        {

            int count = 0;
            Dictionary<int, List<int>> solutions = new Dictionary<int, List<int>>(); // map solution values to List of indexes which are waiting for that solution

            for (int i = 0; i < nums.Length; ++i)
            {

                if (solutions.ContainsKey(nums[i]) && solutions[nums[i]].Count() > 0) // if nums[i] is solution, and we still ned it, remove the pair and increment the count
                {
                    solutions[nums[i]].RemoveAt(solutions[nums[i]].Count() - 1); // we have found a solution that we were looking for! remove it from the list nad increment the count.
                    ++count;
                }
                else if (solutions.ContainsKey(nums[i]) && solutions[nums[i]].Count() == 0)
                {

                    if (solutions.ContainsKey(k - nums[i]))
                    {

                        solutions[k - nums[i]].Add(i);
                    }
                    else
                    {

                        solutions.Add(k - nums[i], new List<int>() { i }); // ** we actually still need to make sure we did not already add this particular k - nums[i] so we dont add a duplicate key.
                    }
                }
                else if (!solutions.ContainsKey(nums[i]) && !solutions.ContainsKey(k - nums[i])) // this is the first time we encountered nuums[i]
                {
                    solutions.Add(k - nums[i], new List<int>() { i });
                }
                else if (!solutions.ContainsKey(nums[i]) && solutions.ContainsKey(k - nums[i])) // we have seen nums[i] before
                {
                    solutions[k - nums[i]].Add(i);
                }
                else if (solutions.ContainsKey(k - nums[i]) && solutions[k - nums[i]].Count() > 0)//
                {
                    // found a nums[i] that we have seen before, append the index
                    solutions[k - nums[i]].Add(i);

                }
            }
            return count;
        }
    }
}
