using System.Collections.Generic;
using System.Linq;

public static class ArrayExtension
{
    public static T GetRandomElement<T>(this T[] sources)
    {
        return sources[UnityEngine.Random.Range(0, sources.Length)];
    }

    public static T GetRandomElementWithExclusion<T>(this T[] sources, IEnumerable<T> exclusions)
        where T : class
    {
        T result;
        bool isFound = false;

        do
        {
            result = sources[UnityEngine.Random.Range(0, sources.Length)];
            isFound = exclusions.Any(i => i == result) == false;
        }
        while (isFound == false);

        return result;
    }

    public static T GetRandomElement<T>(this IEnumerable<T> sources)
    {
        var a = sources.ToArray();
        return a[UnityEngine.Random.Range(0, a.Length)];
    }

    public static IEnumerable<T> GetParamsAsIEnumerable<T>(params T[] sources)
    {
        return sources;
    }
}
