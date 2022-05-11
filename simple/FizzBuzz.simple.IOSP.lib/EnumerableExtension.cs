namespace FizzBuzz.simple.IOSP.lib;

internal static class EnumerableExtension
{
    public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
    {
        foreach (var item in enumerable) 
            action(item);
    }
}