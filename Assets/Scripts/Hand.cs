using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class Hand : MonoBehaviour
{
    static public int handSize;

    static public Dictionary<int, Card> hand = new Dictionary<int, Card>(); 

    public static Hand Instance;


    void Start()
    {
        // handSize = 4;
        // DrawInitialCards();
        Debug.Log("Hand is: " + hand[0] + hand[1] +  hand[2] + hand[3]);
    }


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
        handSize = 4;
        DrawInitialCards();
        }


    public void DrawInitialCards()
        {
         for (int i = 0; i < handSize; i++)
           {
            DrawCard(i);
          }
        }


    public void DrawCard(int i)
        {
        if (!hand.ContainsKey(i) || hand[i] == null)
        {
           hand[i] = CardCollection.Instance.GetRandomCard();
           Debug.Log($"Card {i} drawn: {hand[i]}");
        }        
           else
        {
            Debug.Log($"Slot {i} already has a card: {hand[i].cardName}");
        }
        }
    
    public void Remove(int index)
    {
        if (index != -1) //не понимаю почему -1? 
        {
            Debug.Log($"Card {index} removed: {hand[index]}");
            hand[index] = null; // Удаление карты из руки
            
        }
        else
        {
            Debug.LogError("Failed to remove card: Card not found in hand.");
        }
    }
    
    }