
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;
using TMPro;

public class TriggerDialogueScript : MonoBehaviour
{
    DialogueManagerScript dialogueManagerScript;

   bool isPlayerInRange;
   public TextMeshPro dialogueText;
   public string[] dialogueScript;
       
    void Start()
    {
        dialogueManagerScript = FindObjectOfType<DialogueManagerScript>();
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isPlayerInRange = false;
           dialogueManagerScript.SwitchPriority("PlayerCamera");
           dialogueManagerScript.EndDialogue();
        }
    }

    private void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E) && dialogueManagerScript.isInDialog == false)
        {
            dialogueManagerScript.SwitchPriority("DialogueCamera");
            dialogueManagerScript.dialogue = dialogueScript;
            dialogueManagerScript.dialogueText = dialogueText;
            dialogueManagerScript.StartDialogue();
        }
    }

}
    