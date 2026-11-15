using System.Diagnostics;
using EnumerablePrinter.Extensions;

namespace Coding.Exercises;

public static class MethodBenchmark
{
    private const int DefaultIterations = 100_000;

    public static T Run<T>(
        string name,
        Func<T> method,
        int iterations = DefaultIterations)
    {
        ArgumentNullException.ThrowIfNull(method);
        ValidateIterations(iterations);

        // Warm up and preserve the result.
        T result = method();

        RunBenchmark(
            name,
            () => _ = method(),
            iterations);

        return result;
    }

    public static void Run(
        string name,
        Action method,
        int iterations = DefaultIterations)
    {
        ArgumentNullException.ThrowIfNull(method);
        ValidateIterations(iterations);

        // Warm up.
        method();

        RunBenchmark(name, method, iterations);
    }

    private static void RunBenchmark(
        string name,
        Action method,
        int iterations)
    {
        var stopwatch = Stopwatch.StartNew();

        for (int i = 0; i < iterations; i++)
        {
            method();
        }

        stopwatch.Stop();

        PrintResults(name, iterations, stopwatch.Elapsed);
    }

    private static void PrintResults(
        string name,
        int iterations,
        TimeSpan elapsed)
    {
        var results = new Dictionary<string, string>
        {
            ["Method"] = name,
            ["Benchmark Runs"] = $"{iterations:N0}",
            ["Total"] = $"{elapsed.TotalMilliseconds:N3} ms",
            ["Average Per Run"] =
                $"{elapsed.TotalNanoseconds / iterations:N3} ns"
        };

        results.Print();
    }

    private static void ValidateIterations(int iterations)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(iterations);
    }
}