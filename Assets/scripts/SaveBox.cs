using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveBox : MonoBehaviour
{
    [SerializeField] GameObject E_interactKey;
    [SerializeField] Vector3 offeset;
    bool canPressE;
    GameObject player;
    [SerializeField] Saves sv;
    [SerializeField] Sprite[] icons;
    [SerializeField] Image image;
    [SerializeField] ParticleSystem ParSys;

    public void Start()
    {
        if(GameObject.Find("GameManager").GetComponent<GameManager>().cameFromMenu)
        {
            sv = SaveManager.Load();
            GameObject.Find("Player").transform.position = sv.last_pos;
            GameObject.Find("GameManager").GetComponent<GameManager>().cameFromMenu = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            E_interactKey.SetActive(true);
            player = collision.gameObject;
            canPressE = true;
        }
    }

    public void Update()
    {
        if (canPressE)
        {
            var pos = Camera.main.WorldToScreenPoint(this.transform.position);
            E_interactKey.GetComponent<RectTransform>().position = pos + offeset;

            if (Input.GetKeyDown(KeyCode.E))
            {
                image.sprite = icons[1];
                ParSys.Play();
                //play save sound

                sv.last_pos = GameObject.Find("Player").GetComponent<Transform>().position; // save player possision

                string scn = SceneManager.GetActiveScene().name; // save player room
                sv.last_Level = scn;               

                SaveManager.Save(sv); // save all data to saveFile

                GameObject.Find("GameManager").GetComponent<GameManager>().UpdateInfo();

            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        image.sprite = icons[0];
        E_interactKey.SetActive(false);
        canPressE = false;
    }
}
