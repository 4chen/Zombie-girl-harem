using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    [SerializeField] public static string prevScene;
    [SerializeField] public static string curScene;
    [SerializeField] Saves sv;
    public static bool dialouge;
    public static GameObject npc;

    public virtual void Start()
    {
        curScene = SceneManager.GetActiveScene().name;
    }

    public void SwitchScene(string sceneName)
    {
        prevScene = curScene;
        LoadScene(sceneName);
    }

        public static void LoadScene( string SceneNameToLoad)
    {
        PendingPreviousScene = SceneManager.GetActiveScene().name;
        SceneManager.sceneLoaded += ActivatorAndUnloader;
        SceneManager.LoadScene( SceneNameToLoad, LoadSceneMode.Additive);
    }
 
    static string PendingPreviousScene;
    static void ActivatorAndUnloader( Scene scene, LoadSceneMode mode)
    {
        SceneManager.sceneLoaded -= ActivatorAndUnloader;
        SceneManager.SetActiveScene( scene);
        SceneManager.UnloadSceneAsync( PendingPreviousScene);
    }
}
