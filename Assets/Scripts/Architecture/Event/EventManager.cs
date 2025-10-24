using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager
{
    public static Dictionary<EventName, UnityEvent> Events = new Dictionary<EventName, UnityEvent>();

    public static void Subscribe(EventName eventName, UnityAction action)
    {
        UnityEvent _event;
        if (Events.TryGetValue(eventName, out _event))
            _event.AddListener(action);

        else
        {
            _event = new UnityEvent();
            _event.AddListener(action);
            Events.Add(eventName, _event);
        }
    }

    public static void UnSubscribe(EventName eventName, UnityAction action)
    {
        UnityEvent _event;
        if (Events.TryGetValue(eventName, out _event))
            _event.RemoveListener(action);
    }

    public static void Publish(EventName eventName)
    {
        UnityEvent _event;
        if (Events.TryGetValue(eventName, out _event))
            _event.Invoke();
    }
}
