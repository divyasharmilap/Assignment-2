using System;
using System.Collections.Generic;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Question 1: Find Missing Numbers in Array
            Console.WriteLine("Question 1:");
            int[] nums1 = { 4, 3, 2, 7, 8, 2, 3, 1 };
            IList<int> missingNumbers = FindMissingNumbers(nums1);
            Console.WriteLine(string.Join(",", missingNumbers));

            // Question 2: Sort Array by Parity
            Console.WriteLine("Question 2:");
            int[] nums2 = { 3, 1, 2, 4 };
            int[] sortedArray = SortArrayByParity(nums2);
            Console.WriteLine(string.Join(",", sortedArray));

            // Question 3: Two Sum
            Console.WriteLine("Question 3:");
            int[] nums3 = { 2, 7, 11, 15 };
            int target = 9;
            int[] indices = TwoSum(nums3, target);
            Console.WriteLine(string.Join(",", indices));

            // Question 4: Find Maximum Product of Three Numbers
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 2, 3, 4 };
            int maxProduct = MaximumProduct(nums4);
            Console.WriteLine(maxProduct);

            // Question 5: Decimal to Binary Conversion
            Console.WriteLine("Question 5:");
            int decimalNumber = 42;
            string binary = DecimalToBinary(decimalNumber);
            Console.WriteLine(binary);

            // Question 6: Find Minimum in Rotated Sorted Array
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3, 4, 5, 1, 2 };
            int minElement = FindMin(nums5);
            Console.WriteLine(minElement);

            // Question 7: Palindrome Number
            Console.WriteLine("Question 7:");
            int palindromeNumber = 121;
            bool isPalindrome = IsPalindrome(palindromeNumber);
            Console.WriteLine(isPalindrome);

            // Question 8: Fibonacci Number
            Console.WriteLine("Question 8:");
            int n = 4;
            int fibonacciNumber = Fibonacci(n);
            Console.WriteLine(fibonacciNumber);
        }

        // Question 1: Find Missing Numbers in Array
        public static IList<int> FindMissingNumbers(int[] nums)
        {
            try
            {
                // Write your code here
                // Edge case: Empty array -> return empty list
                HashSet<int> set = new HashSet<int>(nums); // HashSet to store unique numbers
                List<int> missing_num = new List<int>(); // List to store missing numbers
                for (int i = 1; i <= nums.Length; i++)
                {
                    if (!set.Contains(i))
                    {
                        missing_num.Add(i); // Add missing number to the list
                    }
                }
                return missing_num; // Placeholder
            }
            catch (Exception)
            {
                throw;
            }
        }



        // Question 2: Sort Array by Parity
        public static int[] SortArrayByParity(int[] nums)
        {
            try
            {
                // Write your code here
                // Edge case: All even or all odd -> return original
                int left = 0, right = nums.Length - 1;
                while (left < right)
                {
                    if (nums[left] % 2 > nums[right] % 2) // if left is odd and right is even
                    {
                        (nums[left], nums[right]) = (nums[right], nums[left]); 
                    }

                    if (nums[left] % 2 == 0) left++; // move left pointer if even
                    if (nums[right] % 2 == 1) right--; // move right pointer if odd
                }
                return nums; // Placeholder
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 3: Two Sum
        public static int[] TwoSum(int[] nums, int target)
        {
            try
            {
                // Write your code here
                Dictionary<int, int> map = new Dictionary<int, int>(); // Dictionary to store numbers and their indices
                for (int i = 0; i < nums.Length; i++)
                {
                    int complement = target - nums[i];
                    if (map.ContainsKey(complement)) // check if complement exists
                    {
                        return new int[] { map[complement], i };
                    }
                    if (!map.ContainsKey(nums[i])) // avoids duplicate keys
                    {
                        map[nums[i]] = i;
                    }
                }
                return new int[] { }; // Placeholder
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 4: Find Maximum Product of Three Numbers
        public static int MaximumProduct(int[] nums)
        {
            try
            {
                // Write your code here
                Array.Sort(nums); // Sort the array
                int n = nums.Length; 
                // Consider two smallest * largest (for negative values)
                return Math.Max(nums[n - 1] * nums[n - 2] * nums[n - 3], nums[0] * nums[1] * nums[n - 1]);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 5: Decimal to Binary Conversion
        public static string DecimalToBinary(int decimalNumber)
        {
            try
            {
                // Write your code here
                if (decimalNumber == 0) return "0"; // Edge case: 0 -> return "0"
                string result = "";
                while (decimalNumber > 0) // Convert to binary
                {
                    result = (decimalNumber % 2) + result; 
                    decimalNumber /= 2;
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 6: Find Minimum in Rotated Sorted Array
        public static int FindMin(int[] nums)
        {
            try
            {
                // Write your code here
                int left = 0, right = nums.Length - 1; // Initialize left and right pointers
                while (left < right) // Binary search
                {
                    int middle = (left + right) / 2;
                    if (nums[middle] > nums[right])  // middle is in the left part
                    {
                        left = middle + 1;
                    }
                    else
                    {
                        right = middle;
                    }
                }
                return nums[left];
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 7: Palindrome Number
        public static bool IsPalindrome(int x)
        {
            try
            {
                // Write your code here
                if (x < 0) return false; // negative numbers are not palindromes
                int word = x, reversed = 0;
                while (x > 0) // Reverse the number
                {
                    int digit = x % 10;
                    if (reversed > (int.MaxValue - digit) / 10) return false; // overflow protection
                    reversed = reversed * 10 + digit; // build the reversed number
                    x /= 10;
                }
                return word == reversed;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 8: Fibonacci Number
        public static int Fibonacci(int n)
        {
            try
            {
                // Write your code here
                if (n == 0) return 0;
                if (n == 1) return 1;
                int a = 0, b = 1; // Initialize base cases
                for (int i = 2; i <= n; i++) // start from 2 since 0 and 1 are base cases
                {
                    int temperature = a + b;
                    a = b;
                    b = temperature;
                }
                return b; // return the nth Fibonacci number
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
