using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using GameCreator.Variables;
using UnityEngine.UI;
using System;

public class SmeltingManager : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private string ingotName;
    [SerializeField] private int iron;
    [SerializeField] private int copper;
    [SerializeField] private int tin;
    [SerializeField] private int carbon;
    [SerializeField] private int gold;

    [SerializeField] private Slider slider;

    private float timer;
    public void OnPointerClick(PointerEventData eventData)
    {
        StopAllCoroutines();
        StartCoroutine(SmeltingCoolDown());
        //StartCoroutine(SliderStart());

    }

    private void Update()
    {
       // timer += Time.deltaTime;
    }

    IEnumerator SmeltingCoolDown()
    {
        //Debug.Log((float)VariablesManager.GetGlobal("GlovesTier"));
        timer = 0;
        if (CheckCanCraft(iron, copper, tin, carbon, gold))
        {
            while (timer < (float)VariablesManager.GetGlobal("GlovesTier"))
            {
                SliderUpdate();
                yield return null;
            }

            AttemptCraft(iron, copper, tin, carbon, gold);
            slider.value = 0;
        }
      


    }
    private void SliderUpdate()
    {
        Debug.Log("slider value" + slider.value);
        slider.value = timer/ (float)VariablesManager.GetGlobal("GlovesTier");
        timer += Time.deltaTime;
    }
    public bool CheckCanCraft(int localIron, int localCopper, int localTin, int localCarbon, int localGold)
    {
        if ((float)VariablesManager.GetGlobal("IronOre") >= localIron && (float)VariablesManager.GetGlobal("CopperOre") >= localCopper && (float)VariablesManager.GetGlobal("TinOre") >= localTin &&
            (float)VariablesManager.GetGlobal("CarbonOre") >= localCarbon && (float)VariablesManager.GetGlobal("GoldOre") >= localGold
            && (float)VariablesManager.GetGlobal(ingotName) < (float)VariablesManager.GetGlobal("BagSize"))
        {
            return true;
        }

        else return false;
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
