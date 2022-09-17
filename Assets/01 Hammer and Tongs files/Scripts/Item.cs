using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    [SerializeField] private string itemName;
    public string GetItemName()
    {
        return this.itemName;
    }
    [SerializeField] private int itemValue;
    public int GetItemValue()
    {
        return this.itemValue;
    }

    [SerializeField] private Sprite icon;
    public Sprite GetIcon()
    {
        return icon;
    }
}
