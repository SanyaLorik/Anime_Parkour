using UnityEngine;

public static class VectorExtension
{
    public static Vector3 ZeroXZ(ref this Vector3 source)
    {
        source.x = 0;
        source.z = 0;

        return source;
    }
}