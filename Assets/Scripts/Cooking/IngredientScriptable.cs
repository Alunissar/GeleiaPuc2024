using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum FoodType
{
    Proteina,
    Legume,
    Grao,
    Fruta,
    Verdura,
    Alface,
    Arroz,
    Batata,
    Carne,
    Cenoura,
    Brocolis,
    Feijao,
    Laranja,
    Mandioca,
    Ovo,
    Soja,
    Tomate
}

[CreateAssetMenu(fileName = "Ingredient", menuName = "Ingredients", order = 1)]
public class IngredientScriptable : ScriptableObject
{
    public string ingredientName;
    public FoodType[] tags;
    public Sprite icon; 
    public int quantity;
    public int price;
    //Number of days to get bad
    public int durability;
}
