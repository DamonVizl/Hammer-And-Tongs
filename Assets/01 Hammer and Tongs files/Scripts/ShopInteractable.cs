using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;
using TMPro;
using GameCreator.Variables;

public class ShopInteractable : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private int itemType;  // 1 is pickaxe, 2 is hammer, 3 is gloves, 4 is bag
        
    [SerializeField]
    private int tier;
    [SerializeField]
    private int value;

    [SerializeField]
    private Transform toolTip;

    public void OnPointerClick(PointerEventData eventData)
    {
        if((float)VariablesManager.GetGlobal("Coins")>= value)
        {
            ActionManager.BuyItemAction(itemType, tier); //damon this needs work, need to check itemtype after
            VariablesManager.SetGlobal("Coins", (float) VariablesManager.GetGlobal("Coins") - value);
            //this.gameObject.SetActive(false);
            switch(tier)
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

}


