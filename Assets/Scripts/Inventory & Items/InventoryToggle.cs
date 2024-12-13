using UnityEngine;

public class InventoryToggle : MonoBehaviour
{
    public GameObject inventoryUI; // Reference to the Inventory UI (Canvas or Panel)

    private bool isInventoryOpen = false; // Track inventory state

    void Update()
    {
        // Check if the Tab key is pressed
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isInventoryOpen = !isInventoryOpen; // Toggle inventory state
            inventoryUI.SetActive(isInventoryOpen); // Show or hide inventory
        }
    }
}
