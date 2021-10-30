using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// trigger attached to the player that tells what objects or enemies are in range
/// </summary>
public class SearchForItems : MonoBehaviour
{

    [SerializeField] UIManager ui;
    [SerializeField] InventoryManager inventoryManager;
    Collectable nearItem;

    public Enemy nearEnemy;

    private void OnTriggerEnter(Collider collision)
    {
        Collectable itemToPick = collision.gameObject.GetComponent<Collectable>();
        if (itemToPick != null) {
            ui.ShowPickUpElement("Pick" + itemToPick.name);
            nearItem = itemToPick;
        }

        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null) nearEnemy = enemy;

    }

    private void OnTriggerExit(Collider collision)
    {
        Collectable itemToPick = collision.gameObject.GetComponent<Collectable>();
        if (itemToPick != null)
        {
            ui.HidePickUpElement();
            nearItem = null;
        }

        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy == null && nearEnemy!= null) nearEnemy = null;
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && nearItem != null) {

            PickItem();
        }
    }

    void PickItem() {
        inventoryManager.AddToInventory(nearItem);

        Destroy(nearItem.gameObject.GetComponent<Collider>());
        Destroy(nearItem.gameObject.GetComponent<MeshRenderer>());

        nearItem.transform.parent = inventoryManager.transform; //set all the picked items into the manager without its renderer and collider

        ui.HidePickUpElement();
        nearItem = null;
    }
}
