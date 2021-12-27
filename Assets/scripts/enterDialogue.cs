using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enterDialogue : MonoBehaviour
{
    [SerializeField] DialogueObj creatureDialogue;
    [SerializeField] GameObject E_interactKey;
    [SerializeField] Vector3 offeset;
    [SerializeField] SceneSwitch sceneSwitch;
    [SerializeField] bool hasDialogue;
    [SerializeField] bool hasCombat;
    bool canPressE;
    GameObject player;

    
    public void Start()
    {
        sceneSwitch = FindObjectOfType<SceneSwitch>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            E_interactKey.SetActive(true);
            player = collision.gameObject;
            canPressE = true;
        }
    }

    public void Update()
    {
        if(canPressE)
        {
            var pos = Camera.main.WorldToScreenPoint(this.transform.position);
            E_interactKey.GetComponent<RectTransform>().position = pos + offeset;

            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneSwitch.npc = this.gameObject;

                var GM = GameObject.Find("GameManager").GetComponent<GameManager>();
                GM.lastNpc = this.gameObject.name;
                GM.startDialogue = creatureDialogue;
                GM.sv.last_pos = GameObject.Find("Player").transform.position;
                GM.sv.last_Level = SceneManager.GetActiveScene().name;
                
                if(hasDialogue)
                enterTheDialogue("Dialogue");
                else if(hasCombat)
                enterTheDialogue("Combat");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        E_interactKey.SetActive(false);
        canPressE = false;
    }

    public void onLeaveDialogue()
    {
        string scene = GameObject.Find("GameManager").GetComponent<GameManager>().sv.last_Level;
        enterTheDialogue(scene);
    }

    public void enterTheDialogue(string scene)
    {        
        sceneSwitch.SwitchScene(scene);
    }

}
