using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanShow : MonoBehaviour
{

    CookingHandler pan;
    public List<IngredientScriptable> ingredients = new List<IngredientScriptable>();
    [SerializeField] Image ingredientPanel;

    // Start is called before the first frame update
    void Start()
    {
        //Getting reference to the pan's script
        pan = GetComponent<CookingHandler>();
        ingredients = pan.recipe;
    }

    public void ShowIngredients()
    {
        //Enabling Panel
        ingredientPanel.gameObject.SetActive(true);

        //Going through all ingredients
        for (int i = 0; i < ingredientPanel.transform.childCount; i++)
        {
            //Checking if doesn't have this ingredient
            if (i >= ingredients.Count)
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
}
