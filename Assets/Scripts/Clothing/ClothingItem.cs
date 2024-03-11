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
    public string Name;
    public EquipmentType Type;
    public Sprite Icon;
    public Sprite EquippedCharacterSprite;
    public float Price;
    public bool ModulateColour;
    public Color Colour;

    public List<Sprite> NorthSprites;
    public List<Sprite> EastSprites;
    public List<Sprite> SouthSprites;
    
    // Method to equip the clothing item
    public void Equip()
    {
        // Implement equip logic here
    }

    public void Unequip()
    {

    }
}
