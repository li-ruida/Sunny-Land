using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    protected Animator anim;
    protected AudioSource deathAudio;
    protected virtual void Start()
    {
        anim = GetComponent<Animator>();
        deathAudio = GetComponent<AudioSource>();
    }
    public void death()
    {

        Destroy(gameObject);//消灭敌人

    }
    public void jumpon()
    {
        anim.SetTrigger("death");
        deathAudio.Play();
    }
}
