using UnityEngine;

[RequireInScene] //
public class GameManager : MonoBehaviour
{
    void Awake()
    {
        SingletonManager.InitializeAllSingletons();
    }
}