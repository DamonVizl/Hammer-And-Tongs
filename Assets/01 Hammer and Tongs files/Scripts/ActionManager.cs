using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class ActionManager : MonoBehaviour
{
    public static Action<int, int> SellItemAction;
    public static Action<int, int> BuyItemAction;

    public static Action<Item> AddItem;
    public static Action<int, Item> UpdateInventoryUI;

}
