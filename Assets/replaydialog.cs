using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class replaydialog : MonoBehaviour
{
    public GameObject Replaydialog;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Replaydialog.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Replaydialog.SetActive(false);
        }
    }
}
