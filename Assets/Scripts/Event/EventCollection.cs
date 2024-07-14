using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventCollection : MonoBehaviour

{
    public static EventCollection Instance;
    public List<Event> allEvents = new List<Event>();

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            LoadAllEvents();
            // Debug.Log("There are " + EventCollection.Instance.allEvents.Count + " in EventCollection");
        }
        else
        {
            Destroy(gameObject);
        }
    }


    void LoadAllEvents()
    {
        Event[] events = Resources.LoadAll<Event>("EventCollection");
        allEvents.AddRange(events);
    }


    public Event GetRandomEvent()
    {
        int randomIndex = Random.Range(0, allEvents.Count);
        return allEvents[randomIndex];
    }
}
