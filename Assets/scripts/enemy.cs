using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    [SerializeField] DialogueObj dioObj;
    [SerializeField] getDialouge dilogueSys; 

    private void Awake()
    {
        dioObj = GameObject.Find("GameManager").GetComponent<GameManager>().startDialogue;
        StartCoroutine(StartEncounterDialogue());
    }

    IEnumerator StartEncounterDialogue()
    {
        yield return new WaitForSeconds(.1f);
        dilogueSys.ClickDialogue(dioObj);
    }

}
