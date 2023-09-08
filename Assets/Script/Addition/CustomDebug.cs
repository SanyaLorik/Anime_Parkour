using UnityEngine;

public static class CustomDebug
{
    public static void Log(params object[] objects)
    {
        Debug.Log(string.Join(" ", objects));
    }

    public static void Log(params string[] strings)
    {
        Debug.Log(string.Join(" ", strings));
    }
}