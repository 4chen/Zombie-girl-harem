using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class portrait : MonoBehaviour
{
    public bool showPortrait;
    public bool showPortrait_encounter;
    [SerializeField] RectTransform RT_ally;
    [SerializeField] RectTransform RT_encounter;
    [SerializeField] RectTransform[] RT_possissions_ally;
    [SerializeField] RectTransform[] RT_possissions_encounter;
    public Image image_ally;
    public Image image_encounter;

    public void Update()
    {
        switch (showPortrait)
        {
            case (true):
                RT_ally.transform.position = Vector3.Lerp(RT_ally.transform.position, RT_possissions_ally[0].transform.position, Time.deltaTime * 5);
                break;

            case (false):
                RT_ally.transform.position = Vector3.Lerp(RT_ally.transform.position, RT_possissions_ally[1].transform.position, Time.deltaTime * 5);
                break;
        }

        switch (showPortrait_encounter)
        {
            case (true):
                RT_encounter.transform.position = Vector3.Lerp(RT_encounter.transform.position, RT_possissions_encounter[0].transform.position, Time.deltaTime * 5);
                break;

            case (false):
                RT_encounter.transform.position = Vector3.Lerp(RT_encounter.transform.position, RT_possissions_encounter[1].transform.position, Time.deltaTime * 5);
                break;
        }
    }
}
