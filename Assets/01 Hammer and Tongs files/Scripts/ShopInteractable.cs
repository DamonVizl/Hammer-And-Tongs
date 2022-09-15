using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;
using TMPro;

public class ShopInteractable : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private int itemType;  // 1 is pickaxe, 2 is hammer, 3 is gloves, 4 is bag
        
    [SerializeField]
    private int value;

    [SerializeField]
    private Transform toolTip;

    private TextMeshProUGUI descriptionText;
    [SerializeField]
    private string ItemDescription;

    [SerializeField]
    private int itemCost;

    private TextMeshProUGUI itemCostText;

    private void Start()
    {
        Debug.Log(toolTip.childCount);
        itemCostText = toolTip.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        descriptionText= toolTip.GetChild(1).GetComponent<TextMeshProUGUI>();
    }

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

    public void OnPointerEnter(PointerEventData eventData)
    {
        //this will bring up the tool tip and update the text to tell us the cost. 
        Debug.Log("Entered the shop Icon");
        toolTip.gameObject.SetActive(true);
        toolTip.GetComponent<RectTransform>().anchoredPosition = this.transform.parent.GetComponent<RectTransform>().anchoredPosition;//this.gameObject.transform.GetComponent<RectTransform>().anchoredPosition;
        descriptionText.text = (string)ItemDescription;
        itemCostText.text = (string)itemCost.ToString();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Exited the shop Icon");
        //this will close the tool tip and clear the text
        toolTip.gameObject.SetActive(false);
    }
}


