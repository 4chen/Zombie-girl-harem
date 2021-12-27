using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class world : SceneSwitch
{
    [SerializeField] Transform player;
    [SerializeField] float x;
    [SerializeField] float y;
    [SerializeField] string prev;


    public override void Start()
    {
        base.Start();

        if(prevScene == prev)
        {
            player.position = new Vector2(x, y);
            var npc = GameObject.Find("GameManager").GetComponent<GameManager>();

            if(npc.lastNpc != "")
            {
                player.position = npc.sv.last_pos;
                GameObject.Find("GameManager").GetComponent<GameManager>().lastNpc = "";
            }
        }
    }
}
