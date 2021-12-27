using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inputtListener : MonoBehaviour
{
    [SerializeField] Image[] buttonImage;

    void Update()
    {
        if (Input.GetKey(KeyCode.W)){
            var bColor = buttonImage[0].color;
            bColor.a = .5f;
            buttonImage[0].color = bColor;
        }
        else{
            var bColor = buttonImage[0].color;
            bColor.a = 1;
            buttonImage[0].color = bColor;
        }

        if (Input.GetKey(KeyCode.A))
        {
            var bColor = buttonImage[1].color;
            bColor.a = .5f;
            buttonImage[1].color = bColor;
        }
        else
        {
            var bColor = buttonImage[1].color;
            bColor.a = 1;
            buttonImage[1].color = bColor;
        }

        if (Input.GetKey(KeyCode.S))
        {
            var bColor = buttonImage[2].color;
            bColor.a = .5f;
            buttonImage[2].color = bColor;
        }
        else
        {
            var bColor = buttonImage[2].color;
            bColor.a = 1;
            buttonImage[2].color = bColor;
        }

        if (Input.GetKey(KeyCode.D))
        {
            var bColor = buttonImage[3].color;
            bColor.a = .5f;
            buttonImage[3].color = bColor;
        }
        else
        {
            var bColor = buttonImage[3].color;
            bColor.a = 1;
            buttonImage[3].color = bColor;
        }

        if (Input.GetKey(KeyCode.E))
        {
            var bColor = buttonImage[4].color;
            bColor.a = .5f;
            buttonImage[4].color = bColor;
        }
        else
        {
            var bColor = buttonImage[4].color;
            bColor.a = 1;
            buttonImage[4].color = bColor;
        }
    }
}
