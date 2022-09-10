using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class ItemData : MonoBehaviour
{
    // Properties
    
    [SerializeField]
    string itemName;

    [SerializeField]
    protected int itemLevel;

    [SerializeField]
    Sprite itemSprite;

    [SerializeField]
    int cost;

    enum Rarity
    {
        white,
        green,
        blue,
        yellow
    }
    [SerializeField]
    Rarity itemRarity = Rarity.white;




    //Functions
    public Sprite GetSprite()
    {
        return itemSprite;
    }
}
