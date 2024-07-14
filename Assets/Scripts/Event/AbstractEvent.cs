using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using System;

public abstract class AbstractEvent : ScriptableObject
{    
public abstract void PlayCard(Card card, GameManager state);

public Sprite eventImage;

public String eventName;

public string description; 
}