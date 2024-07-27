using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopSlot : MonoBehaviour
{
    public IngredientScriptable ingredient;
    [SerializeField] TextMeshProUGUI priceText;

    // Start is called before the first frame update
    void Start()
    {
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
