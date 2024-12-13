using System.Collections.Generic;
using UnityEngine;

public class LoreInventory : MonoBehaviour
{
    public List<LoreItem> collectedLore = new List<LoreItem>(); // List of collected lore
    private LoreInventoryUI cachedLoreInventoryUI;
    public void AddLore(LoreItem loreItem)
    {
        if (!collectedLore.Contains(loreItem)) // Avoid duplicates
        {
            collectedLore.Add(loreItem);
            Debug.Log($"Collected Lore: {loreItem.loreTitle}");

            // Find and cache the LoreInventoryUI reference
            if (cachedLoreInventoryUI == null)
            {
                cachedLoreInventoryUI = FindObjectOfType<LoreInventoryUI>();
            }

            // Call UpdateUI if reference is found
            if (cachedLoreInventoryUI != null)
            {
                cachedLoreInventoryUI.UpdateUI();
            }
            else
            {
                Debug.LogError("LoreInventoryUI not found in the scene!");
            }
        }
        else
        {
            Debug.Log($"Lore '{loreItem.loreTitle}' already collected.");
        }

        Debug.Log($"CollectedLore now contains {collectedLore.Count} items.");
    }
}
