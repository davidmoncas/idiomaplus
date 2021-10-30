using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls the items collected
/// </summary>
public class InventoryManager : MonoBehaviour
{

    public List<Collectable> ItemsCollected;
    public int InventorySize; //How many items can the player collect

    [SerializeField] InventoryUI InventoryUI;

    public void AddToInventory(Collectable collectable) {

        if (ItemsCollected.Count < InventorySize)
            ItemsCollected.Add(collectable);
        else
            Debug.LogWarning("the inventory is full"); 
    }

    public void ConsumeItem(Collectable collectable) {
        Time.timeScale = 0.1f;
        collectable.OnConsume();
        ItemsCollected.Remove(collectable);
        InventoryUI.PopulateSlots();
        Time.timeScale = 0;
    }   
}
