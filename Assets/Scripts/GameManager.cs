using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public enum DayState
    {
        Deliver,
        Kitchen,
        Shop,
    }

    public DayState currentDayState;

    public int dayCount;
    public int currency;

    [SerializeField] InventoryShop inventoryShop;

    public List<IngredientScriptable> ingredients = new List<IngredientScriptable>();

    [SerializeField] int minCurrencyGain;
    [SerializeField] int maxCurrencyGain;

    [SerializeField] int minIngredientGain;
    [SerializeField] int maxIngredientGain;

    public int ingredientsNumber = 0;

    [Range(0, 100)]
    [SerializeField] float ingredientGainChance;

    [SerializeField] private int dailyClients;

    [SerializeField] TextMeshProUGUI currencyText;

    public Action<DayState> changeDayState;

    [SerializeField] int Bonus;

    private int feedback;
    private int clients;

    [SerializeField] GameObject pauseMenu;

    [Header("Summary")]
    [SerializeField] TextMeshProUGUI summaryTitle;
    [SerializeField] TextMeshProUGUI summaryText;

    [Header("Scriptable Object Refs")]
    [SerializeField] private CharacterSO[] characterSOs;

    private void Start()
    {
        StartGame();
        StartDay();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    public void StartGame()
    {
        dayCount = 0;
        currency = 250;

        //Getting how many ingredients you are starting with
        ingredientsNumber = 0;

        //Going through all ingredients
        for (int i = 0; i < ingredients.Count; i++)
        {
            //Adding to the count of ingredients
            ingredientsNumber += ingredients[i].quantity;
        }
        ResetSOs();
    }

    private void ResetSOs()
    {
        foreach(CharacterSO character in characterSOs)
        {
            character._hasMet = false;
            character.meetingTimes = 0;
        }

        foreach (IngredientScriptable ingredient in ingredients)
        {
            ingredient.quantity = 1;
        }
    }

    public void StartDay()
    {

        //Checks how much money have at the start of the day
        int _currency = currency;

        dayCount++;

        if (dayCount >= 24)
        {
            SceneManager.LoadScene(2);
        }

        ClientManager.Instance.PopulateQueue(dailyClients);

        //Checking if it's the start of the week
        if (dayCount % 7 == 0)
        {
            GetCurrency();

            if (clients > 0)
            {
                //Checking if had bad review
                if (feedback / clients < 0)
                {
                    SceneManager.LoadScene(3);
                }
            }

            //Reseting feedback values
            clients = 0;
            feedback = 0;
        }
        //Getting a random chance for getting ingredient
        float _chance = UnityEngine.Random.Range(0f, 100f);

        //Getting an random index
        int ind = UnityEngine.Random.Range(0, ingredients.Count);
        //Getting the ingredient
        IngredientScriptable ing = ingredients[ind];
        //Getting a random number of ingredients to get
        int quantity = UnityEngine.Random.Range(minIngredientGain, maxIngredientGain + 1);

        //Checking chance
        if (_chance <= ingredientGainChance)
        {
            GetIngredients(ing, quantity);
        }
        else
        {
            quantity = 0;
        }

        //Checking how much money is different
        _currency = currency - _currency;

        UpdateShopText(ing, quantity, _currency);

    }

    private void GetCurrency()
    {
        //Adding a random quantity of currency
        currency += UnityEngine.Random.Range(minCurrencyGain, maxCurrencyGain+1);

        //Adding or reducing Bonus
        currency += Bonus * (feedback / clients);

        UpdateCurrencyText();

    }

    public void GetIngredients(IngredientScriptable ing, int quantity)
    {

        //Adding ingredients
        ing.quantity += quantity;

        ingredientsNumber += quantity;

        Inventory.Instance.UpdateTexts();

        inventoryShop.UpdateText();

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

    private void UpdateShopText(IngredientScriptable ing, int quantity, int _currency)
    {
        summaryTitle.text = "Dia: " + dayCount + "\n";

        //Clearing text
        summaryText.text = "";

        //Checking if had clients
        if (clients > 0)
        {
            //Reseting summary text
            summaryText.text = "Reputa��o gerada pelo Bandej�o " + "(" + (feedback / clients) + ")" + "\n";
        }

        //Checking if there were ingredient donations
        if(quantity > 0)
        {
            summaryText.text += "Doa��o de alimentos: " + ing.ingredientName + "(" + quantity +")" + "\n";
        }
        //Checking if there were any money alterations
        if(_currency > 0)
        {
            summaryText.text += "Doa��o em dinheiro: " + "$" + _currency;
        }

        UpdateCurrencyText();

    }

    public void GetFeedback(int _feed)
    {
        //Adding to the feed
        feedback += _feed;
        clients++;
    }

    public void PauseGame()
    {
        //Enabling and disabling pause
        pauseMenu.SetActive(!pauseMenu.activeSelf);
    }

    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }

}
