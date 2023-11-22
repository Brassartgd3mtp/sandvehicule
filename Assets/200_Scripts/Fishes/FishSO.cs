using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Fishes", menuName = "AllFishes/ Fish")]
public class FishSO : ScriptableObject
{
    public int ID;
    public string Name;
    [TextArea (4,4)]
    public string Description;
    public Sprite Icon;
    public float Value;
}
