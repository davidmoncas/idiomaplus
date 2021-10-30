using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// For selecting items in the Inventory window
/// </summary>
public class InventorySlot : MonoBehaviour
{
    public Collectable collectable;
    public Image imageIcon;

    InventoryUI inventoryUI;

    private void Start()
    {
        inventoryUI = FindObjectOfType<InventoryUI>();
    }

    public void SelectItem() {
        inventoryUI.SelectItem(collectable);
    }
}
