using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu (fileName = "ItemSO", menuName = "AllItems/ Item")]
public class ItemSO : ScriptableObject
{
    public int ID;
    public string Name;
    [TextArea(4, 4)]
    public string Description;
    public Sprite Icon;
    public int MaxStackSize;
}
