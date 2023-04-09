using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HomeEntry : MonoBehaviour
{ 

    private bool enterAllowed;
    public TMP_Text puhekuplanTeksti;

    private IEnumerator WaitAndHide(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        puhekuplanTeksti.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
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
            puhekuplanTeksti.gameObject.SetActive(true);
            StartCoroutine(WaitAndHide(3f));
        }
    }
}
