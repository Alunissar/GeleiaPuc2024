using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shop : MonoBehaviour
{

    List<IngredientScriptable> products = new List<IngredientScriptable>();
    List<ShopSlot> slotList = new List<ShopSlot>();

    [SerializeField] GameObject slotPrefab;
    [SerializeField] GameObject inventoryGrid;

    // Start is called before the first frame update
    void Start()
    {
        //Getting the list of ingredients
        products = GameManager.Instance.ingredients;

        InitializeShop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InitializeShop()
    {
        //Running through all ingredients
        for (int i = 0; i < products.Count; i++)
        {
            //Instantiating slot as a prefab
            GameObject _slotObj = Instantiate(slotPrefab, inventoryGrid.transform);
            //Getting inventory slot script
            ShopSlot _slot = _slotObj.GetComponent<ShopSlot>();
            //Adding slot to the list
            slotList.Add(_slot.GetComponent<ShopSlot>());
            //Passing ingredient to slot
            _slot.ingredient = products[i];
        }
    }
}
