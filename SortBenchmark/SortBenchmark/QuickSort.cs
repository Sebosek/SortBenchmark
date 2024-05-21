namespace SortBenchmark;

public static class QuickSort
{
    /// <summary>
    /// Quick Sort <br />
    /// ---------- <br />
    ///
    /// Begins with defining a pivot. This implementation uses as pivot the first element
    /// from unsorted collection. Pivot is switched to the end of unsorted collection.<br />
    /// Running from the pivot to the end and looking for biggest element. Every smaller element than
    /// pivot are switched with pivot. The position of last pivot index is used to final switch with
    /// element in the last position. <br />
    /// Repeat until there are element in unsorted collection. <br /><br />
    /// 
    /// Eq: <br />
    ///   9, 3, 6, 1 (Swap pivot with last item) <br />
    ///   1, 3, 6, 9 (1 is smaller than 9, switch i with j - both point to 1) <br />
    ///   1, 3, 6, 9 (3 is smaller than 9, switch i with j - both point to 3) <br />
    ///   1, 3, 6, 9 (6 is smaller than 9, switch i with j - both point to 6) <br /><br />
    ///
    ///   Pivot is at index 2, value 6. <br />
    /// 
    ///   1, 3 (is collection on left, recursive call, but already sorted)  <br />
    ///   6    (pivot value)                                                <br />
    ///   9    (is collection or right, recursive call, but already sorted) <br /><br />
    ///
    /// No more collections to sort; the end.
    /// 
    /// </summary>
    public static void Run(int[] items)
    {
        Sort(items, 0, items.Length - 1);
    }

    private static void Sort(int[] items, int left, int right)
    {
        if (right < left) return;

        Swap(items, left, right);
        var pivot = PivotIndex(items, left, right);
        Swap(items, pivot, right);
    
        Sort(items, left, pivot - 1);
        Sort(items, pivot + 1, right);
    }

    private static int PivotIndex(int[] items, int left, int right)
    {
        var i = left;
        for (var j = left; j < right; j++)
        {
            if (items[j] >= items[right]) continue;

            Swap(items, i, j);
            i++;
        }

        return i;
    }

    private static void Swap(int[] items, int left, int right)
    {
        (items[left], items[right]) = (items[right], items[left]);
    }
}