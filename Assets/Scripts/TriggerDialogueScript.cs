using UnityEngine;

public class TriggerDialogueScript : MonoBehaviour
{
    private bool isPlayerInRange;

    [SerializeField] private string cameraName;      // Dialogue camera to activate
    [SerializeField] private Dialogue dialogueData; // Dialogue data for this NPC
    [SerializeField] private string PlayerCameraName; // Player camera to reset to

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;

            if (DialogueManager.Instance.isInDialog)
            {
                DialogueManager.Instance.EndDialogue();
            }

            // Reset to the player camera
            DialogueManager.Instance.SwitchPriority(PlayerCameraName);
        }
    }

    private void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E) && !DialogueManager.Instance.isInDialog)
        {
            DialogueManager.Instance.StartDialogue(cameraName, dialogueData);
        }

        if (DialogueManager.Instance.isInDialog && Input.GetKeyDown(KeyCode.Return))
        {
            DialogueManager.Instance.NextDialog();
        }
    }
}