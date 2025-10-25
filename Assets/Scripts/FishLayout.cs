using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class FishLayout : MonoBehaviour
{
    [SerializeField] float spacing;
    [SerializeField] GameObject fishPrefab;
    [SerializeField] List<GameObject> loadedGameObject = new List<GameObject>();

    FishImageRepository repo;

    void Start()
    {
        repo = SingletonManager.Get<FishImageRepository>();
    }

    public void Load(UntrimmedData untrimmedData)
    {
        Debug.Log("Load Start");
        GameObject fish = Instantiate(fishPrefab);

        fish.GetComponent<SpriteRenderer>().sprite = repo.fishImages[untrimmedData.fish];

        fish.transform.SetParent(transform);

        if (loadedGameObject.Count == 0) fish.transform.localPosition = Vector3.zero;
        else fish.transform.localPosition = loadedGameObject[loadedGameObject.Count - 1].transform.localPosition + Vector3.up * spacing;
        
        loadedGameObject.Add(fish);
        Debug.Log($"Load Finish : {loadedGameObject.Count}");
    }

    public void Load(TrimmedData trimmedData)
    {
        GameObject fish = Instantiate(fishPrefab);
        fish.GetComponent<SpriteRenderer>().sprite = repo.fishImages[trimmedData.fish];
        if (loadedGameObject.Count == 0) fish.transform.localPosition = Vector3.zero;
        fish.transform.localPosition = loadedGameObject[loadedGameObject.Count - 1].transform.localPosition + Vector3.up*spacing;
    }

    public void UnLoad()
    {
        Destroy(loadedGameObject[loadedGameObject.Count - 1], 0.01f);
        loadedGameObject.RemoveAt(loadedGameObject.Count - 1);
    }
    
        
    public void UnLoadAll()
    {
        int c = loadedGameObject.Count;
        for (int i = 0; i < c; i++)
        {
            UnLoad();
        }
    }
}
