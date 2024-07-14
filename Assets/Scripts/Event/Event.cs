using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;


[CreateAssetMenu(fileName = "New Event", menuName = "Event")]
public class Event : AbstractEvent
{

  [Header("Effects")]
  [SerializeField] private int effectRed;
  [SerializeField] private int effectGreen;
  [SerializeField] private int effectBlue; 
  public override void PlayCard(Card card, GameManager state)
  {
    Debug.Log($"Card {card} was played (metod PlayCard)");
    switch (card.cardType){
        case CardType.Red:
        GameManager.Instance.score.Add(this);
        GameManager.Instance.scorePoints += effectRed;
            break;
        case CardType.Green:
        GameManager.Instance.score.Add(this);
        GameManager.Instance.scorePoints += effectGreen;
            break;
        case CardType.Blue:
        GameManager.Instance.score.Add(this);
        GameManager.Instance.scorePoints += effectBlue;
            break;
    }
  }
}
