using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject {
    public new string name;
    public string description;

    public Sprite image;
    
    public float defaultSpeed;
    public float defaultHealth;
    public float defaultStrength;
    public float defaultEnergy;

    public float energyCost;
}
