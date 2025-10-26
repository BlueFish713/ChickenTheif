using UnityEngine;

public class SunAndMoon : MonoBehaviour
{

    [SerializeField] SpriteRenderer sr;
    public Sprite sun;
    public Sprite moon;
    void Start()
    {
        EventManager.Subscribe(EventName.DayChanged, () =>
        {
            if (SingletonManager.Get<GlobalLightControl>().night)
            {
                sr.sprite = moon;
            }
            else sr.sprite = sun;
        });
    }
}