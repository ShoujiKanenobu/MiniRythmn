using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//https://github.com/roboryantron/Unite2017/tree/master/Assets/Code/Events
[CreateAssetMenu]
public class GameEvent : ScriptableObject
{
    private readonly List<GameEventListener> listeners = new List<GameEventListener>();

    public void Raise()
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
            listeners[i].OnEventRaised();
    }

    public void RegisterListener(GameEventListener l)
    {
        if (!listeners.Contains(l))
            listeners.Add(l);
    }

    public void UnregisterListener(GameEventListener l)
    {
        if (listeners.Contains(l))
            listeners.Remove(l);
    }

}
