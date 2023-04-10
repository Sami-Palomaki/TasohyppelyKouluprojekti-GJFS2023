using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OffScreenTrigger : MonoBehaviour
{
    // public string youAreDead;
    [SerializeField] private AudioSource youDiedEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            youDiedEffect.Play();
            // AudioManager.instance.Play(youAreDead, this.gameObject);
        }
    }
}
