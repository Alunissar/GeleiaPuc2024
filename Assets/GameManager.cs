using System.Collections;
using System.Collections.Generic;
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
            GetIngredients();
        }
    }

    private void GetCurrency()
    {
        //Adding a random quantity of currency
        currency += Random.Range(minCurrencyGain, maxCurrencyGain+1);
    }

    private void GetIngredients()
    {
        //Getting an random index
        int ind = Random.Range(0, ingredients.Count);
        //Getting a random number of ingredients to get
        int quantity = Random.Range(minIngredientGain,maxIngredientGain+1);
        //Adding ingredients
        ingredients[ind].quantity += quantity;

        Inventory.Instance.UpdateTexts();
    }

}
