using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using GameCreator.Variables;

public class SmeltingManager : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private string ingotName;
    [SerializeField] private int iron;
    [SerializeField] private int copper;
    [SerializeField] private int tin;
    [SerializeField] private int carbon;
    [SerializeField] private int gold;
    public void OnPointerClick(PointerEventData eventData)
    {
        StopAllCoroutines();
        StartCoroutine(SmeltingCoolDown());
    }

    IEnumerator SmeltingCoolDown()
    {
        Debug.Log((float)VariablesManager.GetGlobal("GlovesTier"));
        yield return new WaitForSeconds((float) VariablesManager.GetGlobal("GlovesTier"));
        AttemptCraft(iron, copper, tin, carbon, gold);

    }

    public void AttemptCraft(int localIron, int localCopper, int localTin, int localCarbon, int localGold)
    {
        if ((float)VariablesManager.GetGlobal("IronOre") >= localIron && (float)VariablesManager.GetGlobal("CopperOre") >= localCopper && (float)VariablesManager.GetGlobal("TinOre") >= localTin &&
            (float)VariablesManager.GetGlobal("CarbonOre") >= localCarbon && (float)VariablesManager.GetGlobal("GoldOre") >= localGold
            && (float)VariablesManager.GetGlobal(ingotName) < (float)VariablesManager.GetGlobal("BagSize")) 
        {
            Debug.Log("Crafting that ingot");
            VariablesManager.SetGlobal(ingotName, (float)VariablesManager.GetGlobal(ingotName)+1) ;
            VariablesManager.SetGlobal("IronOre", (float)VariablesManager.GetGlobal("IronOre")-localIron);
            VariablesManager.SetGlobal("CopperOre", (float)VariablesManager.GetGlobal("CopperOre") - localCopper);
            VariablesManager.SetGlobal("TinOre", (float)VariablesManager.GetGlobal("TinOre") - localTin);
            VariablesManager.SetGlobal("CarbonOre", (float)VariablesManager.GetGlobal("CarbonOre") - localCarbon);
            VariablesManager.SetGlobal("GoldOre", (float)VariablesManager.GetGlobal("GoldOre") - localGold);

        }
        else
        {
            Debug.Log("don't have enough resources to craft that");
            //put in a gamrplay visual of this.
        }
    }
}
