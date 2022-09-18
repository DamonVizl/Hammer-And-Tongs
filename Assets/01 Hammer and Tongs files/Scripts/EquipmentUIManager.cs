using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentUIManager : MonoBehaviour
{
    [SerializeField]
    private Sprite[] backGroundImages;

 
    private void OnEnable()
    {
        ActionManager.BuyItemAction += UpdateEquipmentUI;
    }
    private void OnDisable()
    {
        ActionManager.BuyItemAction -= UpdateEquipmentUI;
    }


    private void UpdateEquipmentUI(int itemType, int tier)
    {
        switch (itemType)
        {
            case 1:
                this.transform.GetChild(0).transform.GetChild(0).GetComponent<Image>().sprite = backGroundImages[tier-1];
                break;
            case 2:
                this.transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().sprite = backGroundImages[tier - 1];
                break;
            case 3:
                this.transform.GetChild(2).transform.GetChild(0).GetComponent<Image>().sprite = backGroundImages[tier - 1];
                break;
            case 4:
                this.transform.GetChild(3).transform.GetChild(0).GetComponent<Image>().sprite = backGroundImages[tier - 1];
                break;

        }
    }
}
