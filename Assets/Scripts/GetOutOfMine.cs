using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GetOutOfMine : MonoBehaviour
{ 
    // public Player player;
    private bool enterAllowed;
    private string sceneLoad;

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            sceneLoad = "Outdoor";
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
            Debug.Log("Pitäisi vaihtaa skeneä!");
            SceneManager.LoadScene(sceneLoad);
        }
    }
}
