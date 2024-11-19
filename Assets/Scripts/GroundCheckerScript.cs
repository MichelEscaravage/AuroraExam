using UnityEngine;

public class GroundCheckerScript : MonoBehaviour
{
    public bool stopCheck;
    public float resumeCheckTime = 0.1f; // Shortened time to resume ground check quickly
    public bool isGrounded;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Floor"))
        {
            isGrounded = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Floor"))
        {
            isGrounded = false;
        }
    }

    public void StopCheck()
    {
        stopCheck = true;
        Invoke("ResumeCheck", resumeCheckTime); // Resume quickly after a small delay
        isGrounded = false; // Temporarily disable ground check
    }

    private void ResumeCheck()
    {
        stopCheck = false;
    }
}
