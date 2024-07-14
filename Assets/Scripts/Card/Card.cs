using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CardType { Red, Blue, Green }

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : AbstractCard
{

    public void Print (){
    Debug.Log(cardName + description + cardType + strength);        
    }
 
}
