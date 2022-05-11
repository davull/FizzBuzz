namespace FizzBuzz.simple.IOSP.lib;

public static class FizzBuzzIntegration
{
    public static void GetFizzBuzz(int start, int count, Action<string> output) =>
        GenerateNumbers(start: start, count: count)
            .Select(FizzBuzzOperation.TransformNumber)
            .ForEach(output);

    private static IEnumerable<int> GenerateNumbers(int start, int count)
        => Enumerable.Range(start: start, count: count);
}