using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WillNotGoFurther : MonoBehaviour
{ 

    public TMP_Text puhekuplanTeksti;

    private IEnumerator WaitAndHide(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        puhekuplanTeksti.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Miksei tämä toimi?");
        puhekuplanTeksti.gameObject.SetActive(true);
        StartCoroutine(WaitAndHide(3f));
    }
}
