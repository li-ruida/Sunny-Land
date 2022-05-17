using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class playercontroler : MonoBehaviour
{
    private Rigidbody2D rb;//private前加[SerializeField]private在界面可视
    private Animator anim;
    public Collider2D coll;
    public float speed ;
    public float jumpforce;
    public LayerMask ground;
    public int Cherry=0;
    public int ijump;//跳跃次数
    public Collider2D crouch;
    public Text cherrynumber;
    public int Gem = 0;
    public Collider2D discoll;
    public Text gemnumber;
    private bool isHurt;//默认false
    public AudioSource jumpaudio,hitaudio;
    public AudioSource collectionaudio;
    public Joystick joystick;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        crouch = GetComponent<BoxCollider2D>();//实现控制下蹲
    }
    void Update()//FixedUpdate可以保证每次的执行,防止因设备性能问题控制迟钝
    {
        if(!isHurt)
        movement();
        switchanim();
    }

    void movement()//键盘
    {
        float horizontalMove = Input.GetAxis("Horizontal");//--1左 0不动 1右方向键控制;获取[-1,1]之间的数
        float facedircetion = Input.GetAxisRaw("Horizontal");//只获得-1 0 1
        //角色移动
        rb.velocity = new Vector2(horizontalMove * speed, rb.velocity.y);// 如果speed*Time.deltaTime控制两帧运行时间相等会减慢速度
        anim.SetFloat("running", Mathf.Abs(facedircetion));
        if (facedircetion!=0)//这个不能省略
        transform.localScale = new Vector3(facedircetion, 1, 1);
        //角色跳跃
        
        if (Input.GetButtonDown("Jump")&&ijump>0)//实现二段跳
        { 
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
            //vector2.up*jumpforce;.up==(0,1)
            jumpaudio.Play();
            anim.SetBool("jumping", true);
            --ijump;
        }
        if(coll.IsTouchingLayers(ground))
        ijump = 1;
        if(Input.GetKey(KeyCode.S)&& coll.IsTouchingLayers(ground))
        { anim.SetBool("crouching", true);
            crouch.enabled = false;
            //discoll.enabled = false;//取消下蹲时的碰撞提
        }
        else
        {
            anim.SetBool("crouching", false);
            crouch.enabled = true;
            //discoll.enabled = true;
        }
    }//移动
   /* 
    
    void movement()//手机
    {
        //float horizontalMove = Input.GetAxis("Horizontal");//--1左 0不动 1右方向键控制;获取[-1,1]之间的数
        float horizontalMove = joystick.Horizontal;
        float facedircetion = joystick.Horizontal;//只获得-1 0 1
        //角色移动
        if (horizontalMove!=0f)
        {
            rb.velocity = new Vector2(horizontalMove * speed, rb.velocity.y);
            anim.SetFloat("running", Mathf.Abs(horizontalMove));
        }
        // 如果speed*Time.deltaTime控制两帧运行时间相等会减慢速度
       
        if (facedircetion >0f)//这个不能省略
            transform.localScale = new Vector3(1, 1, 1);
        else if(facedircetion < 0f)//这个不能省略
            transform.localScale = new Vector3(-1, 1, 1);
        //角色跳跃

        if (joystick.enabled&&joystick.Vertical>0.3f&&coll.IsTouchingLayers(ground))//实现二段跳
        {
            ijump = 1;
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
            //vector2.up*jumpforce;.up==(0,1)
            jumpaudio.Play();
            anim.SetBool("jumping", true);
            --ijump;
            if (ijump < 0)
            {
                anim.SetBool("jumping", false);
            }
        }
        if (coll.IsTouchingLayers(ground))
            ijump = 1;
        if (joystick.Vertical<-0.3f && coll.IsTouchingLayers(ground))
        {
            anim.SetBool("crouching", true);
            crouch.enabled = false;
            //discoll.enabled = false;//取消下蹲时的碰撞提
        }
        else
        {
            anim.SetBool("crouching", false);
            crouch.enabled = true;
            //discoll.enabled = true;
        }
    }
    void switchanim()//手机
    {
        anim.SetBool("idle", false);//关于idle代码可删除
        if (anim.GetBool("jumping"))
        {
            if (rb.velocity.y < 0)
            {
                anim.SetBool("jumping", false);
                anim.SetBool("falling", true);
            }
        }
        else if (isHurt)
        {

            anim.SetBool("hurt", true);
            if (Mathf.Abs(rb.velocity.x) < 0.1f)
            {
                anim.SetBool("hurt", false);
                anim.SetBool("idle", true);
                anim.SetFloat("running", 0);
                isHurt = false;
            }
        }
        else if (coll.IsTouchingLayers(ground)&&joystick.Vertical>0.5f)
        {
            anim.SetBool("falling", false);
            anim.SetBool("idle", true);
        }

    }
   */
    void switchanim()
    {
        anim.SetBool("idle", false);//关于idle代码可删除
        if (anim.GetBool("jumping"))
        {
            if(rb.velocity.y<0)
            {
                anim.SetBool("jumping", false);
                anim.SetBool("falling", true);
            }
        }
        else if (isHurt)
        {
          
            anim.SetBool("hurt", true);
            if (Mathf.Abs(rb.velocity.x) < 0.1f)
            {
                anim.SetBool("hurt", false);
                anim.SetBool("idle", true);
                anim.SetFloat("running", 0);
                isHurt = false;
            }
        }
        else if(coll.IsTouchingLayers(ground))
        {
            anim.SetBool("falling", false);
            anim.SetBool("idle", true);
        }
        
    }
    //切换动画

    //碰撞触发器
    private void OnTriggerEnter2D(Collider2D collision)//收集物品
    {
        collectionaudio.Play();
        if (collision.tag=="Collection")
        {
            
            Destroy(collision.gameObject);
            Cherry+=1;
            cherrynumber.text = Cherry.ToString();
        }
        if (collision.tag == "collectiongem")
        {
            Destroy(collision.gameObject);
            Gem += 1;
            gemnumber.text = Gem.ToString();
        }
        if (collision.tag == "deadliine")
        {
            GetComponent<AudioSource>().enabled = false;//关闭音源
            Invoke("restart", 1.5f);
        }
    }
    //消灭敌人
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemies")
        {
            //Enemies_frog frog = collision.gameObject.GetComponent<Enemies_frog>();
            Enemies enemy = collision.gameObject.GetComponent<Enemies>();
            if (anim.GetBool("falling"))
            {
                //Destroy(collision.gameObject);消灭敌人
               enemy.jumpon();
                rb.velocity = new Vector2(rb.velocity.x, jumpforce);//消灭敌人后跳跃
                anim.SetBool("jumping", true);
            }
            else if(transform.position.x<collision.gameObject.transform.position.x)
            {
                rb.velocity = new Vector2(-5, rb.velocity.y);
                hitaudio.Play();
                isHurt = true;
            }
            else if (transform.position.x > collision.gameObject.transform.position.x)
            {
                rb.velocity = new Vector2(5, rb.velocity.y);
                hitaudio.Play();
                isHurt = true;
            }  
        }
    }
    void restart()
    {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);//重载当前使用场景的名字        
    }
}
