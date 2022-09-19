using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using GameCreator.Variables;
using UnityEngine.UI;
using System;
using System.Linq;

public class SmithingManager : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Item thisItem;
    [SerializeField] private Inventory inv;
    [SerializeField] private int itemTier;
    [SerializeField] private int ironIngot;
    [SerializeField] private int bronzeIngot;
    [SerializeField] private int steelIngot;
    [SerializeField] private int goldIngot;

    public void OnPointerClick(PointerEventData eventData)
    {
        AttemptCraft(ironIngot, bronzeIngot, steelIngot, goldIngot);
    }

    public void AttemptCraft(int localIron, int localBronze, int localSteel, int localGold)
    {
        if ((float)VariablesManager.GetGlobal("IronIngot") >= localIron && (float)VariablesManager.GetGlobal("BronzeIngot") >= localBronze && (float)VariablesManager.GetGlobal("SteelIngot") >= localSteel &&
              (float)VariablesManager.GetGlobal("GoldIngot") >= localGold && itemTier <= (float) VariablesManager.GetGlobal("HammerTier"))
            //check to see if inventory is full
        {
            if (inv.CheckIfFull())
            {
                return;
            }
            else
            {
                Debug.Log("Crafting that ingot");
                // VariablesManager.SetGlobal(ingotName, (float)VariablesManager.GetGlobal(ingotName) + 1);
                VariablesManager.SetGlobal("IronIngot", (float)VariablesManager.GetGlobal("IronIngot") - localIron);
                VariablesManager.SetGlobal("BronzeIngot", (float)VariablesManager.GetGlobal("BronzeIngot") - localBronze);
                VariablesManager.SetGlobal("SteelIngot", (float)VariablesManager.GetGlobal("SteelIngot") - localSteel);
                VariablesManager.SetGlobal("GoldIngot", (float)VariablesManager.GetGlobal("GoldIngot") - localGold);

                ActionManager.AddItem(thisItem);
            }

        }
        else
        {
            Debug.Log("don't have enough resources to craft that");
            //put in a gamrplay visual of this.
        }
    }
}
