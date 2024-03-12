using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class CreateInventorySlot
{
    [MenuItem("GameObject/UI/Inventory/Inventory Slot")]
    public static void Create(MenuCommand menuCommand)
    {
        // Create a new GameObject
        GameObject inventorySlot = new GameObject("InventorySlot");

        // Add necessary components
        inventorySlot.AddComponent<RectTransform>();
        inventorySlot.AddComponent<Image>();
        inventorySlot.AddComponent<Button>();

        // Set parent and reset position
        GameObjectUtility.SetParentAndAlign(inventorySlot, menuCommand.context as GameObject);
        RectTransform rectTransform = inventorySlot.GetComponent<RectTransform>();
        rectTransform.localPosition = Vector3.zero;
        rectTransform.localScale = Vector3.one;

        // Register the creation in the undo system
        Undo.RegisterCreatedObjectUndo(inventorySlot, "Create Inventory Slot");
        Selection.activeObject = inventorySlot;
    }
}
