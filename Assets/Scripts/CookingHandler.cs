using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingHandler : MonoBehaviour
{

    public List<IngredientScriptable> recipe = new List<IngredientScriptable>();

    [SerializeField] int maxIngredients;
    [SerializeField] GameObject foodPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddIngredient(IngredientScriptable newIngredient)
    {
        //Adding ingredient to recipe
        recipe.Add(newIngredient);

        //Checking if number of ingredients reached max
        if(recipe.Count >= maxIngredients)
        {
            FinishRecipe();
        }
    }

    private void FinishRecipe()
    {
        //Creating the food and getting component
        Food _food = Instantiate(foodPrefab, new Vector3(-1f, 0.3f, 0f), Quaternion.identity).GetComponent<Food>();
        
        //Going through all ingredients
        for (int i = 0; i < recipe.Count; i++)
        {
            //Sending recipe to the food
            _food.ingredients.Add(recipe[i]);
        }

        //Clearing recipe
        recipe.Clear();
    }

}
