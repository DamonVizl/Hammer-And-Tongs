using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameCreator.Core.Hooks;
using TMPro;

public class ErrorToolTip : MonoBehaviour
{
    RectTransform rectTrans;
	private float timeForErrorMessage = 1.5f; //this is not seconds
    string errorMessage; 
    private void Start()
    {
        rectTrans = this.GetComponent<RectTransform>();
        rectTrans.localScale = new Vector3(0.02f, 0.02f, 0.02f);
    }

    private void OnEnable()
    {
        ActionManager.DisplayErrorMessage += DisplayError;
    }
    private void OnDisable()
    {
        ActionManager.DisplayErrorMessage -= DisplayError;
    }

    private void DisplayError(string message)
    {
        //Debug.Log(this.example);
        errorMessage = message;
        StopAllCoroutines();
        rectTrans.localScale = new Vector3(0.02f, 0.02f, 0.02f);
        StartCoroutine(DisplayErrorMessage());
    }

    IEnumerator DisplayErrorMessage()
    {
        this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        this.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = errorMessage;
        this.gameObject.transform.position = new Vector3(HookPlayer.Instance.transform.position.x, HookPlayer.Instance.transform.position.y + 2f, HookPlayer.Instance.transform.position.z);
        this.gameObject.transform.rotation = HookCamera.Instance.transform.rotation;
        yield return new WaitForSeconds(timeForErrorMessage);
        StartCoroutine(FadeAwayErrorMessage());
        
    }

    IEnumerator FadeAwayErrorMessage()
    {
        float i = 0;
        while (i < 1)
        {
            rectTrans.localScale = rectTrans.localScale - rectTrans.localScale / 10f;
            yield return new WaitForSeconds(0.1f);
            i = i + 0.1f;
        }
        this.GetComponentInChildren<TextMeshProUGUI>().text = null;
        rectTrans.localScale = new Vector3(0.02f, 0.02f, 0.02f);
        this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }
}
