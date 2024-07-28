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

    [SerializeField] int maxFood;

    PanShow panShow;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        panShow = GetComponent<PanShow>();
        animator = GetComponent<Animator>();
    }

    public void AddIngredient(IngredientScriptable newIngredient, int slot)
    {
        SoundManager.instance.PlaySFX(SoundManager.instance.sounds[1]);

        //Adding ingredient to recipe
        recipe.Add(newIngredient);
        slots.Add(slot);
        panShow.ShowIngredients();
    }

    public void FinishRecipe()
    {
        //Checking if minimal ingredients are reached && there is space to store food
        if (recipe.Count >= minIngredients && foodList.transform.childCount < maxFood)
        {
            SoundManager.instance.PlaySFX(SoundManager.instance.sounds[0]);
            animator.SetTrigger("Cook");
        }
    }

    public void MakeFood()
    {

        //Creating the food and getting component
        Food _food = Instantiate(foodPrefab, foodList.transform).GetComponent<Food>();
        foodList.GetComponent<FoodShelf>().Organize();

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
