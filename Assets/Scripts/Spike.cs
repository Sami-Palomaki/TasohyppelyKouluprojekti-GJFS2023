using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public float bounceForce = 10f; // Pomppuvoima, joka pelaajalle annetaan osuessaan piikkiin
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Pomppaa pelaaja ilmaan
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector2 bounceDirection = (other.transform.position - transform.position).normalized;
                rb.velocity = new Vector2(rb.velocity.x, 0f);
                rb.AddForce(bounceDirection * bounceForce, ForceMode.Impulse);
            }
        }
    }
}
