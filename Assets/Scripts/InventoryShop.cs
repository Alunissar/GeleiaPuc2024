using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class InventoryShop : MonoBehaviour
{

    [SerializeField] GameObject slotPrefab;
    [SerializeField] GameObject container;

    List<InventorySlot> slots = new List<InventorySlot>();

    // Start is called before the first frame update
    void Start()
    {
        //Going through all ingredients
        for(int i = 0; i < GameManager.Instance.ingredients.Count; i++)
        {
            slots.Add(Instantiate(slotPrefab, container.transform).GetComponent<InventorySlot>());
            slots[i].ingredient = GameManager.Instance.ingredients[i];
        }        
    }

    public void UpdateText()
    {
        for (int i = 0;i < slots.Count;i++)
        {
            slots[i].UpdateText();
        }
    }

}
