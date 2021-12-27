using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DiceAllocation : MonoBehaviour, IDropHandler
{
    [SerializeField] TMPro.TMP_Text statValue;
    public bool x1, x2, x3, x4, x5;

    public void OnDrop(PointerEventData data)
    {
        if(data.pointerDrag != null)
        {
            GetComponent<Image>().sprite = data.pointerDrag.GetComponent<Image>().sprite;
            Object.Destroy(data.pointerDrag.gameObject);
            GetComponent<Image>().raycastTarget = false;
            string str = data.pointerDrag.GetComponent<Image>().sprite.name;

            int par = int.Parse(str.Substring(str.Length - 1));

            
            if(x1){
                statValue.text = str.Substring(str.Length - 1) + " x1 = " + (par * 1).ToString();
            }
                        
            if(x2){
                statValue.text = str.Substring(str.Length - 1) + " x2 = " + (par * 2).ToString();
            }
                        
            if(x3){
                statValue.text = str.Substring(str.Length - 1) + " x3 = " + (par * 3).ToString();
            }
                        
            if(x4){
                statValue.text = str.Substring(str.Length - 1) + " x4 = " + (par * 4).ToString();
            }
                        
            if(x5){
                statValue.text = str.Substring(str.Length - 1) + " x5 = " + (par * 5).ToString();
            }

        }
    }
}
