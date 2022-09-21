using GameCreator.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using GameCreator.Variables;

public class InventoryUISlot : MonoBehaviour, IPointerClickHandler 
{
    [SerializeField]
    private int slotNum;
    [SerializeField]
    Inventory inv;

    public int GetSlotNum()
    {
        return slotNum;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //this could have fired an event.  ah well.

        if( (bool)(VariablesManager.GetGlobal("isShopOpen")))
        {
            inv.SellItem(slotNum);
        }
    }
}
