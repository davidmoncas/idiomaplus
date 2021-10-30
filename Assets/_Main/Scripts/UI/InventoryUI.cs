using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// Controls the stored items in the inventory (allows to add and Use items)
/// </summary>
public class InventoryUI : MonoBehaviour
{

    [SerializeField] InventoryManager inventoryManager;
    [SerializeField] GameObject InventoryWindow;

    [SerializeField] Text descriptionText , titleText;

    [SerializeField] List<InventorySlot> slots;

    Collectable selectedItem;

    public void OpenInventoryWindow() {
        InventoryWindow.SetActive(true);
        PopulateSlots();
    }

    public void CloseInventoryWindow() {
        InventoryWindow.SetActive(false);
    }


    public void PopulateSlots() {

        titleText.text = "";
        descriptionText.text = "";

        // set all the icons to empty
        foreach(InventorySlot slot in slots)
        {
            slot.collectable = null;
            slot.imageIcon.enabled = false;
        }


        int counter = 0;
        foreach (Collectable collectable in inventoryManager.ItemsCollected) {
            slots[counter].collectable = collectable;
            slots[counter].imageIcon.enabled = true;
            slots[counter].imageIcon.sprite = collectable.inventoryIcon;
            counter++;
        }
    }

    public void SelectItem(Collectable collectable) {
        descriptionText.text = collectable.objectDescription;
        titleText.text = collectable.nameOfObject;
        selectedItem = collectable;
    }

    public void ConsumeItem() {
        inventoryManager.ConsumeItem(selectedItem);
    }
}
