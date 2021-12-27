using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class startMenu : MonoBehaviour
{
    [SerializeField] GameObject contineButton;
    [SerializeField] Saves sv;

    void Start()
    {
        if (File.Exists(Application.persistentDataPath + "/SaveData/Save.txt"))
        {
            contineButton.GetComponent<Button>().enabled = true;
            Color vColor = contineButton.GetComponent<Image>().color;
            vColor.a = 1;
            contineButton.GetComponent<Image>().color = vColor;
        }

        GameObject.Find("GameManager").GetComponent<GameManager>().cameFromMenu = true;
    }

    public void onClickNewGame()
    {
        if (File.Exists(Application.persistentDataPath + "/SaveData/Save.txt"))
        {
            //r u sure ? u have a save do you want to remove it ? 
            File.Delete(Application.persistentDataPath + "/SaveData/Save.txt");

        }

        SaveManager.Save(sv);
        sv.last_Level = "Overworld_cave_1";
        SceneManager.LoadScene(sv.last_Level);
    }

    public void onClickContine()
    {
        sv = SaveManager.Load();
        GameObject.Find("GameManager").GetComponent<GameManager>().UpdateInfo();
        SceneManager.LoadScene(sv.last_Level);
    }

    public void onClickDelete()
    {
        if (File.Exists(Application.persistentDataPath + "/SaveData/Save.txt"))
        {
            File.Delete(Application.persistentDataPath + "/SaveData/Save.txt");
        }

        contineButton.GetComponent<Button>().enabled = false;
        Color vColor = contineButton.GetComponent<Image>().color;
        vColor.a = .5f;
        contineButton.GetComponent<Image>().color = vColor;

    }
}
