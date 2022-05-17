using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class off : MonoBehaviour
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
            rb.velocity = new Vector2(speed, rb.velocity.y);
            if (transform.position.x > uppoint.position.x)
            {
                uping = false;
            }
        }
        else
        {
            rb.velocity = new Vector2( -speed, rb.velocity.y);
            if (transform.position.x < downpoint.position.x)
            {
                uping = true;
            }
        }
    }
}
