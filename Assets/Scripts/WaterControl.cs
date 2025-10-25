using UnityEngine;

public class WaterControl : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] float xOffset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(target.transform.position.x - (transform.position.x+xOffset), 0, 0);
    }
}
