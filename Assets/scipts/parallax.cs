using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax : MonoBehaviour
{
    public Transform cam;
    public float moverate;
    private float startpoint;
    void Start()
    {
        startpoint = transform.position.x; 
    }

    
    void Update()
    {
        transform.position = new Vector2(startpoint + cam.position.x * moverate, transform.position.y);
    }
}
