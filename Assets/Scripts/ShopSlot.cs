using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopSlot : InventorySlot
{
    [SerializeField] TextMeshProUGUI priceText;

    // Start is called before the first frame update
    override protected void Start()
    {
        icon.sprite = ingredient.icon;

        //Updating ingredient price text
        priceText.text = ingredient.price.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BuyProduct()
    {
        //Checking if has enough money
        if (GameManager.Instance.currency >= ingredient.price)
        {
            //Reducing price from currency
            GameManager.Instance.currency -= ingredient.price;

            //Adding 1 ingredient to the inventory
            GameManager.Instance.GetIngredients(ingredient, 1);
        }
    }

}
