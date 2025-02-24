using System.Collections;
using System.IO.Enumeration;
using UnityEngine;

[CreateAssetMenu(fileName="new Armor class", menuName ="Item/armor" )]
public class ArmorClass : ItemClass
{
    [Header("Armor")]
    public ArmorType armorType;
    public enum ArmorType
    {
        helmet,
        torso,
        leggins,
        shoes
    }
    public  override ItemClass GetItem() { return this; }
    public override ArmorClass GetArmor() { return this; }
    public override FoodClass GetFood() { return null; }
}
