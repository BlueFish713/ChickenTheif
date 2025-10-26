#nullable enable
using UnityEngine;

public static class AngleBase
{
    public static float Vector2ToEuler(Vector2 dir)
    {
        return Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
    }

    public static Vector2 EulerToVector2(float angleDeg)
    {
        float rad = angleDeg * Mathf.Deg2Rad;
        return new Vector2(Mathf.Cos(rad), Mathf.Sin(rad));
    }
}