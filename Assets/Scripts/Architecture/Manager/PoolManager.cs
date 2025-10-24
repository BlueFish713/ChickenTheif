using System;
using System.Collections.Generic;
using UnityEngine;

[Singleton]//RequireInScene
public class PoolManager : MonoBehaviour
{
    [Serializable]
    public struct Pool
    {
        public string key;
        public int count;
        public GameObject prefab;
        public List<GameObject> prefabList;

        public void Initialize()
        {
            //prefabList = new List<GameObject>();
            for (int i = 0; i < count; i++)
            {
                GameObject p = Instantiate(prefab);
                p.transform.SetParent(SingletonManager.Get<PoolManager>().transform);
                prefabList.Add(p);
                p.SetActive(false);
            }
        }
        public GameObject Get()
        {
            for (int i = 0; i < prefabList.Count; i++)
            {
                if (!prefabList[i].activeSelf)
                {
                    return prefabList[i];
                }
            }
            return null;
        }
    }

    [SerializeField] List<Pool> pools = new List<Pool>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        //DontDestroyOnLoad(gameObject);
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Initialize()
    {
        foreach (Pool p in pools)
        {
            p.Initialize();
        }
    }

    public GameObject Create(string key)
    {
        //Debug.Log(key);
        GameObject returnObject = FindPool(key).Get();
        //Debug.Log(returnObject);
        returnObject.SetActive(true);
        returnObject.transform.parent = null;
        return returnObject;
    }

    public void Delete(GameObject g)
    {
        g.transform.SetParent(gameObject.transform);
        g.SetActive(false);
    }

    Pool FindPool(string _key)
    {
        foreach (Pool p in pools)
        {
            if (p.key.Equals(_key))
            {
                //Debug.Log(String.Format("key: {0} / p: {1}", _key, p.key));
                return p;
            }
        }
        return new Pool();
    }
}
