using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Sirenix.OdinInspector;
using UnityEngine.UI;

public class Board : MonoBehaviour
{
    [SerializeField] int heigh;
    [SerializeField] int width;
    [SerializeField] GameObject pref;
    public TileData[,] tileArray;
    [SerializeField] int cellSize;
    [SerializeField] GameObject startobj;
    public void Start()
    {
        tileArray = new TileData[width,heigh];
        Create();
    }

    public void Create()
    {
        for (int y = 0; y < heigh; y++)
        {
            for (int x = 0; x < width; x++)
            {
                GameObject tile = Instantiate(pref,new Vector2(x,y),Quaternion.identity,startobj.transform);
                tile.name = (x + " ," + y).ToString();

                RectTransform rectT = tile.GetComponent<RectTransform>();
                rectT.anchoredPosition = new Vector2(x * cellSize,y * cellSize); // tiles placing wierdly and not acurate to anchor

                tileArray[x,y] = tile.GetComponent<TileData>();
                tileArray[x,y].setUp(new Vector2Int(x,y), this);
            }
        }
    }
}
