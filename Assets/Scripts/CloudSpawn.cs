using System.Collections;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public GameObject cloudPrefab;
    void Start()
    {
        for (int i = 0; i < 20; i++)
        {
            GameObject cloud = Instantiate(cloudPrefab);
            Cloud cloudCode = cloud.GetComponent<Cloud>();
            cloudCode.init(Mathf.Lerp(-60f, 60f, (i+1)/20f), Random.Range(10f, 20f)); // -60 60
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
            yield return new WaitForSeconds(15);
        }
    }
}
