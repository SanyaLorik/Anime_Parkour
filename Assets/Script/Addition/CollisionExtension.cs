using UnityEngine;

public static class CollisionExtension
{
    public static T ReciveComponent<T>(this GameObject source)
        where T : class
    {
        return source == null ? null : source.GetComponent<T>();
    }

    public static T ReciveComponent<T>(this Component source)
        where T : class
    {
        return source == null ? null : source.GetComponent<T>();
    }

    public static T ReciveComponent<T>(this Collision source)
        where T : class
    {
        return source == null ? null : source.gameObject.GetComponent<T>();
    }

    public static T SetFlagTrue<T>(this T source, ref bool flag)
        where T : class
    {
        if (source != null)
            flag = true;

        return source;
    }

    public static T SetFlagFalse<T>(this T source, ref bool flag)
        where T : class
    {
        if (source != null)
            flag = false;

        return source;
    }

    public static T SetFlag<T>(this T source, ref bool flag, bool value)
        where T : class
    {
        if (source != null)
            flag = value;

        return source;
    }
}
