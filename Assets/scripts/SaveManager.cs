using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveManager : MonoBehaviour
{
    public static string directory = "/SaveData/";
    public static string fileName = "Save.txt";


    public static void Save(Saves saveData)
    {
        string dir = Application.persistentDataPath + directory;

        if (!Directory.Exists(dir))
            Directory.CreateDirectory(dir);

        string json = JsonUtility.ToJson(saveData);
        File.WriteAllText(dir + fileName, json);
    }

    public static Saves Load()
    {       
        string fullPath = Application.persistentDataPath + directory + fileName;
        Saves sv = new Saves();

        if(File.Exists(fullPath))
        {
            string json = File.ReadAllText(fullPath);
            sv = JsonUtility.FromJson<Saves>(json);
        }

        return sv;
    }
}
