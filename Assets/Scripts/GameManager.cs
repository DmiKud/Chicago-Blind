using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    
    public static GameManager Instance;
    
    public List<Event> score;
    public int scorePoints = 4;
    public int winScore = 8; 
    
    public Event currentEvent;
    public EventQueue eventQueue;

    public GameObject CardPrefab;
    public GameObject EventPrefab;
    // public TextMeshProUGUI scoreText;
    public TextMeshProUGUI eventName;

    
    public Transform[] cardSlots;
    public bool[] availableCardSlots;

    private GraphicRaycaster _graphicRaycaster;
    public EventSystem eventSystem;


    void Awake()
        {
            if (Instance == null)
            {   
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }


    void Start()
    {
        _graphicRaycaster = GetComponent<GraphicRaycaster>();       
        // scoreText.text = scorePoints.ToString();
        Debug.Log("There are " + scorePoints + " progress points");
        eventName.text = currentEvent.ToString();
        EventQueue.Init();
        NextEvent();
    }
    

    void NextEvent()
    {
        if (EventQueue.Instance.eventQueue.Count > 0)
        {
            currentEvent = EventQueue.Instance.eventQueue.Dequeue();
            // UpdateEventUI();
        }
    }

    public void NextStep(int cardIndex, Event currentEvent)
    {
        currentEvent.PlayCard(Hand.hand[cardIndex], this);
        // Debug.Log(Hand.hand[cardIndex]);

        // UpdateUI();

        if (scorePoints <= 0)
        {
            Debug.Log("U R lose");
        }
        else if (scorePoints >= winScore)
        {
            Debug.Log("U R win");
        }
        else
        {
            Hand.Instance.Remove(cardIndex);
            Hand.Instance.DrawCard(cardIndex);
            Debug.Log("Hand is: " + Hand.hand[0] + Hand.hand[1] +  Hand.hand[2] + Hand.hand[3]);
            Debug.Log($"Played {Hand.hand[cardIndex]} for {currentEvent}");
            NextEvent();
            // Debug.Log($"{currentEvent} is next Event");
        }
    }

    void UpdateUI()
    {
        // Logic to update health and score UI
    }
}