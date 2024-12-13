using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActivateBoulderScript : MonoBehaviour
{
    private Rigidbody boulderRigidbody; // Reference to the Rigidbody

    [SerializeField] private Transform player;       // Reference to the player's Transform
    [SerializeField] private Transform startPoint;   // Reference to the starting point Transform

    private void Start()
    {
        // Get the Rigidbody component and disable physics initially
        boulderRigidbody = GetComponent<Rigidbody>();
        boulderRigidbody.isKinematic = true; // Disable physics
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ActivateBoulder();
        }
    }

    private void ActivateBoulder()
    {
        // Enable physics by making the Rigidbody non-kinematic
        if (boulderRigidbody != null)
        {
            boulderRigidbody.isKinematic = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ResetPlayer();
        }
    }

    private void ResetPlayer()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index);
    }
}
