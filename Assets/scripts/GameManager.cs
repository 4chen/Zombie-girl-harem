using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class GameManager : MonoBehaviour
{
    public string lastNpc;
    public static GameManager Instance = null;
    public DialogueObj startDialogue;
    public Vector2 playerPos;
    public Saves sv;
    public bool cameFromMenu;

    public void Start()
    {
        if (!Instance)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpdateInfo()
    {
        sv = SaveManager.Load();
    }
}
