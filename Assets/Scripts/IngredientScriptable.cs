using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Ingredient", menuName = "Ingredients", order = 1)]
public class IngredientScriptable : ScriptableObject
{
    public string ingredientName;
    public string[] tags;
    public Sprite icon; 
    public int quantity;
}
