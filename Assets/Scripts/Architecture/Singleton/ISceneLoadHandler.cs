using UnityEngine;
using UnityEngine.SceneManagement;

public interface ISceneLoadHandler
{
    void OnSceneLoaded(Scene scene, LoadSceneMode mode);
}
