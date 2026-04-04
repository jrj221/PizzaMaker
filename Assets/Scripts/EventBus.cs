using System;
using System.Collections.Generic;

public static class EventBus
{
    private static readonly Dictionary<string, Action<object>> _events = new();

    public static void Subscribe(string eventName, Action<object> listener)
    {
        if (!_events.ContainsKey(eventName))
        {
            _events[eventName] = listener;
        }
        else
        {
            _events[eventName] += listener;
        }
    }

    public static void Unsubscribe(string eventName, Action<object> listener)
    {
        if (_events.ContainsKey(eventName))
        {
            _events[eventName] -= listener;
        }
    }

    public static void Trigger(string eventName, object param = null)
    {
        if (_events.ContainsKey(eventName))
        {
            _events[eventName].Invoke(param);
        }
    }
}