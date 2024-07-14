using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractCard : ScriptableObject
{
   public string cardName;
    public string description;
    public CardType cardType;
    public int strength;
    public Sprite cardImage;
}
