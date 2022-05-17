using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hhh : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public Transform uppoint, downpoint;
    public bool uping = true;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement();
        transform.DetachChildren();//断绝与子点坐标关系
    }
    void movement()
    {
        if (uping)
        {
            rb.velocity = new Vector2(rb.velocity.x, speed);
            if (transform.position.y > uppoint.position.y)
            {
                uping = false;
            }
        }
        else
        {
            rb.velocity = new Vector2(rb.velocity.x, -speed);
            if (transform.position.y < downpoint.position.y)
            {
                uping = true;
            }
        }
    }
}
