namespace SortBenchmark.Tests;

public class BubbleSortTests
{
    [Fact]
    public void Run_NullArgument_ThrowException()
    {
        Assert.Throws<ArgumentNullException>(() => BubbleSort.Run(null as int[]));
    }
    
    [Fact]
    public void Run_ValidData_Success()
    {
        int[] numbers = [9, 4, 1, 8, 2, 6, 3, 7, 5];
        BubbleSort.Run(numbers);

        Assert.Equal([1, 2, 3, 4, 5, 6, 7, 8, 9], numbers);
    }
    
    [Fact]
    public void Run_ZeroItems_Success()
    {
        var numbers = Array.Empty<int>();
        BubbleSort.Run(numbers);

        Assert.Empty(numbers);
    }
    
    [Fact]
    public void Run_JustOneItem_Success()
    {
        int[] numbers = [42];
        BubbleSort.Run(numbers);
        
        Assert.Equal([42], numbers);
    }
    
    [Fact]
    public void Run_EvenLength_Success()
    {
        int[] numbers = [9, 4];
        BubbleSort.Run(numbers);
        
        Assert.Equal([4, 9], numbers);
    }
    
    [Fact]
    public void Run_RepeatingNumbers_Success()
    {
        int[] numbers = [9, 9, 4, 1, 4];
        BubbleSort.Run(numbers);
        
        Assert.Equal([1, 4, 4, 9, 9], numbers);
    }
    
    [Fact]
    public void Run_OddLength_Success()
    {
        int[] numbers = [3, 7, 5];
        BubbleSort.Run(numbers);
        
        Assert.Equal([3, 5, 7], numbers);
    }
    
    [Fact]
    public void Run_NegativeNumbers_Success()
    {
        int[] numbers = [-3, -7, -5];
        BubbleSort.Run(numbers);
        
        Assert.Equal([-7, -5, -3], numbers);
    }
}