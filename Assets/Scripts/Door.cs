using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Collision with: " + collision.gameObject.name);
        if (collision.tag == "Player")
        {
            int index = SceneManager.GetActiveScene().buildIndex;

            if (index != 1)
            {
                SceneManager.LoadScene(index + 1);
            }
            else
            {
                SceneManager.LoadScene(index - 1);
            }
        }
    }
}
