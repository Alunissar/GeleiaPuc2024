using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingHandler : MonoBehaviour
{

    public List<IngredientScriptable> recipe = new List<IngredientScriptable>();
    public List<int> slots = new List<int>();

    public int maxIngredients;
    public int minIngredients;
    [SerializeField] GameObject foodPrefab;
    [SerializeField] GameObject foodList;

    PanShow panShow;

    // Start is called before the first frame update
    void Start()
    {
        panShow = GetComponent<PanShow>();
    }

    public void AddIngredient(IngredientScriptable newIngredient, int slot)
    {
        //Adding ingredient to recipe
        recipe.Add(newIngredient);
        slots.Add(slot);
        panShow.ShowIngredients();
    }

    public void FinishRecipe()
    {
        //Checking if minimal ingredients are reached
        if (recipe.Count >= minIngredients)
        {
            //Creating the food and getting component
            Food _food = Instantiate(foodPrefab, foodList.transform).GetComponent<Food>();

            //Going through all ingredients
            for (int i = 0; i < recipe.Count; i++)
            {
                //Sending recipe to the food
                _food.ingredients.Add(recipe[i]);
            }

            //Clearing recipe
            recipe.Clear();
            slots.Clear();
            panShow.HideIngredients();
        }
    }

    public void ClearRecipe()
    {
        //Going through all ingredients
        for (int i = 0;i < recipe.Count;i++)
        {
            //Returning ingredients to the inventory
            Inventory.Instance.ReturnIngredient(slots[i]);
        }

        //Clearing recipe
        recipe.Clear();
        slots.Clear();
        panShow.HideIngredients();
    }

}
