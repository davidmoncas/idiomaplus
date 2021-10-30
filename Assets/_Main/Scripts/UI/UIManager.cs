using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// Controls all the elements from the Graphical User Interface
/// </summary>
public class UIManager : MonoBehaviour
{
    [Header("UI Objects")]
    [SerializeField] Image staminaBar;
    [SerializeField] Image healthBar;
    [SerializeField] GameObject pickElementPopup;
    [SerializeField] Text pickElementText;

    [Header("References to other things")]
    [SerializeField] PlayerMovement playerMovement;



    public void SetHealthBar(float amount, float max) {
        healthBar.fillAmount=amount / max;
    }

    void Update()
    {
        staminaBar.fillAmount = playerMovement.stamina / playerMovement.initialStamina;
    }

    public void ShowPickUpElement(string message) {
        pickElementPopup.SetActive(true);
        pickElementText.text = message;
    }
    public void HidePickUpElement() {
        pickElementPopup.SetActive(false);
    }
}
