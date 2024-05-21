using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;

using SortBenchmark;

// BenchmarkRunner.Run<Benchmark>(new DebugInProcessConfig());
BenchmarkRunner.Run<Benchmark>();

public class Benchmark
{
    private readonly Random _random = new(42);
    
    private int[] _data;
    
    [Params(10, 1_000, 100_000)]
    public int N { get; set; }

    [IterationSetup]
    public void Reset()
    {
        _data = new int[N];
        for (var i = 0; i < N; i++)
        {
            _data[i] = _random.Next(int.MinValue, int.MaxValue);
        }
    }

    [Benchmark(Description = "Bubble Sort")]
    public void Bubble()
    {
        BubbleSort.Run(_data);
    }

    [Benchmark(Description = "Pancake Sort")]
    public void Pancake()
    {
        PancakeSort.Run(_data);
    }

    [Benchmark(Description = "Quick Sort")]
    public void Quick()
    {
        QuickSort.Run(_data);
    }
    
    [Benchmark(Description = "Merge Sort")]
    public void Merge()
    {
        MergeSort.Run(_data);
    }
    
    [Benchmark(Description = ".NET native sort")]
    public void Native()
    {
        _data.Order();
    }
}