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
                if (bonus > (float)VariablesManager.GetGlobal("PickaxeTier"))
                {
                    VariablesManager.SetGlobal("PickaxeTier", bonus);
                }

                break;
            case 2: //hammer
                if (bonus > (float)VariablesManager.GetGlobal("HammerTier"))
                {
                    VariablesManager.SetGlobal("HammerTier", bonus);
                }

                break;

            case 3: //gloves
                if (bonus > (float)VariablesManager.GetGlobal("GlovesTier"))
                {
                    VariablesManager.SetGlobal("GlovesTier", bonus);
                }

                break;

            case 4: //bagsize
                if ((bonus+1)*10 > (float)VariablesManager.GetGlobal("BagSize"))
                {
                    VariablesManager.SetGlobal("BagSize", (bonus + 1) * 10);
                }   
                break; 
        }

    }
}
