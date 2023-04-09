using UnityEngine;
using TMPro;

public class SpeechBubble : MonoBehaviour
{
    public TMP_Text puhekuplanTeksti;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            puhekuplanTeksti.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            puhekuplanTeksti.gameObject.SetActive(false);
        }
    }
}
