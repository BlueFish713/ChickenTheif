using UnityEngine;

public static class MoveBase
{
    public static float GetDuration(Vector2 vec1, Vector2 vec2, float moveSpeed)
    {
        float distance = Vector2.Distance(vec1, vec2);
        return distance / moveSpeed;
    }
    public static float GetDuration(Vector3 vec1, Vector3 vec2, float moveSpeed)
    {
        return GetDuration((Vector2)vec1, (Vector2)vec2, moveSpeed);
    }

public static bool GetFlipX(Vector2 startPosition, Vector2 endPosition)
{
    return startPosition.x > endPosition.x;
}
}