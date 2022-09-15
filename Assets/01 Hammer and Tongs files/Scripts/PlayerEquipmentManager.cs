using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameCreator.Variables;

public class PlayerEquipmentManager : MonoBehaviour
{


    private void OnEnable()
    {
        ActionManager.BuyItemAction += UpdateEquipment;
    }
    private void OnDisable()
    {
        ActionManager.BuyItemAction -= UpdateEquipment;
    }


    private void UpdateEquipment(int slotNum, int bonus)
    {
        Debug.Log("Slot num: " + slotNum + " adding bonus: " + bonus);

        switch (slotNum)
        {
            case 1: //pickaxe
                    VariablesManager.SetGlobal("PickaxeTier", bonus);
                break;
            case 2: //hammer
                    VariablesManager.SetGlobal("HammerTier", bonus);
                break;
            case 3: //gloves
                       VariablesManager.SetGlobal("GlovesTier", (float) 1/bonus);
                break;
            case 4: //bagsize
                    VariablesManager.SetGlobal("BagSize", (bonus + 1) * 10);   
                break; 
        }

    }
}
