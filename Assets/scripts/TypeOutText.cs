using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TypeOutText : MonoBehaviour
{
    [SerializeField] public float typeSpeed = 45f;
    [SerializeField] AudioSource vo;

    public Coroutine Run(string textToType, TMP_Text textBox, AudioClip voice)
    { 
        return StartCoroutine(TypeText(textToType,textBox, voice));
    }

    IEnumerator TypeText(string text, TMP_Text textBox, AudioClip voice)
    {
        textBox.text = string.Empty;

        int charIndex = 0;

        for (int i = 0; i < text.Length; i++)
        {
            yield return new WaitForSeconds(Time.deltaTime);

            charIndex = Mathf.Clamp(i, 0, text.Length);
            textBox.text = text.Substring(0, charIndex+1);

            if (text.Substring(charIndex, 1).ToString() != " ")
            {
                vo.PlayOneShot(voice, 0.2f);
            }

            if(Input.GetMouseButton(0))
            {
                i = text.Length;
                textBox.text = text;
            }
            yield return null;
        }
    }

}
