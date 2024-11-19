using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LorePickup : MonoBehaviour
{
    public LoreItem loreItem;       // Reference to the LoreItem ScriptableObject
    public TMP_Text loreDisplayText;   // Reference to a UI Text component

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (loreDisplayText != null)
            {
                loreDisplayText.text = $"Picked up: {loreItem.loreTitle}\n{loreItem.loreText}";
            }
            Debug.Log($"Picked up: {loreItem.loreTitle}");
            Destroy(gameObject); // Remove the item from the world
        }
    }
}