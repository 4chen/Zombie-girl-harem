using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class testLoadSave : MonoBehaviour
{
    [SerializeField] Saves sv;

    public void onClickSave()
    {
        sv.last_pos = GameObject.Find("Player").GetComponent<Transform>().position; // save player possision

        string scn = SceneManager.GetActiveScene().name; // save player room
        sv.last_Level = scn;

        GameObject.Find("GameManager").GetComponent<GameManager>().UpdateInfo();
        
        SaveManager.Save(sv); // save all data to saveFile

        sv = SaveManager.Load();
    }

    public void onClickLoade()
    {
        sv = SaveManager.Load();

        if (sv.last_Level != SceneManager.GetActiveScene().name)
            SceneManager.LoadScene(sv.last_Level);
    }
}
