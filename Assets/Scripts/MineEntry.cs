using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MineEntry : MonoBehaviour
{ 
    // public Player player;
    private bool enterAllowed;
    private string sceneLoad;

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            sceneLoad = "Mine";
            enterAllowed = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            enterAllowed = false;
        }
    }

    private void Update() 
    {
        if(enterAllowed && Input.GetKey(KeyCode.W))
        {
            SceneManager.LoadScene(sceneLoad);
        }
    }
}
