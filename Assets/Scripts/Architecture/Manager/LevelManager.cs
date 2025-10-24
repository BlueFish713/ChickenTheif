using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[Singleton]
public class LevelManager : MonoBehaviour
{
    [SerializeField] List<string> sceneNames;
    [SerializeField] int index = 0;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        var currentScene = SceneManager.GetActiveScene().name;
        index = 0;
        for (int i = 0; i < sceneNames.Count; i++)
        {
            if (sceneNames[i].Equals(currentScene))
            {
                index = i;
            }
        }
    }

    void Start()
    {
        EventManager.Subscribe(EventName.StartPointTouched, () =>
        {
            Debug.Log(sceneNames.Count);
            Debug.Log(index);
            SceneManager.LoadScene(sceneNames[++index]);
        });
    }
}
