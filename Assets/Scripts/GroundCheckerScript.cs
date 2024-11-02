using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheckerScript : MonoBehaviour
{
    public bool isGrounded;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Floor")
        {
            isGrounded = true;  
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Floor")
        {
            isGrounded = false;
        }
    }
}
