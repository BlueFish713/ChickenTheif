using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundMusic : MonoBehaviour
{
    AudioSource AS;

    [SerializeField] AudioClip Night;
    [SerializeField] AudioClip Day;
    float vol;
    void Start()
    {
        AS = GetComponent<AudioSource>();
        AS.Play();

        EventManager.Subscribe(EventName.DayChanged, CheckNightDay);
        CheckNightDay();
    }

    public void Update()
    {
        AS.volume = vol;
    }

    public void CheckNightDay()
    {
        if (SingletonManager.Get<GlobalLightControl>().night)
        {
            ChangeBGM(Night);
        }
        if (!SingletonManager.Get<GlobalLightControl>().night)
        {
            ChangeBGM(Day);
        }
    }

    public void ChangeBGM(AudioClip AC)
    {
        StopAllCoroutines();
        StartCoroutine(VolumDown(AC));
    }

    IEnumerator VolumDown(AudioClip AC)
    {
        Debug.Log("Volume Down");
        yield return new WaitForSecondsRealtime(0.015f);
        vol -= 0.01f;
        if (vol <= 0)
        {
            AS.clip = AC;
            AS.Play();

            StartCoroutine(VolumUp(AC));
        }
        else StartCoroutine(VolumDown(AC));
    }
    IEnumerator VolumUp(AudioClip AC)
    {
        Debug.Log("Volume Up");
        yield return new WaitForSecondsRealtime(0.015f);
        vol += 0.01f;
        if (vol >= 1)
        {
            yield return null;
        }
        else StartCoroutine(VolumUp(AC));
    }
}
