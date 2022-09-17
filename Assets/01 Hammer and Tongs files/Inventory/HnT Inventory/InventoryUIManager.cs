using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIManager : MonoBehaviour
{
    private void OnEnable()
    {
        ActionManager.UpdateInventoryUI += UpdateUI;
    }
    private void OnDisable()
    {
        ActionManager.UpdateInventoryUI -= UpdateUI;
    }



    private void UpdateUI(int slot, Item item)
    {
        this.gameObject.transform.GetChild(slot).GetChild(0).GetComponent<Image>().sprite = item.GetIcon();
    }
}
