using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryUIItem : MonoBehaviour, IPointerDownHandler, IDragHandler, IEndDragHandler, IBeginDragHandler, IPointerClickHandler

{
    private RectTransform rectTrans;
    private CanvasGroup canvasGroup;
    [SerializeField]
    private int slotNum;
    [SerializeField]
    private Canvas canvas;

    [SerializeField]
    Sprite defaultSprite;

    private void OnEnable()
    {
        ActionManager.SellItemAction += SellItem;
    }
    private void OnDisable()
    {
        ActionManager.SellItemAction -= SellItem;
    }
    private void Awake()
    {
        rectTrans = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("OnBeginDrag");
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0.6f;
    }

    public void OnDrag(PointerEventData eventData)
    {
       // Debug.Log("OnDrag");
        rectTrans.anchoredPosition += eventData.delta/canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //if(eventData.pointerDrag)
        //Debug.Log("OnEndDrag");
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1;
        //if(eventData.pointerDrag.transform)
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log("OnPointerDown");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button==PointerEventData.InputButton.Right)//include && shop window open bool
        {
            ActionManager.SellItemAction(1, 3);
        }
    }

    private void SellItem(int i, int j)
    {
        Debug.Log(i +" and " + j);
    }

}
