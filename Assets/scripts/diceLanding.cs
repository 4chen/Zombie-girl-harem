using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diceLanding : MonoBehaviour
{
    [SerializeField] PointIncreeser givePoints;
    [SerializeField] Transform diDrag;

    public void Start()
    {
        diDrag = this.gameObject.transform.GetChild(0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Dice")
        {
            diDrag.gameObject.GetComponent<Animator>().enabled = false;
            diDrag.gameObject.GetComponent<diceDrag>().canDrag = true;
            givePoints.StartCoroutine("IncreesPoints");
        }
    }
}
