using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enterdialog : MonoBehaviour
{
    public GameObject enterdialog1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            enterdialog1.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            enterdialog1.SetActive(false);
        }
    }
}
