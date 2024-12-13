using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoreInventoryUI : MonoBehaviour
{
    public LoreInventory loreInventory; // Reference to the LoreInventory script
    public GameObject loreItemPrefab;   // Prefab for displaying a lore entry
    public Transform loreListParent;    // Parent object for the UI list

    private void OnEnable()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        Debug.Log("Updating UI...");

        // Check for null references
        if (loreListParent == null)
        {
            Debug.LogError("loreListParent is not assigned!");
            return;
        }

        if (loreItemPrefab == null)
        {
            Debug.LogError("loreItemPrefab is not assigned!");
            return;
        }

        if (loreInventory == null)
        {
            Debug.LogError("loreInventory is not assigned!");
            return;
        }

        // Clear existing UI elements
        foreach (Transform child in loreListParent)
        {
            Destroy(child.gameObject);
        }

        // Populate UI with collected lore
        foreach (var loreItem in loreInventory.collectedLore)
        {
            Debug.Log($"Adding {loreItem.loreTitle} to UI");

            // Create a new UI element from the prefab
            GameObject newLoreUI = Instantiate(loreItemPrefab, loreListParent);
            if (newLoreUI == null)
            {
                Debug.LogError("Failed to instantiate loreItemPrefab!");
                continue;
            }

            // Assign data to the prefab's UI components
            Image icon = newLoreUI.transform.Find("Icon")?.GetComponent<Image>();
            TMP_Text title = newLoreUI.transform.Find("TextContainer/Title")?.GetComponent<TMP_Text>();
            TMP_Text description = newLoreUI.transform.Find("TextContainer/Description")?.GetComponent<TMP_Text>();

            if (icon == null) Debug.LogError("Icon object not found in prefab!");
            if (title == null) Debug.LogError("Title object not found in prefab!");
            if (description == null) Debug.LogError("Description object not found in prefab!");

            if (icon != null) icon.sprite = loreItem.loreIcon;
            if (title != null) title.text = loreItem.loreTitle;
            if (description != null) description.text = loreItem.loreText;
        }
    }
}
