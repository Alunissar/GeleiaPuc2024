using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{

    public IngredientScriptable ingredient;
    [SerializeField] TextMeshProUGUI quantityText;

    private void Start()
    {
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
