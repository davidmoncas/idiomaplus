using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Abstract class to create collectable objects (potions, weapons, etc)
/// </summary>
public abstract class Collectable : MonoBehaviour
{

    public Sprite inventoryIcon;
    public string nameOfObject;
    public string objectDescription;

    public virtual void OnConsume() { }

}

