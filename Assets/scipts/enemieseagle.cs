using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class enemieseagle : Enemies
{
    private Rigidbody2D rb;
    //private Collider2D coll;
    public float speed;
    public Transform top, bottom;
    private float topy, bottomy;
    private bool isup;
    protected override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody2D>();
        //coll = GetComponent<Collider2D>();
        topy = top.position.y;
        bottomy = bottom.position.y;
        Destroy(top.gameObject);
        Destroy(bottom.gameObject);
    }

    
    void Update()
    {
        movement();
    }
    void movement()
    {
        if(isup)
        {
            rb.velocity = new Vector2(rb.velocity.x, speed);
            if(transform.position.y>topy)
            {
                isup = false;
            }
        }
        else
        {
            rb.velocity = new Vector2(rb.velocity.x, -speed);
            if (transform.position.y < bottomy)
            {
                isup = true;
            }
        }
    }
}
