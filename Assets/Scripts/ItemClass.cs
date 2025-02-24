using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemClass : ScriptableObject
{
    [Header ("Item")]
    public string itemName;
    public Sprite itemIcon;
    public bool isStackable=true;
    public abstract ItemClass GetItem();
    public abstract ArmorClass GetArmor();
    public abstract FoodClass GetFood();
}
