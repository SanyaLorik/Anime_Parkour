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

    public static T GetRandomElement<T>(this IReadOnlyList<T> sources)
    {
        return sources[UnityEngine.Random.Range(0, sources.Count)];
    }

    public static IEnumerable<T> GetParamsAsIEnumerable<T>(params T[] sources)
    {
        return sources;
    }

    public static IReadOnlyList<T> GetRandomElementsByPercent<T>(this IReadOnlyList<T> sources, float percent, bool mustReturned = false)
        where T : class
    {
        if (sources.Count == 0) 
            return new T[0];

        float lenght = sources.Count * percent;
        if (0 < lenght && lenght < 1)
            return mustReturned == true ? new T[1] { sources.GetRandomElement() } : new T[0];

        int count = (int)lenght;
        List<T> result = new(count);

        if (count == 1)
        {
            result.Add(sources.GetRandomElement());
            return result;
        }

        do
        {
            var random = sources.GetRandomElement();
            result.Any(i => i == random).Incorrect(() => result.Add(random));
        } 
        while (result.Count < count);

        return result;
    }
}
