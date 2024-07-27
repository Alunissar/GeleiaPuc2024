using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowInfo : MonoBehaviour
{
    public static Action<ShowInfo> slotHover;
    public static Action<ShowInfo> slotLeft;

    InventorySlot slot;
    public IngredientScriptable ingredient;


    public enum Side
    {
        Left = -1,
        Right = 1
    }

    //Hold if is to be shown on right
    public Side side;

    // Start is called before the first frame update
    void Start()
    {
        //Getting Inventory component
        slot = GetComponent<InventorySlot>();
        //Getting ingredient
        ingredient = slot.ingredient;
    }

    public void Hover()
    {
        slotHover?.Invoke(this);
    }
    public void Exit()
    {
        slotLeft?.Invoke(this);
    }

}
