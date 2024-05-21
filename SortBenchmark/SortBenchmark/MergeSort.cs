namespace SortBenchmark;

public static class MergeSort
{
    /// <summary>
    /// Merge Sort <br />
    /// ---------- <br />
    /// Recursively splits a collection of items until reach a collection made
    /// by a single element or less. Once the recursion ends, start merging items
    /// together again. <br />
    /// Remember a position in merge collection, left collection and right collection.
    /// Goes through left and right collection and always takes smaller value and put it
    /// inside the final merged collection. Once reached to the end of left OR right collection
    /// put the rest items from left and right collections at the end of final merged collection.
    ///
    /// Eq: <br />
    ///   (split)        <br />
    ///   9,  3,  6,  1  <br />
    ///   9,  3 | 6,  1  <br />
    ///   9 | 3 | 6,  1  <br />
    ///   3 | 9 | 6 | 1  [split to 4 collections] <br /><br />
    /// 
    /// The collection is split into 4 standalone collections. <br />
    /// Start merging them together. <br />
    ///
    ///   (1st merge of last split "6" & "1") <br />
    ///   3 | 9 | 6 | 1 <br /> 
    ///   3 | 9 | 1,    <br />
    ///   3 | 9 | 1,  6 <br />
    ///
    ///   (2nd merge of split "3" & "9") <br />
    ///   3 | 9 | 1,  6 <br />
    ///   3     | 1,  6 <br />
    ///   3,  9 | 1,  6 <br />
    ///
    ///  (3rd merge of split "3, 9" & "1, 6") <br />
    ///   3,  9 | 1,  6 [k: 0, i: 0, j: 0] <br /> 
    ///   1             [k: 1, i: 0, j: 1] <br /> 
    ///   1,  3         [k: 2, i: 1, j: 1] <br /> 
    ///   1,  3   6,    [k: 3, i: 1, j: 2 - we've reached j == right.Length, add rest of items from left and right collections] <br /> 
    ///   1,  3,  6,  9 <br /> 
    ///
    /// No more collections can be merged; the end.
    /// </summary>
    public static void Run(int[] items)
    {
        ArgumentNullException.ThrowIfNull(items);

        Sort(items);
    }
    
    private static void Sort(int[] items)
    {
        if (items.Length <= 1)
        {
            return;
        }

        var index = items.Length / 2;
        var remaining = items.Length - index;
        var left = new int[index];
        var right = new int[remaining];

        Array.Copy(items, 0, left, 0, index);
        Array.Copy(items, index, right, 0, remaining);

        Sort(left);
        Sort(right);

        Merge(items, left, right);
    }
    
    private static void Merge(int[] items, int[] left, int[] right)
    {
        var i = 0;
        var j = 0;
        var k = 0;

        while (i < left.Length && j < right.Length)
        {
            if (left[i] <= right[j])
            {
                items[k] = left[i];
                i++;
                k++;
            }
            else
            {
                items[k] = right[j];
                j++;
                k++;
            }
        }

        while (i < left.Length)
        {
            items[k] = left[i];
            i++;
            k++;
        }

        while (j < right.Length)
        {
            items[k] = right[j];
            j++;
            k++;
        }
    }
}
