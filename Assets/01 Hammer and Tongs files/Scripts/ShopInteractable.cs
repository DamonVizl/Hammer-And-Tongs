using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;
using TMPro;

public class ShopInteractable : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private int itemType;  // 1 is pickaxe, 2 is hammer, 3 is gloves, 4 is bag
        
    [SerializeField]
    private int value;

    [SerializeField]
    private Transform toolTip;

    public void OnPointerClick(PointerEventData eventData)
    {
        ActionManager.BuyItemAction(itemType, value); //damon this needs work, need to check itemtype after
        this.gameObject.SetActive(false);
        switch(value)
        {
            case 1:
                this.gameObject.SetActive(false);
                toolTip.gameObject.SetActive(false);
                break;
            case 2:
                this.gameObject.SetActive(false);
                this.transform.parent.transform.parent.GetChild(0).GetChild(0).gameObject.SetActive(false);
                toolTip.gameObject.SetActive(false);
                break;
            case 3:
                this.gameObject.SetActive(false);
                this.transform.parent.transform.parent.GetChild(0).GetChild(0).gameObject.SetActive(false);
                this.transform.parent.transform.parent.GetChild(1).GetChild(0).gameObject.SetActive(false);
                toolTip.gameObject.SetActive(false);
                break;
            

        }
        
    }

}


