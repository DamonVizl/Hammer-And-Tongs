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
    private Item[] items;
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

    private void OnEnable()
    {
        ActionManager.AddItem += AddItemToInventory;
        
    }
    private void OnDisable()
    {
        ActionManager.AddItem -= AddItemToInventory;
        
    }
    public void Start()
    {
        items = new Item[InventorySize];
        sprites = new Image[InventorySize];
        EventDispatchManager.Instance.Subscribe(this.eventName, this.OnReceiveEvent);
        //this event is called whenever an item is swapped. its in the inventoryUISlot.cs class
        //EventDispatchManager.Instance.Subscribe("OnInventoryUIUpdatedOldSlot", this.ItemMovedFrom);
        //EventDispatchManager.Instance.Subscribe("OnInventoryUIUpdatedNewSlot", this.ItemMovedTo);

  /*      //match the sprites array from the inventory slots
        for (int i = 0; i<InventorySize; i++) //should throw a catch in here for if the array is too big
        {
            sprites[i] = InventoryUI.transform.GetChild(i).GetChild(0).GetComponent<Image>();
        }*/
        
    }

    private void OnReceiveEvent(GameObject invoker)
    {
        this.storeInvoker.Set(invoker, invoker);
        //this.ExecuteTrigger(invoker);
        Debug.Log("I have picked up a: " + invoker.name);
       // this.AddItemToInventory(invoker);
       
    }
    public void AddItemToInventory(Item item)
    {
        currIndex = 0; // reset the array back to 0 to fill any empty slots
        Debug.Log("Do i get into the add item function from the action push");
        for(int i = 0; i<InventorySize; i++)
        {
            //Debug.Log("at slot, is: " + currIndex + items[i].name);
            if(!items[i])
            {
                currIndex = i;
                Debug.Log("current index (the first free inventory slot) is:" + currIndex);
                items[currIndex] = item;
                ActionManager.UpdateInventoryUI(currIndex, item);
                return;
            }
        }
    }

    public bool CheckIfFull()
    {
        currIndex = 0;
        for (int i = 0; i < InventorySize; i++)
        {
            //Debug.Log("at slot, is: " + currIndex + items[i].name);
            if (!items[i])
            {
                return false;
            }
        }
        Debug.Log("Inventory full");
        return true;
    }
/*    public void AddItemToInventory(GameObject item)
    {
        if (currIndex < InventorySize)
        {
            items[currIndex] = item.GetComponent<ItemData>();
            sprites[currIndex].sprite = item.GetComponent<ItemData>().GetSprite();
            currIndex++;
        }
    }*/
/*    public void ItemMovedFrom(GameObject item)
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
    }*/
    public void DropItem(GameObject item)
    {
        
    }

    public void SellItem(int slot)
    {
        if(items[slot])
        {
            ActionManager.SellItemAction(slot, items[slot].GetItemValue());
            VariablesManager.SetGlobal("Coins", (float)VariablesManager.GetGlobal("Coins") + items[slot].GetItemValue());
            items[slot] = null;
        }
    }

}
