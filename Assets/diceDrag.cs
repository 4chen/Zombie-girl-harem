using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class diceDrag : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    RectTransform rectTransform;
    Canvas canvas; 
    [SerializeField] Vector2 origen;

    public bool canDrag;
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GameObject.FindObjectOfType<Canvas>();
    }
    public void OnDrag(PointerEventData eventData)
    {
        if(canDrag)
        {
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
            GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        origen = GetComponent<RectTransform>().anchoredPosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition = origen;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    public void DestroyAnim()
    {
        Object.Destroy(GetComponent<Animator>());
        canDrag = true;
        origen = GetComponent<RectTransform>().transform.position;
    }
}
