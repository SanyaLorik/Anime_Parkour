using System;

public static class ConditionalExtension
{
    public static T Correct<T>(this T source, Action<T> method)
        where T : class
    {
        if (source == null)
            return null;

        method.Invoke(source);
        return source;
    }

    public static T CorrectArguments<T>(this T source, params Action<T>[] methods)
        where T : class
    {
        if (source == null)
            return null;

        foreach (var method in methods)
            method.Invoke(source);

        return source;
    }

    public static T CorrectWithoutArguments<T>(this T source, params Action[] methods)
        where T : class
    {
        if (source == null)
            return null;

        foreach (var method in methods)   
            method.Invoke();
        
        return source;
    }
    
    public static T CorrectWithoutArguments<T>(this T source, Action method)
        where T : class
    {
        if (source == null)
            return null;

        method.Invoke();
        
        return source;
    }

    public static T Incorrect<T>(this T source, Action method)
        where T : class
    {
        if (source == null)
            method.Invoke();

        return source;
    }

    public static T Finally<T>(this T source, Action method)
    {
        method.Invoke();
        return source;
    }

    public static bool Compare<T>(this Func<bool> source)
    {
        return source.Invoke();
    }

    public static bool Correct(this bool source, Action method)
    {
        if (source == true)
            method.Invoke();

        return source;
    }

    public static bool Incorrect(this bool source, Action method)
    {
        if (source == false)
            method.Invoke();

        return source;
    }

    public static T IsCorrect<T>(this T source, Func<T, bool> conditional) 
        where T : class
    {
        if (source == null)
            return null;
        
        if (conditional == null)
            return null;
        
        if (conditional.Invoke(source) == false)
            return null;

        return source;
    }
    
    public static T IsCorrect<T>(this T source, Func<T, bool> conditional, Action wrong) 
        where T : class
    {
        if (source == null)
            return null;
        
        if (conditional == null)
            return null;

        if (wrong == null)
            return null;
        
        if (conditional.Invoke(source) == false)
        {
            wrong.Invoke();
            return null;
        }

        return source;
    }
}
