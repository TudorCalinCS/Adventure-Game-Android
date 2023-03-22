using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    public Canvas talkCanvas;
    public bool isOnTrigger=false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isOnTrigger = true;
            Debug.Log("Npc collide with Player!");
            talkCanvas.enabled = true;
           
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        
        talkCanvas.enabled = false;
        isOnTrigger = false;

    }
}

