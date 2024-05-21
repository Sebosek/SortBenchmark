namespace SortBenchmark;

public static class PancakeSort
{
    /// <summary>
    /// Pancake Sort <br />
    /// ------------ <br />
    /// Works exactly as you would expect, it's about flipping the pancakes. <br />
    /// Let's have a stack of pancakes: <br /><br />
    /// 
    ///   -=======-  <br />
    ///  -=========- <br />
    ///      -=-     <br />
    ///    -=====-   <br /><br />
    ///
    /// You can only flip a stack of pancakes and your goal is to put the larges one at
    /// the bottom of deck. Because you have just one spatula, you have to flip the largest
    /// at to top, but that also means that all pancakes above are flipped too. Once the largest
    /// is on the top, you can flip whole deck to put the largest at the bottom. <br />
    /// Continue with the second largest package, flip it on the top, then flip it to the bottom except
    /// the most largest pancake, the largest is already placed correctly, so bottom - 1. <br />
    /// Repeat until the deck is sorted. <br />
    ///
    /// (1st flip)     <br />
    ///   -=======-  ^ <br />
    ///  -=========- | <br />
    ///      -=-       <br />
    ///    -=====-     <br /><br />
    ///
    /// (1st flip to the bottom) <br />
    ///  -=========- | <br />
    ///   -=======-  | <br />
    ///      -=-     | <br />
    ///    -=====-   v <br /><br />
    ///
    /// (2nd flip)     <br />
    ///    -=====-   ^ <br />
    ///      -=-     | <br />
    ///   -=======-  | <br />
    ///  -=========-   <br /><br />
    ///
    /// (2nd flip to the bottom) <br />
    ///   -=======-  | <br />
    ///      -=-     | <br />
    ///    -=====-   v <br />
    ///  -=========-   <br /><br />
    ///
    /// (3rd flip - the largest available is on the top) <br />
    ///    -=====-   ^ <br />
    ///      -=-       <br />
    ///   -=======-    <br />
    ///  -=========-   <br /><br />
    /// 
    /// (3rd flip to the bottom) <br />
    ///    -=====-   | <br />
    ///      -=-     v <br />
    ///   -=======-    <br />
    ///  -=========-   <br /><br />
    ///
    /// (Completed pile) <br />
    ///      -=-       <br />
    ///    -=====-     <br />
    ///   -=======-    <br />
    ///  -=========-   <br /><br />
    ///
    /// The deck is sorted; the end.
    /// 
    /// </summary>
    public static void Run(int[] items)
    {
        ArgumentNullException.ThrowIfNull(items);
        if (items is { Length: <= 1}) return;
        
        var end = items.Length;
        while (!IsOrdered(items))
        {
            var i = IndexOfMax(items, end);
            Reverse(items, 0, i + 1);
            Reverse(items, 0, end);

            end -= 1;
        }
    }

    private static int IndexOfMax(int[] items, int count)
    {
        var max = int.MinValue;
        var index = 0;

        for (var i = 0; i < count; i++)
        {
            if (items[i] <= max) continue;
            
            max = items[i];
            index = i;
        }

        return index;
    }

    private static bool IsOrdered(int[] items)
    {
        for (var i = 0; i < items.Length - 1; i++)
        {
            if (items[i] > items[i + 1]) return false;
        }

        return true;
    }

    private static void Reverse(int[] items, int start, int count)
    {
        var end = Math.Min(count, items.Length);
        for (var i = start; i < end / 2; i++)
        {
            (items[i], items[end - 1 - i]) = (items[end - 1 - i], items[i]);
        }
    }
}