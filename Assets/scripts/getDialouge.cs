using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class getDialouge : MonoBehaviour
{
    [SerializeField] TMP_Text textbox;
    [SerializeField] GameObject DialogueBox;    
    [SerializeField] portrait sprite;
    TypeOutText typeEffect;
    [SerializeField] GameObject nextBox;
    bool next;

    void Start()
    {
        typeEffect = GetComponent<TypeOutText>();
        closeTextBox();
    }

    public void ClickDialogue(DialogueObj dioObj)
    {
        if(dioObj.RightSide){
            sprite.image_ally.sprite = dioObj.Portrait;
            sprite.showPortrait = true;
        }
        else{
            sprite.image_encounter.sprite = dioObj.Portrait;
            sprite.showPortrait_encounter = true;
        }
   
        ShowDialouge(dioObj,dioObj.Voice);
    }

    public void ShowDialouge(DialogueObj DialogueObject,AudioClip voice)
    {
        DialogueBox.SetActive(true);      
        StartCoroutine(stepThrueDialoug(DialogueObject, voice));
    }

    public void clickNext()
    {
        next = true;       
    }

    private IEnumerator stepThrueDialoug(DialogueObj dialougueObject,AudioClip voice)
    {


        foreach (string dialogue in dialougueObject.Dialogue)
        {
            yield return typeEffect.Run(dialogue,textbox, voice);
            nextBox.SetActive(true);
            yield return new WaitUntil(() => next);
            next = false;
            nextBox.SetActive(false);
        }

        if(dialougueObject.Retreet)
        {
            if(dialougueObject.RightSide)
            {
                sprite.showPortrait = false;
            }
            else{
                sprite.showPortrait_encounter = false;
            }
        }

        closeTextBox();
    }

    public void closeTextBox()
    {

        DialogueBox.SetActive(false);
        textbox.text = string.Empty;
    }
}
