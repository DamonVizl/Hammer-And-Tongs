using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class ActionManager : MonoBehaviour
{
    public static Action<int, int> SellItemAction; //first int slotNum, second int value
    public static Action<int, int> BuyItemAction;
    public static Action<int> StopOtherSmeltingAction;

    public static Action<Item> AddItemAction;
    public static Action<int, Item> UpdateInventoryUIAction;
    

}
