using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterPointScript : MonoBehaviour
{
    [SerializeField] private SceneLoader sceneManager;
    public string wantedScene;
    [SerializeField] private Canvas canvasPlayer;   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Collision with Player");
            canvasPlayer.enabled = true;
            
        }
        Debug.Log("Collision with Player");
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Collision with Player");
            canvasPlayer.enabled = false;

        }
    }
    public void pressedEnterButton()
    {
        sceneManager.load_a_Scene = true;
        sceneManager.theScene = wantedScene;
    }
}
