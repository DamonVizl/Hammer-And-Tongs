using GameCreator.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryUISlot : MonoBehaviour, IDropHandler
{
    [SerializeField]
    private int slotNum;
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Dropped");
        if(eventData.pointerDrag != null)
        {
            //Vector2 storePosition = GetComponent<RectTransform>().anchoredPosition;
            //storePosition = new Vector2(10-storePosition.x , 10+ storePosition.y); // this little line of fckery is to move the item back into the right spot relative to the holder
            if(this.CompareTag("UIInventorySlot")) //this if statement checks to see if the slot im dropping it in is an inventory slot and parents it to that slot if it is.
            {
                //this line here swaps the new spot into the old parent. 
                Transform tempItem;
                tempItem = GetComponent<Transform>().GetChild(0);
                tempItem.SetParent(eventData.pointerDrag.transform.parent);
                tempItem.GetComponent<RectTransform>().anchoredPosition = new Vector2(10, -10);
                //passes the inventory the old slot via an event
                EventDispatchManager.Instance.Dispatch("OnInventoryUIUpdatedOldSlot", eventData.pointerDrag.transform.parent.gameObject);

                eventData.pointerDrag.transform.SetParent(GetComponent<Transform>());
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = new Vector2(10, -10);

                //passes the inventory the new slot via an event
                
                EventDispatchManager.Instance.Dispatch("OnInventoryUIUpdatedNewSlot", this.gameObject);

                //i want some code here that will swap the items. 

            }
            else
            {
                eventData.pointerDrag.transform.SetParent(eventData.pointerDrag.transform.parent); //this doesn't work right now. im trying to get it to snap back into its old slot if its not dropped on the inventory slot. 
            }
            
           

           
        }
    }

    public int GetSlotNum()
    {
        return slotNum;
    }


}
