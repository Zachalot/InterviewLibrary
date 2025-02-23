using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSandbox
{
    public class ProductExceptSelf
    {
        /*
         Given an integer array nums, return an array answer such that answer[i] is equal to the product of all the elements of nums except nums[i].

        The product of any prefix or suffix of nums is guaranteed to fit in a 32-bit integer.

        You must write an algorithm that runs in O(n) time and without using the division operation.

 

        Example 1:

        Input: nums = [1,2,3,4]
        Output: [24,12,8,6]
        Example 2:

        Input: nums = [-1,1,0,-3,3]
        Output: [0,0,9,0,0]
 

        Constraints:

        2 <= nums.length <= 105
        -30 <= nums[i] <= 30
        The input is generated such that answer[i] is guaranteed to fit in a 32-bit integer.
 

        Follow up: Can you solve the problem in O(1) extra space complexity? (The output array does not count as extra space for space complexity analysis.)
        */
        public int[] ProductExceptSelfSolve(int[] nums)
        {

            int[] beforeArr = new int[nums.Length];
            int[] afterArr = new int[nums.Length];
            int[] result = new int[nums.Length];

            beforeArr[0] = 1;
            afterArr[nums.Length - 1] = 1;

            for (int i = 1; i < nums.Length; ++i)
            {
                beforeArr[i] = beforeArr[i - 1] * nums[i - 1];
            }

            for (int j = nums.Length - 2; j > -1; --j)
            {
                afterArr[j] = afterArr[j + 1] * nums[j + 1];
            }

            for (int i = 0; i < beforeArr.Length; ++i)
            {
                result[i] = beforeArr[i] * afterArr[i];
            }

            return result;
        }
    }
}
