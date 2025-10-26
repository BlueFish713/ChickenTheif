using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightManager : MonoBehaviour
{
    [SerializeField] GlobalLightControl globalLightControl;
    [SerializeField] List<Light2D> lights = new List<Light2D>();
    void Awake()
    {
        EventManager.Subscribe(EventName.DayChanged, () =>
        {
            if (globalLightControl.night)
            {
                foreach (var l in lights)
                {
                    l.enabled = true;
                }
            }
            else
            {
                foreach (var l in lights)
                {
                    l.enabled = false;
                }
            }
        });foreach (var l in lights)
                {
                    l.enabled = false;
                }
    }
}
