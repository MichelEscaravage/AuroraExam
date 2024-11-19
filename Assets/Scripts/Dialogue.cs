using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    [SerializeField] private string name;
    [SerializeField] private List<string> _dialogues = new();

    public string Name => name;
    public List<string> Dialogues => _dialogues;
}
