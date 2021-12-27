using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMenu : MonoBehaviour
{
    [SerializeField] bool menuToggle;
    [SerializeField] GameObject ui;
    [SerializeField] Vector3[] uiPos;
    Vector2 resolution;

    float halfExtend = 6;

    public void Start()
    {
        uiPos[0].x = Screen.width;
        uiPos[1].x = Screen.width - (Screen.width / halfExtend);
        resolution = new Vector2(Screen.width, Screen.height);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            menuToggle = !menuToggle;
        }

        if(!menuToggle)
        {
            ui.transform.position = Vector3.Lerp(ui.transform.position, uiPos[0], Time.deltaTime * 5);
        }
        else
        {
            ui.transform.position = Vector3.Lerp(ui.transform.position, uiPos[1], Time.deltaTime * 5);
        }

        if (resolution.x != Screen.width || resolution.y != Screen.height)
        {
            resolution.x = Screen.width;
            resolution.y = Screen.height;

            uiPos[0].x = Screen.width;
            uiPos[1].x = Screen.width - (Screen.width / halfExtend);

        }
    }

    public void onClickQuit()
    {
        Application.Quit();
    }

    public void onClickESC()
    {
        menuToggle = !menuToggle;
    }
}
