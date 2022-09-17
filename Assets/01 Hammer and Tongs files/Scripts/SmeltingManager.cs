using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using GameCreator.Variables;
using UnityEngine.UI;
using System;
using System.Linq;

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
    //forges the max amount of ingots based off the lowest number when divided. 
    public void ForgeMax()
    {
         List<float> dividedList = new List<float>();

        if (iron != 0) { float i = Mathf.FloorToInt((float)VariablesManager.GetGlobal("IronOre") / iron); dividedList.Add(i); }
        if (copper != 0) { float c = Mathf.FloorToInt((float)VariablesManager.GetGlobal("CopperOre") / copper); dividedList.Add(c); }
        if (tin != 0) { float t = Mathf.FloorToInt((float)VariablesManager.GetGlobal("TinOre") / tin); dividedList.Add(t); }
        if (carbon != 0) { float ca = Mathf.FloorToInt((float)VariablesManager.GetGlobal("CarbonOre") / carbon); dividedList.Add(ca); }
        if (gold != 0) { float g = Mathf.FloorToInt((float)VariablesManager.GetGlobal("GoldOre") / gold); dividedList.Add(g); }

         dividedList.Min();
        Debug.Log(dividedList.Min());

        StopAllCoroutines();
        StartCoroutine( MultipleSmelting((int)dividedList.Min()));
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
    //this here function loops through loopTimes doing the smeltingCoolDOwn coroutine that many times
    IEnumerator MultipleSmelting(int loopTimes)
    {
        for (int i = 0; i<loopTimes; i++)
        {
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
        
       // yield return null;
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
