using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls which windows are open (menu, inventory)
/// </summary>
public class WindowsManager : MonoBehaviour
{

    [SerializeField] GameObject menu;
    [SerializeField] InventoryUI inventoryUi;
    [SerializeField] CameraMovement cameraMovement;

    bool menuIsOpened, inventoryUiIsOpened;



    void OpenMenu(bool flag) {
        menu.SetActive(flag);
        menuIsOpened = flag;

        cameraMovement.windowOpened = flag;
    }

    public void OpenInventory(bool flag) {
        if (flag) inventoryUi.OpenInventoryWindow();
        else inventoryUi.CloseInventoryWindow();

        inventoryUiIsOpened = flag;

         cameraMovement.windowOpened = flag;
    }

    public void closeInventoryWithButtonX() {
        OpenInventory(false);
        ResumeGame();
    }

    public void CloseMenuWithButton() {
        OpenMenu(false);
        Time.timeScale = 1;
    }

    void PauseGame() => Time.timeScale = 0;

    void ResumeGame() => Time.timeScale = 1;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)) {          
            if (menuIsOpened) return;

            else if (inventoryUiIsOpened)           //close Inventory with I
            {
                OpenInventory(false);
                ResumeGame();
            }

            else { 
                OpenInventory(true);        //Open Inventory with I
                PauseGame();
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape)) { //Close Menu with esc
            if (menuIsOpened)
            {
                OpenMenu(false);
                ResumeGame();
            }

            else if (inventoryUiIsOpened) { //Close Inventory with esc
                OpenInventory(false);
                ResumeGame();
            }

            else {              //Open Menu
                OpenMenu(true);
                PauseGame();
            }

        }

    }
}
