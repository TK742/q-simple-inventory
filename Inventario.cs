using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    public List<Slot> inventory;

    public void Add(Item item)
    {
        Add(item.itemName, item.itemQuantity);
        Destroy(item.gameObject);
    }

    public void Add(string itemName, int itemQuantity)
    {
        Slot slot = inventory.Find(_slot => _slot.name == itemName);
        if (slot == null) inventory.Add(new Slot(itemName, itemQuantity));
        else slot.quantity += itemQuantity;
    }

    public void Delete(string itemName, int itemQuantity)
    {
        Slot slot = inventory.Find(_slot => _slot.name == itemName);
        if (slot != null && slot.quantity - itemQuantity >= 0)
        {
            slot.quantity -= itemQuantity;
            if (slot.quantity == 0) inventory.Remove(slot);
        }
    }
}

[System.Serializable]
public class Slot
{
    public string name;
    public int quantity;

    public Slot (string name, int quantity)
    {
        this.name = name;
        this.quantity = quantity;
    }
}