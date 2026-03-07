public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // PLAN FOR IMPLEMENTING MultiplesOf:
        // Step 1: Create a new array of doubles with size equal to 'length'
        // Step 2: Loop through the array from index 0 to length-1
        // Step 3: For each index i, calculate the multiple by multiplying 'number' by (i + 1)
        //         - At index 0: number * 1 = first multiple
        //         - At index 1: number * 2 = second multiple
        //         - At index 2: number * 3 = third multiple, and so on
        // Step 4: Store each calculated multiple in the corresponding array position
        // Step 5: After the loop completes, return the filled array

        // IMPLEMENTATION:
        // Step 1: Create array
        double[] multiples = new double[length];
        
        // Step 2-4: Loop and calculate multiples
        for (int i = 0; i < length; i++)
        {
            // Step 3: Calculate the multiple (i+1 because we want 1st, 2nd, 3rd multiples)
            multiples[i] = number * (i + 1);
        }
        
        // Step 5: Return the array
        return multiples;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // PLAN FOR IMPLEMENTING RotateListRight:
        // Rotating right means taking elements from the end and moving them to the beginning.
        // For example: {1, 2, 3, 4, 5, 6, 7, 8, 9} rotated right by 3 becomes {7, 8, 9, 1, 2, 3, 4, 5, 6}
        // The last 3 elements (7, 8, 9) move to the front.
        //
        // Step 1: Calculate the split point where we divide the list
        //         - Split point = data.Count - amount
        //         - Elements from split point to end will move to the front
        //         - Elements from start to split point will move to the back
        //
        // Step 2: Extract the last 'amount' elements that need to move to the front
        //         - Use GetRange(startIndex, count) to get a copy of these elements
        //         - startIndex = data.Count - amount
        //         - count = amount
        //
        // Step 3: Extract the first portion (remaining elements) that will move to the back
        //         - Use GetRange(0, data.Count - amount) to get these elements
        //
        // Step 4: Clear the original list to prepare for reassembly
        //         - Use Clear() method
        //
        // Step 5: Add the elements back in the rotated order
        //         - First, add the last portion (using AddRange)
        //         - Then, add the first portion (using AddRange)
        //
        // Result: The list is now rotated to the right by 'amount' positions

        // IMPLEMENTATION:
        // Step 1: Calculate split point
        int splitPoint = data.Count - amount;
        
        // Step 2: Get the last 'amount' elements (these go to the front)
        List<int> lastPortion = data.GetRange(splitPoint, amount);
        
        // Step 3: Get the first portion (these go to the back)
        List<int> firstPortion = data.GetRange(0, splitPoint);
        
        // Step 4: Clear the original list
        data.Clear();
        
        // Step 5: Add elements in rotated order
        data.AddRange(lastPortion);  // Add the last portion first
        data.AddRange(firstPortion); // Add the first portion last

    }
}
