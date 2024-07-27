using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public int dayCount;
    public int currency;

    public List<IngredientScriptable> ingredients = new List<IngredientScriptable>();

    [SerializeField] int minCurrencyGain;
    [SerializeField] int maxCurrencyGain;

    [SerializeField] int minIngredientGain;
    [SerializeField] int maxIngredientGain;

    [Range(0, 100)]
    [SerializeField] float ingredientGainChance;

    [SerializeField] TextMeshProUGUI currencyText;

    private void Start()
    {
        StartGame();
        StartDay();
    }

    public void StartGame()
    {
        dayCount = 0;
        currency = 250;
    }
    public void StartDay()
    {
        dayCount++;
        //ClientManager.Instance.PopulateQueue(5);
        //Checking if it's the start of the week
        if (dayCount % 7 == 0)
        {
            GetCurrency();
        }
        //Getting a random chance for getting ingredient
        float _chance = Random.Range(0f, 100f);
        //Checking chance
        if(_chance <= ingredientGainChance)
        {
            //Getting an random index
            int ind = Random.Range(0, ingredients.Count);
            //Getting the ingredient
            IngredientScriptable ing = ingredients[ind];
            //Getting a random number of ingredients to get
            int quantity = Random.Range(minIngredientGain, maxIngredientGain + 1);

            GetIngredients(ing, quantity);
        }
    }

    private void GetCurrency()
    {
        //Adding a random quantity of currency
        currency += Random.Range(minCurrencyGain, maxCurrencyGain+1);

        UpdateCurrencyText();

    }

    public void GetIngredients(IngredientScriptable ing, int quantity)
    {

        //Adding ingredients
        ing.quantity += quantity;

        Inventory.Instance.UpdateTexts();

        UpdateCurrencyText();
    }

    private void UpdateCurrencyText()
    {
        //Checking if there is a text reference
        if (currencyText != null)
        {
            //Updating currency text
            currencyText.text = "$" + currency;
        }
    }

}
