using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManagerScript : MonoBehaviour
{
    private CinemachineVirtualCamera[] cameras;
    internal bool isInDialog;
    public TextMeshPro dialogueText;
    public string[] dialogue;
    public void SwitchPriority(string camera)
    {
        cameras = FindObjectsOfType<CinemachineVirtualCamera>();

        foreach (CinemachineVirtualCamera cam in cameras)
        {
            cam.Priority = 0;
        }

        GameObject.Find(camera).GetComponent<CinemachineVirtualCamera>().Priority = 1;
    }

    public void StartDialogue()
    {
        isInDialog = true;

        for (int i = 0; i <= dialogue.Length;)
        {
            dialogueText.text = dialogue[i];
            i++;
        }

       
    }


    public void EndDialogue()
    {
        dialogueText.text = "";
        isInDialog = false;
    }


}
