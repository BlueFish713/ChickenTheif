using UnityEngine;

[RequireInScene]
public class BasicImage : MonoBehaviour
{
    [SerializeField] private Sprite _sprite;

    public static Sprite Sprite { get; private set; }

    void Awake()
    {
        Sprite = _sprite;

        if (Sprite == null) Debug.LogWarning("You Need To Assign BasicImage Sprite!");
    }
}