using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    [SerializeField] List<IngredientScriptable> allIngredients = new List<IngredientScriptable>();
    List<GameObject> slotList = new List<GameObject>();

    [SerializeField] GameObject slotPrefab;
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
            GameObject _slot = Instantiate(slotPrefab, inventoryGrid.transform);
            //Adding slot to the list
            slotList.Add(_slot);
            //Passing ingredient to slot
            _slot.GetComponent<InventorySlot>().ingredient = allIngredients[i];
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
                slotList[i].SetActive(true);
            }
            else
            {
                slotList[i].SetActive(false);
            }
        } 
    }

}
