using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSandbox
{
    public class IncreasingTriplet
    {
        /*
       constraints:

       0 < i < nums.Length
       i < j < k
       j < k < nums.Length

       naive soluion:

       start at i = 0, j = i + 1, k = j + 1 and then evaulate the condition nums[i] < nums[j] < nums[k].

       increment i in the outerloop, j in the second oop, k in the inner loop.

       O(n3) complexity.

       return once we have found a solution.

       O(n2) solution:
       - start with i = 0.
       - set j = i + 1;
       - iterate j until we find nums[j] > nums[i]
       - set k = j + 1
       - iterate k until we find nums[k] > nums[j]
       - if we failed, start over with i = i + 1. ALSO we now have a new condition, i < k because we know once i == k, this is a fail condition.


       no tis doesn't work either. if the numbers are sorted in reverse .... wait a second

       [5, 1, 3, 2, 6]

       in the above case we set i = 0 (5) and then we iterate and never find another j and ten we fail


       O(n) solution:
       we do the O(n2) solution, but this time, as we iterate i if we find a new i such that nums[new_i] < nums[old_i], we use the new_i instead.
       - start with i = 0;
       - check i + 1. if i + 1 < i, set i = i + 1.
       - if i + 1 > i, then set j = i + 1
       - if nums[i] < nums[j], set j = j + 1.
       - otherwise set k = j + 1.


       WAIT NO even better.

       O(n) solution:

       - start with k = nums.Length / 2 such that k is the middle element.
       - check k + 1. if k + 1 < k, 

       ... nvm this doesnt fuking work



       Okay I cheated and looked at the solution.
   */
        public bool IncreasingTripletSolve(int[] nums)
        {

            int first = int.MaxValue;
            int second = int.MaxValue;


            for (int i = 0; i < nums.Length; ++i)
            {
                if (nums[i] <= first)
                {
                    first = nums[i];
                }
                else if (nums[i] <= second)
                {
                    second = nums[i];

                }
                else if (nums[i] > first && nums[i] > second)
                {
                    return true;
                }
            }

            return false;


        }
    }
}
