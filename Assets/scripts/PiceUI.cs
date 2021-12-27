using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PiceUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IEndDragHandler, IBeginDragHandler, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] GameObject gui;
    GameObject insGui;
    Canvas canvas;
    [SerializeField] PiceStats PlayerPiceStats;
    RectTransform rectTransform;
    bool draging;
    CanvasGroup canvasGroup;
    void Start()
    {
        canvas = GameObject.FindObjectOfType<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {   
        if(!draging)    
        {
            insGui = Instantiate(gui,transform.position,Quaternion.identity,canvas.transform);
            insGui.transform.position = insGui.transform.position + new Vector3(200,0,0);

            insGui.GetComponent<SetUpPiceStats>().so_piceName = PlayerPiceStats.piceName;
            insGui.GetComponent<SetUpPiceStats>().so_move = PlayerPiceStats.movement;
            insGui.GetComponent<SetUpPiceStats>().so_atk = PlayerPiceStats.attack;
            insGui.GetComponent<SetUpPiceStats>().so_def = PlayerPiceStats.defence;
            insGui.GetComponent<SetUpPiceStats>().so_abil = PlayerPiceStats.ability;
        }

    }
    public void OnPointerExit(PointerEventData eventData)
    {
        Object.Destroy(insGui);
    }
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        draging = true;
        Object.Destroy(insGui);
    }
    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        draging = false;
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = .6f;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1;
    }

}