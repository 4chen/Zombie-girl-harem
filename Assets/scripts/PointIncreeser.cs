using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointIncreeser : MonoBehaviour
{
    int pointValue;
    public int pointIncreesed;
    [SerializeField] TMP_Text enemyPointText;
    [SerializeField] TMP_Text pointText;
    [SerializeField] bool turnText;
    Vector3 origenPos;

    public void Start()
    {
        origenPos = pointText.GetComponent<RectTransform>().localScale;
        enemyPointText.text = Random.Range(0,36).ToString();
    }
    public void Update()
    {
        if(turnText)
        {   

            pointText.GetComponent<RectTransform>().localScale = Vector3.Lerp(pointText.GetComponent<RectTransform>().localScale,origenPos,Time.deltaTime * 10); 
            
            if(pointText.GetComponent<RectTransform>().localScale == origenPos)
            {
                turnText = false;
            }
        }
    }
    IEnumerator IncreesPoints()
    {                
        if(pointValue < pointIncreesed)
        {
            pointText.GetComponent<RectTransform>().localScale = Vector3.one * 2;
            pointValue++;
        }
            else if(pointValue > pointIncreesed)
        {
            pointText.GetComponent<RectTransform>().localScale = Vector3.one * 2;
            pointValue--;
        }

        turnText = true;
        yield return new WaitForSeconds(.1f);

        if(pointValue != pointIncreesed)
        {
            StartCoroutine(IncreesPoints());
        }
        pointText.text = pointValue.ToString();
        
    }
}
