using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    bool playerDetect;
    public Transform doorPos;
    [SerializeField]  float width;
    [SerializeField] float height;
    [SerializeField] LayerMask whatIsPlayer;
    [SerializeField] string sceneName;
    [SerializeField] SceneSwitch sceneSwitch;

    private void Start()
    {
        sceneSwitch = FindObjectOfType<SceneSwitch>();
    }

    private void Update()
    {
        playerDetect = Physics2D.OverlapBox(doorPos.position, new Vector2(width, height), 0, whatIsPlayer);

        if(playerDetect)
        {
            sceneSwitch.SwitchScene(sceneName);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(doorPos.position, new Vector3(width, height, 1));
    }

}
