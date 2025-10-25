using System.Collections;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public GameObject cloudPrefab;
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject cloud = Instantiate(cloudPrefab);
            Cloud cloudCode = cloud.GetComponent<Cloud>();
            cloudCode.init(Random.Range(-60f, 65f), Random.Range(10f, 20f));
        }
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            GameObject cloud = Instantiate(cloudPrefab);
            Cloud cloudCode = cloud.GetComponent<Cloud>();
            cloudCode.init(-60f, Random.Range(10f, 20f));
            yield return new WaitForSeconds(Random.Range(2f, 6f));
        }
    }
}
