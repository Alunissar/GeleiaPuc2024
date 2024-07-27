using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : Singleton<Inventory>
{

    [SerializeField] List<IngredientScriptable> allIngredients = new List<IngredientScriptable>();
    List<InventorySlot> slotList = new List<InventorySlot>();

    [SerializeField] GameObject slotPrefab;
    [SerializeField] GameObject ingredientPrefab;
    [SerializeField] GameObject inventoryGrid;
    // Start is called before the first frame update
    void Start()
    {
        InitializeInventory();
        OrganizeInventory();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InitializeInventory()
    {
        //Running through all ingredients
        for (int i = 0; i < allIngredients.Count; i++)
        {
            //Instantiating slot as a prefab
            GameObject _slotObj = Instantiate(slotPrefab, inventoryGrid.transform);
            //Getting inventory slot script
            InventorySlot _slot = _slotObj.GetComponent<InventorySlot>();
            //Adding slot to the list
            slotList.Add(_slot.GetComponent<InventorySlot>());
            //Passing ingredient to slot
            _slot.ingredient = allIngredients[i];
        }
    }

    void OrganizeInventory()
    { 
        //Running through all the ingredients
       for(int i = 0; i < allIngredients.Count; i++)
        {
            //Checking if there are any of that ingredient
            if (allIngredients[i].quantity > 0)
            {
                slotList[i].gameObject.SetActive(true);
            }
            else
            {
                slotList[i].gameObject.SetActive(false);
            }
        } 
    }

    public void GetIngredient(int slot)
    {
        //Creating ingredient at mouse position
        GameObject _ingredientObj = Instantiate(ingredientPrefab, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
        //Getting Ingredient script
        Ingredient _ingredient = _ingredientObj.GetComponent<Ingredient>();

        //Passing values to ingredient created
        _ingredient.slot = slot;
        _ingredient.ingredient = allIngredients[slot];

        //Reducing quantity
        allIngredients[slot].quantity--;

        slotList[slot].UpdateText();

        //Checking quantity
        if (allIngredients[slot].quantity <= 0)
        {
            slotList[slot].gameObject.SetActive(false);
        }
    }

    public void ReturnIngredient(int slot)
    {
        //Adding quantity
        allIngredients[slot].quantity++;

        slotList[slot].UpdateText();

        //Checking quantity
        if (allIngredients[slot].quantity > 0)
        {
            slotList[slot].gameObject.SetActive(true);
        }
    }

}
