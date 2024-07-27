using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodShow : MonoBehaviour
{

    Food food;
    public List<IngredientScriptable> ingredients = new List<IngredientScriptable>();
    [SerializeField] Image ingredientPanel;

    // Start is called before the first frame update
    void Start()
    {
        //Getting food's script
        food = GetComponent<Food>();
        ingredients = food.ingredients;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowIngredients()
    {
        //Enabling Panel
        ingredientPanel.gameObject.SetActive(true);

        //Going through all ingredients
        for (int i = 0; i < ingredientPanel.transform.childCount; i++)
        {
            //Checking if doesn't have this ingredient
            if(i >= ingredients.Count)
            {
                //Disabling ingredient image
                ingredientPanel.transform.GetChild(i).gameObject.SetActive(false);
            }
            else
            {
                //Enabling ingredient image
                ingredientPanel.transform.GetChild(i).gameObject.SetActive(true);
                //Passing ingredient icon
                ingredientPanel.transform.GetChild(i).GetComponent<Image>().sprite = ingredients[i].icon;
            }
        }
    }

    public void HideIngredients()
    {
        //Disable panel 
        ingredientPanel.gameObject.SetActive(false);
    }

    private void OnMouseEnter()
    {
        ShowIngredients();
    }

    private void OnMouseExit()
    {
        HideIngredients();
    }

}
