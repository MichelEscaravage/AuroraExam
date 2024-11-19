using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Lore Item", menuName = "Inventory/Lore Item")]
public class LoreItem : ScriptableObject
{
    public string loreTitle;
    public Sprite loreIcon;
    [TextArea] public string loreText;
}
