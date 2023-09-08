using UnityEngine;

public static class PhysicsExtension
{
    public static float CalculateForceNoMass(float distance)
    {
        float g = -Physics2D.gravity.y;
        return Mathf.Sqrt(2 * (g * distance));
    }
}