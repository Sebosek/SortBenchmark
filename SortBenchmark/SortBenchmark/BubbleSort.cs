namespace SortBenchmark;

public static class BubbleSort
{
    /// <summary>
    /// Bubble Sort <br />
    /// ----------- <br />
    /// Running from the beginning of a collection of items and compare
    /// a current value with next value and if the current value is
    /// lower to the next item switch them, once reaches the end, the highest
    /// value is at the end. <br />
    ///
    /// Eq: <br />
    ///   (1st cycle) <br />
    ///   9, 3, 6, 1  <br />
    ///   -->         <br />
    ///   3, 9, 6, 1  <br />
    ///      -->      <br />
    ///   3, 6, 9, 1  <br />
    ///         -->   <br />
    ///   3, 6, 1, 9 [highest element is placed] <br /><br />
    /// 
    /// The highest element is placed in its final position. <br />
    /// Repeat the switching from beginning but avoid already placed elements. <br />
    ///
    ///   (2nd cycle) <br />
    ///   3, 6, 1, 9  <br />
    ///      -->      <br />
    ///   3, 1, 6, 9 [second highest element is placed] <br /><br />
    ///
    ///   (3nd cycle) <br />
    ///   3, 1, 6, 9  <br />
    ///   -->         <br />
    ///   1, 3, 6, 9 [third highest element is placed] <br /><br />
    ///
    /// No more elements can be switched; the end.
    /// 
    /// </summary>
    public static void Run(int[] items)
    {
        ArgumentNullException.ThrowIfNull(items);
        
        if (items is { Length: <= 1 }) return;
        
        for (var x = items.Length; x > 0; x--)
        {
            for (var i = 0; i < x - 1; i++)
            {
                if (items[i + 1] > items[i]) continue;
            
                (items[i], items[i + 1]) = (items[i + 1], items[i]);
            }
        }
    }
}