using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCheckScript : MonoBehaviour
{
    public bool isHit;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NPC")
        {
            isHit = true;
        }
    }



    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "NPC")
        {
            isHit = false;
        }
    }

}
