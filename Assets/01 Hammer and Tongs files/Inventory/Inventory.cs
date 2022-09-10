using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameCreator.Core;
using GameCreator.Variables;

//the inventory manages the array of inventory items. it interfaces with the inventory UI and the inventory UI slots and Inventory UI items in turn. 
public class Inventory : MonoBehaviour
{
    //properties
    private int InventorySize = 20;

    //array of the items in the inventory
    [SerializeField]
    private ItemData[] items;
    //currIndex is the current spot in the inventory
    private int currIndex = 0;

    [SerializeField]
    GameObject InventoryUI;
    //the array of images in the UIInvnetory
    [SerializeField]
    private Image[] sprites;

    //these two temp holders hold the swappedFrom and swappedTo slots from when they are swapped over.
    int swappedFrom;
    int swappedTo;


    //variables for the GC event management
    [EventName] public string eventName = "my-event";
    [Space]
    public VariableProperty storeInvoker = new VariableProperty();


    public void Start()
    {
        items = new ItemData[InventorySize];
        sprites = new Image[InventorySize];
        EventDispatchManager.Instance.Subscribe(this.eventName, this.OnReceiveEvent);
        //this event is called whenever an item is swapped. its in the inventoryUISlot.cs class
        EventDispatchManager.Instance.Subscribe("OnInventoryUIUpdatedOldSlot", this.ItemMovedFrom);
        EventDispatchManager.Instance.Subscribe("OnInventoryUIUpdatedNewSlot", this.ItemMovedTo);

        //match the sprites array from the inventory slots
        for (int i = 0; i<InventorySize; i++) //should throw a catch in here for if the array is too big
        {
            sprites[i] = InventoryUI.transform.GetChild(i).GetChild(0).GetComponent<Image>();
        }
        
    }

    private void OnReceiveEvent(GameObject invoker)
    {
        this.storeInvoker.Set(invoker, invoker);
        //this.ExecuteTrigger(invoker);
        Debug.Log("I have picked up a: " + invoker.name);
        this.AddItemToInventory(invoker);
       
    }

    public void AddItemToInventory(GameObject item)
    {
        if (currIndex < InventorySize)
        {
            items[currIndex] = item.GetComponent<ItemData>();
            sprites[currIndex].sprite = item.GetComponent<ItemData>().GetSprite();
            currIndex++;
        }
    }
    public void ItemMovedFrom(GameObject item)
    {
        Debug.Log("an item has been swapped from: " + item.name);
        swappedFrom = item.GetComponent<InventoryUISlot>().GetSlotNum();
    }
    public void ItemMovedTo(GameObject item)
    {
        Debug.Log("an item has been swapped to: " + item.name);
        swappedTo = item.GetComponent<InventoryUISlot>().GetSlotNum();
        SwapItemsInInventory();
    }
  

    public void SwapItemsInInventory()
    {
        ItemData temp = items[swappedTo];
        items[swappedTo] = items[swappedFrom];
        items[swappedFrom] = temp;
    }
    public void DropItem(GameObject item)
    {
        
    }

    public void SellItem(GameObject item)
    {

    }

}
