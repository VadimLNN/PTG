using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{
    public List<InventoryItem> itemsList = new List<InventoryItem>();
    public Dictionary<ItemTypes, int> itemDictionary;

    public UnityEvent onInventoryChange;
    public UnityEvent <string, int> updateQuests;

    public void listToDictionary()
    {
        itemDictionary = new Dictionary<ItemTypes, int>();

        foreach (var item in itemsList)
            if (itemDictionary.ContainsKey(item.type) == false)
                itemDictionary.Add(item.type, item.quant);
    }

    private void Start()
    {
        listToDictionary();
        onInventoryChange?.Invoke();
    }

    public bool getItem(ItemTypes type)
    {
        if (itemDictionary.ContainsKey(type) == false)
            return false;
        if (itemDictionary[type] < 1)
            return false;

        itemDictionary[type]--;
        onInventoryChange?.Invoke();

        return true;
    }

    public bool addItem(ItemTypes type, int amount)
    {
        if (itemDictionary.ContainsKey(type) == false)
            return false;

        itemDictionary[type] += amount;
        onInventoryChange?.Invoke();


        string itemName = Enum.GetName(typeof(ItemTypes), type);
        updateQuests?.Invoke(itemName, amount);

        return true;
    }
}
