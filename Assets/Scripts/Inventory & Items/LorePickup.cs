using TMPro;
using UnityEngine;

public class LorePickup : MonoBehaviour
{
    public LoreItem loreItem;       // Reference to the LoreItem ScriptableObject
    public TMP_Text loreDisplayText;   // Reference to a UI Text component
    public float displayTime = 3f; // Duration to display the message

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Triggered by: {other.name}");
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player detected!");
            LoreInventory inventory = other.GetComponentInChildren<LoreInventory>();
            if (inventory != null)
            {
                Debug.Log($"Adding Lore: {loreItem.loreTitle}");
                inventory.AddLore(loreItem);

                // Use a persistent object to handle the display logic
                if (loreDisplayText != null)
                {
                    LoreDisplayManager.Instance.ShowLorePopup(loreDisplayText, loreItem, displayTime);
                }
            }
            else
            {
                Debug.LogError("LoreInventory component not found on Player!");
            }

            // Destroy the pickup object
            Destroy(gameObject);
        }
    }
}
