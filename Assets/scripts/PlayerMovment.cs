using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float speed;
    Animator anim;
    Vector2 vectors;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();              
    }


    void Update()
    {
        var horz = Input.GetAxisRaw("Horizontal");
        var vert = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(horz, vert);

        anim.SetFloat("Horz", horz);
        anim.SetFloat("Vert", vert);
        anim.SetFloat("Speed", movement.sqrMagnitude);

        rb.velocity = new Vector2(horz,vert) * speed;
    }
}
