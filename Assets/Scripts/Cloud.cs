using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Cloud : MonoBehaviour
{
    float speed;
    public List<Sprite> sprite;
    // public SpeechBubble bubblePrefab;
    // SpeechBubble bubbleInstance;
    void Start()
    {
        speed = Random.Range(0.002f, 0.005f);
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.sprite = sprite[Random.Range(0, sprite.Count)];

        // bubbleInstance = Instantiate(bubblePrefab);
        // bubbleInstance.Setup(transform);
        // bubbleInstance.Show("ABCDEFGHIJKLMNOPQRSTUVWXYZ".Substring(0, Random.Range(1,24)));
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
