using System.Collections;
using UnityEngine;

public class MoneyEarned : MonoBehaviour
{
    SpriteRenderer sr;
    public float height = 0.02f;
    public float delay = 0.05f;
    float alpha;

    public void Init(Transform transform)
    {
        sr = GetComponent<SpriteRenderer>();
        this.transform.position = transform.position;
        StartCoroutine(Rise());
    }

    IEnumerator Rise()
    {
        for (int i = 0; i < 10; i++)
        {
            transform.position += Vector3.up * height;
            yield return new WaitForSeconds(delay);
            Color c = sr.color;
            c.a -= 0.1f;
            sr.color = c;
        }

        Destroy(gameObject);
    }
}
