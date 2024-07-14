using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.PlayerLoop;


public class EventQueue
{

    public Queue<Event> eventQueue = new Queue<Event>();
    public static EventQueue Instance;

    public int Count { get; internal set; }


    public static void Init() 
    {
        Instance = new EventQueue();
        Instance.AddEvents(100);
        Debug.Log($"EventQueue contains {EventQueue.Instance.eventQueue.Count}");
    }



    public void AddEvents(int n)
    {
        for (int i = 0; i < n; i++)
            {
                eventQueue.Enqueue(EventCollection.Instance.GetRandomEvent());
            }
    }


    
    void Update()
    {
        
    }
}
