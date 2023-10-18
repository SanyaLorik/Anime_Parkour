using System;

public static class LoopExtension 
{
    public static void RepeatMethod(this int count, Action method)
    {
        for (int i = 0; i < count; i++)
            method.Invoke();
    }

    public static void RepeatMethod<T>(this int count, Func<T> method)
    {
        for (int i = 0; i < count; i++)
            method.Invoke();
    }
}