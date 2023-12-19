using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EncyclopediaDescription : MonoBehaviour
{
    public GameObject[] objectsToToggle;
    public ItemSO item; // Fais glisser ton ScriptableObject ici dans l'Inspector

    [Header("UI Object")]//Glisser les éléments dans l'Inspector
    public TextMeshProUGUI nameText;
    public Image objectImage;
    public TextMeshProUGUI ressourceTypeText;
    //public TextMeshProUGUI goldValueText;
    public TextMeshProUGUI descriptionText;


    void Start()
    {
        // Assure-toi que l'ItemSO et le TextMeshPro sont référencés
        if (item != null)
        {
            // Affecte le texte ou l'image du ScriptableObject au TextMeshPro ou à l'Image
            nameText.text = item.Name;
            nameText.color = Color.black;
            objectImage.sprite = item.Icon;
            ressourceTypeText.text = "Type de ressource : " + item.ResourceType;
            ressourceTypeText.color = Color.black;
            //goldValueText.text = "Valeur de l'objet : " + item.GoldValue.ToString();
            descriptionText.text = item.Description;
            descriptionText.color = Color.black;

        }
        else
        {
            Debug.LogError("ItemSO ou TextMeshProUGUI non référencé dans le script.");
        }
    }

    public void ToggleState(GameObject target)
    {
        foreach (var obj in objectsToToggle)
        {
            // Active l'objet cible et désactive les autres
            obj.SetActive(obj == target);
        }

        target.SetActive(!target.activeSelf);
    }
}
