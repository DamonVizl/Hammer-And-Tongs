using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIManager : MonoBehaviour
{
    [SerializeField]
    private Sprite defaultSprite;
    private void OnEnable()
    {
        ActionManager.UpdateInventoryUI += UpdateUI;
        ActionManager.SellItemAction += RemoveFromUI;
    }
    private void OnDisable()
    {
        ActionManager.UpdateInventoryUI -= UpdateUI;
        ActionManager.SellItemAction -= RemoveFromUI;
    }



    private void UpdateUI(int slot, Item item)
    {
        this.gameObject.transform.GetChild(slot).GetChild(0).GetComponent<Image>().sprite = item.GetIcon();
    }
    private void RemoveFromUI(int slot, int value)
    {
        this.gameObject.transform.GetChild(slot).GetChild(0).GetComponent<Image>().sprite = defaultSprite;
    }
}
