using System.Diagnostics;
using EnumerablePrinter.Extensions;

namespace Coding.Exercises;

public static class MethodBenchmark
{
    public static T Run<T>(
        string name,
        Func<T> method,
        int iterations = 100_000)
    {
        // Warm-up and capture result
        T result = method();

        var stopwatch = Stopwatch.StartNew();

        for (int i = 0; i < iterations; i++)
        {
            _ = method();
        }

        stopwatch.Stop();

        PrintResults(name, iterations, stopwatch.Elapsed);

        return result;
    }

    public static void Run(
        string name,
        Action method,
        int iterations = 100_000)
    {
        // Warm-up
        method();

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
}