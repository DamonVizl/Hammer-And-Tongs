using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class ShopInteractable : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private int itemType;  // 1 is pickaxe, 2 is hammer, 3 is gloves, 4 is bag
        
    [SerializeField]
    private int value;



    public void OnPointerClick(PointerEventData eventData)
    {
        ActionManager.BuyItemAction(itemType, value); //damon this needs work, need to check itemtype after
        this.gameObject.SetActive(false);
        
    }



}


