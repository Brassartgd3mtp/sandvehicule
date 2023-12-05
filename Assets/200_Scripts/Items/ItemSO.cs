using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


/// <summary>
/// C'est un scriptable onject qui définit ce qu'est un objet dans notre jeu
/// Cela va permettre d'avoir différentes branches d'objets
/// </summary>

[CreateAssetMenu (fileName = "ItemSO", menuName = "AllItems/ Item")]
public class ItemSO : ScriptableObject
{
    public int ID;
    public string Name;
    [TextArea(4, 4)]
    public string Description;
    public Sprite Icon;
    public int MaxStackSize;
    public string ResourceType;
    public int GoldValue;
    public GameObject UI_ItemPickup;
}
