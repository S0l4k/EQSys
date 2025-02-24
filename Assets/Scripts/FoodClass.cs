using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Food class", menuName = "Item/food")]
public class FoodClass : ItemClass
{
    [Header("Food")]
    public FoodType foodType;
    public enum FoodType
    {
       chlebek,
       mleczko,
       bigos
    }
    public override ItemClass GetItem() { return this; }
    public override ArmorClass GetArmor() { return null ; }
    public override FoodClass GetFood() { return this; }
}
