using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Dialogue")]

public class DialogueObj : ScriptableObject
{
    [SerializeField] [TextArea] private string[] dialogue;
    [SerializeField] Sprite portrait;
    [SerializeField] AudioClip voice;
    [SerializeField] bool rightSide;
    [SerializeField] bool retreet;

    public bool Retreet => retreet;
    public bool RightSide => rightSide;
    public AudioClip Voice => voice;
    public string[] Dialogue => dialogue;
    public Sprite Portrait => portrait;
}
