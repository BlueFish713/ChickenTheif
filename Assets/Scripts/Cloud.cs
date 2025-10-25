using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Cloud : MonoBehaviour
{
    float speed, scale;
    public List<Sprite> sprite;
    void Start()
    {
        speed = Random.Range(0.005f, 0.01f);
        // scale = Random.Range(10f, 20f);
        // transform.localScale = new Vector3(scale, scale, 1);
        // transform.position = new Vector3(Random.Range(-60f, -59f), Random.Range(10f, 20f), 0);
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.sprite = sprite[Random.Range(0, sprite.Count)];
    }
    public void init(float x, float y)
    {
        transform.position = new Vector3(x, y, 0);
    }
    void Update()
    {
        transform.position += new Vector3(speed, 0, 0);
        if (transform.position.x > 65f)
        {
            Destroy(gameObject);
        }
    }
}
