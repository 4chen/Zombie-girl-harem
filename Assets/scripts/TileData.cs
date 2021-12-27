using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TileData : MonoBehaviour, IDropHandler
{
    [HideInInspector] public Vector2Int mboardPos;
    [HideInInspector] public Board mboard = null;
    [HideInInspector] public RectTransform mRectT = null;
    public bool ocupide;

    public void setUp(Vector2Int boardPos, Board board)
    {
        mboardPos = boardPos;
        mboard = board;

        mRectT = GetComponent<RectTransform>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        if(eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;// - new Vector2(100,100);
        }
    }
}
