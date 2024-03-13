using System.Collections.Generic;
using UnityEngine;

public enum EquipmentType
{
    FullBody,
    TorsoLegs,
    Torso,
    Legs,
    Shoes,

}

[CreateAssetMenu(fileName = "New Clothing Item", menuName = "Inventory/Clothing Item")]
public class ClothingItem : ScriptableObject
{
    // TODO: Change all these to camel case
    public string Name;
    public EquipmentType Type;
    public Sprite Icon;
    //public Sprite EquippedCharacterSprite;
    public int Price;
    public bool ModulateColour;
    public Color Colour;

    public List<Sprite> NorthSprites;
    public List<Sprite> EastSprites;
    public List<Sprite> SouthSprites;
    
}
