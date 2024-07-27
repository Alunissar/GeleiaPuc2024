using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{

    public IngredientScriptable ingredient;
    [SerializeField] TextMeshProUGUI quantityText;

    [SerializeField] protected Image icon;

    virtual protected void Start()
    {
        icon.sprite = ingredient.icon;

        UpdateText();
    }

    public void Clicked()
    {
        //Getting ingredient based on index
        Inventory.Instance.GetIngredient(transform.GetSiblingIndex());
    }

    public void UpdateText()
    {
        //Changing the quantity text
        quantityText.text = ingredient.quantity.ToString();
    }
}
