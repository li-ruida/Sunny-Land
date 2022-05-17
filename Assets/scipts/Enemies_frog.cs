using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies_frog : Enemies
{
    private Rigidbody2D rb;
    private bool faceleft = true;
    public float speed;
    private Collider2D coll;
    public LayerMask ground;
    public Transform leftpoint,rightpoint;
    //private Animator anim;
    private float leftx, rightx;
    public float jumpforce;
     protected override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();

        transform.DetachChildren();//取消青蛙与其子坐标点关系
        leftx = leftpoint.position.x;
        rightx = rightpoint.position.x;
        Destroy(leftpoint.gameObject);
        Destroy(rightpoint.gameObject);
    }

    void Update()
    {
        //movement();动画事件中调用
        switchanim();
    }
    void movement()
    {
        if(faceleft)
        {
            if (coll.IsTouchingLayers(ground))
            {
                anim.SetBool("jumping", true);
                rb.velocity = new Vector2(-speed, jumpforce); 
                
            }
            if(transform.position.x<leftx)
            {
                transform.localScale = new Vector3(-1, 1, 1);//实现掉头
                faceleft = false;
            }
        }
        else
        {
            if (coll.IsTouchingLayers(ground))
            {
                anim.SetBool("jumping", true);
                rb.velocity = new Vector2(speed, jumpforce);
            }
            if (transform.position.x > rightx)
            {
                transform.localScale = new Vector3(1, 1, 1);//实现掉头
                faceleft = true;
            }
        }
    }
    void switchanim()
    {
        if(anim.GetBool("jumping"))
        {
            if(rb.velocity.y<0.1)
            {
                anim.SetBool("jumping", false);
                anim.SetBool("falling", true);
            }
        }
        if(coll.IsTouchingLayers(ground)&&anim.GetBool("falling"))
        {
            anim.SetBool("falling", false);
        }
    }
    
}
