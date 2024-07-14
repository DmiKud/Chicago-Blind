using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardCollection : MonoBehaviour
{
    public static CardCollection Instance;
    // [NonSerialized]
    public List<Card> allCards = new List<Card>();

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            LoadAllCards();
            // Debug.Log("There are " + CardCollection.Instance.allCards.Count + " in CardCollection");
        }
        else
        {
            Destroy(gameObject);
        }
    }


    void LoadAllCards()
    {
        Card[] cards = Resources.LoadAll<Card>("CardCollection");
        allCards.AddRange(cards);
    }


    public Card GetRandomCard()
    {
         if (allCards.Count == 0)
        {
            Debug.LogError("No cards available in the collection.");
            return null;
        }

        int randomIndex = UnityEngine.Random.Range(0, allCards.Count);
        return allCards[randomIndex];
    }


void PrintAllCards()
    {
        foreach (Card card in allCards)
        {
            Debug.Log("Card: " + card.cardName + ", Type: " + card.cardType + ", Strength: " + card.strength);
        }
    }



}
