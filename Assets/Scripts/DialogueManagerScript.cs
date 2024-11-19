using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Cinemachine;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    [SerializeField] private TMP_Text _title;    // Speaker name UI
    [SerializeField] private TMP_Text _dialogue; // Dialogue text UI

    private CinemachineVirtualCamera[] cameras;
    private int _nameIndex;
    private int _dialogIndex;
    private List<Dialogue> _currentDialogues; // Holds the current NPC's dialogue
    internal bool isInDialog;
    public GameObject Panel;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartDialogue(string cameraName, Dialogue dialogueData)
    {
        // Initialize dialogue
        _nameIndex = 0;
        _dialogIndex = 0;
        _currentDialogues = new List<Dialogue> { dialogueData };
        isInDialog = true;

        // Switch camera and display the first line
        Panel.SetActive(true);  
        SwitchPriority(cameraName);
        DisplayDialog();
    }

    private void DisplayDialog()
    {
        if (_currentDialogues != null && _nameIndex < _currentDialogues.Count)
        {
            _title.text = _currentDialogues[_nameIndex].Name;
            _dialogue.text = _currentDialogues[_nameIndex].Dialogues[_dialogIndex];
        }
    }

    public void NextDialog()
    {
        if (_dialogIndex < _currentDialogues[_nameIndex].Dialogues.Count - 1)
        {
            _dialogIndex++;
        }
        else
        {
            EndDialogue(); // End dialogue when finished
        }

        DisplayDialog();
    }

    public void EndDialogue()
    {
        _title.text = "";
        _dialogue.text = "";
        Panel.SetActive(false);
        isInDialog = false;

        ResetCameraPriorities();
    }

    public void SwitchPriority(string cameraName)
    {
        cameras = FindObjectsOfType<CinemachineVirtualCamera>();

        foreach (CinemachineVirtualCamera cam in cameras)
        {
            cam.Priority = 0;
        }

        GameObject targetCamera = GameObject.Find(cameraName);
        if (targetCamera != null)
        {
            targetCamera.GetComponent<CinemachineVirtualCamera>().Priority = 1;
        }
        else
        {
            Debug.LogWarning($"Camera with name {cameraName} not found!");
        }
    }

    private void ResetCameraPriorities()
    {
        foreach (CinemachineVirtualCamera cam in cameras)
        {
            cam.Priority = 0;
        }
    }
}
