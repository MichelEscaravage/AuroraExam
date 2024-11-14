using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheckerScript : MonoBehaviour
{

    public bool stopCheck;
    public float resumeCheckTime = 20f;
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

    public void StopCheck()
    {
        stopCheck = true;
        Invoke("ResumeCheck", resumeCheckTime);
        isGrounded = false;
    }

    private void ResumeCheck()
    {
        stopCheck = false;  
    }
}
