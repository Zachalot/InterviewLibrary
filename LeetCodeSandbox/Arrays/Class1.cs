namespace Arrays
{
    /*
     Given an integer array nums, move all 0's to the end of it while maintaining the relative order of the non-zero elements.

Note that you must do this in-place without making a copy of the array.

 
     */
    public class MoveZeros
    {
        /*
            [1, 0, 0, 2 12]

            int ptrLastNonZ = 0
            int ptrCurrent = 0

            if nums[ptrCurrent] != 0 AND ptrCurrent != ptrLastNonZ
                // we want assign nums[ptrLastNonZ + 1] = nums[ptrCurrent] and increment ptrLastNonZ and incremet ptrCurrent
                nums[ptrLastNonZ + 1] = nums[ptrCurrent]
                nums[ptrCurrent] = 0
                ++ptrLastNonZ
                ++ptrCurrent
            else if (nums[ptrCurrent] == 0 AND ptrCurrent != ptrLastNonZ)
                // do nothing. only need to increment ptrCurrent if it is a zero
                ++ptrCurrent
                
                
         */
        public void MoveZerosSolve(int[] nums)
        {
            int ptrCurrent = 0;
            int ptrLastNonZ = -1;

            while (ptrCurrent < nums.Length)
            {
                if (nums[ptrCurrent] != 0 && ptrCurrent != ptrLastNonZ)
                {
                    nums[ptrLastNonZ + 1] = nums[ptrCurrent];
                    nums[ptrCurrent] = 0;
                    ++ptrLastNonZ;
                    ++ptrCurrent;
                }
                else if (nums[ptrCurrent] == 0)
                {
                    ++ptrCurrent;
                }
            }
        }
    }
}
