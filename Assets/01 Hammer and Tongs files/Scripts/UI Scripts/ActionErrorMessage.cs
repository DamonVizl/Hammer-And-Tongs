// ##HEADER##
namespace GameCreator.Core
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.Events;
	using TMPro;
	using GameCreator.Core.Hooks;

	[AddComponentMenu("")]
	public class ActionErrorMessage : IAction
	{
		[SerializeField] string errorMessage;
		[SerializeField] GameObject errorMessageCanvas;
		RectTransform rectTrans;



		private float timeForErrorMessage = 1.5f; //this is not seconds

        private void Start()
        {
			rectTrans = errorMessageCanvas.GetComponent<RectTransform>();
			rectTrans.localScale = new Vector3(0.02f, 0.02f, 0.02f);
		}
        public override bool InstantExecute(GameObject target, IAction[] actions, int index)
        {
			//Debug.Log(this.example);
			StopAllCoroutines();
			rectTrans.localScale = new Vector3(0.02f, 0.02f, 0.02f);
			StartCoroutine(DisplayErrorMessage());
			
            return true;
        }

		//displays the error message for timeForErrorMessage seconds
		IEnumerator DisplayErrorMessage()
        {
			StopCoroutine(FadeAwayErrorMessage());
			errorMessageCanvas.gameObject.transform.GetChild(0).gameObject.SetActive(true);
			errorMessageCanvas.GetComponentInChildren<TextMeshProUGUI>().text = errorMessage;
			errorMessageCanvas.transform.position = new Vector3(HookPlayer.Instance.transform.position.x, HookPlayer.Instance.transform.position.y+ 2f, HookPlayer.Instance.transform.position.z);
			errorMessageCanvas.transform.rotation = HookCamera.Instance.transform.rotation;
			yield return new WaitForSeconds(timeForErrorMessage);
			StartCoroutine(FadeAwayErrorMessage());
		}
		//shrinks the error mewsage after its done. 
		IEnumerator FadeAwayErrorMessage()
        {
			float i = 0;
			while( i <1)
			{
				rectTrans.localScale = rectTrans.localScale - rectTrans.localScale / 10f;
				yield return new WaitForSeconds(0.1f);
				i = i + 0.1f;
            }
			
			errorMessageCanvas.GetComponentInChildren<TextMeshProUGUI>().text = null;
			rectTrans.localScale = new Vector3(0.02f, 0.02f, 0.02f);
			errorMessageCanvas.gameObject.transform.GetChild(0).gameObject.SetActive(false);
		}

		#if UNITY_EDITOR
        public static new string NAME = "Custom/ActionErrorMessage";
		#endif
	}
}

