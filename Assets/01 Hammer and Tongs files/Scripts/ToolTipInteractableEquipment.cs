using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;
using TMPro;

public class ToolTipInteractableEquipment : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    private TextMeshProUGUI descriptionText;
    [SerializeField]
    private string ItemDescription;

    [SerializeField]
    private Transform toolTip;


    private void Start()
    {
       // itemCostText = toolTip.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        descriptionText = toolTip.GetChild(0).GetComponent<TextMeshProUGUI>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        //this will bring up the tool tip and update the text to tell us the cost. 
        toolTip.gameObject.SetActive(true);
        toolTip.GetComponent<RectTransform>().anchoredPosition = new Vector2(this.transform.parent.GetComponent<RectTransform>().anchoredPosition.x, this.transform.parent.GetComponent<RectTransform>().anchoredPosition.y-120) ;//this.gameObject.transform.GetComponent<RectTransform>().anchoredPosition;
        descriptionText.text = (string)ItemDescription;
       // itemCostText.text = (string)itemCost.ToString();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //this will close the tool tip and clear the text
        toolTip.gameObject.SetActive(false);
    }
}
