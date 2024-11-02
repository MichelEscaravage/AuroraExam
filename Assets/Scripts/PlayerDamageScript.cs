using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageScript : MonoBehaviour
{
    HitCheckScript hitChecker;
    Renderer playerRenderer;
    void Start()
    {
        hitChecker = GetComponentInChildren<HitCheckScript>();
        playerRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hitChecker.isHit)
        {
            playerRenderer.material.color = Color.red;  
        }
        else
        {
            playerRenderer.material.color = Color.white;
        }
    }


}
