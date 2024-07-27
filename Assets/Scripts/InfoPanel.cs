using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfoPanel : MonoBehaviour
{

    string ingredientName;
    FoodType[] ingredientTags;

    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI tagsText;

    //X Offset from mouse
    [SerializeField] float paddingX;
    //Y Offset from mouse
    [SerializeField] float paddingY;

    private void Start()
    {
        ShowInfo.slotHover += GetInfo;
        ShowInfo.slotLeft += Disable;

        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePos();
    }

    private void GetInfo(ShowInfo slot)
    {
        gameObject.SetActive(true);

        //Getting ingredient name
        ingredientName = slot.ingredient.ingredientName;
        //Getting ingredient tags
        ingredientTags = slot.ingredient.tags;

        //Checking if padding has the same sign as slot side
        if(Mathf.Sign(paddingX) != (int)slot.side)
        {
            //Inverting padding
            paddingX *= -1;
        }

        UpdateTexts();



    }

    private void Disable(ShowInfo slot)
    {
        gameObject.SetActive(false);

        UpdatePos();

    }
    
    private void UpdateTexts()
    {
        //Updating name text
        nameText.text = ingredientName;

        string _text = "";
        //Going through all tags expect the first one
        for(int i = 1; i < ingredientTags.Length; i++)
        {
            //Adding ingredient to the text
            _text += ingredientTags[i] + "\n";
        }
        //Updating tags text
        tagsText.text = _text;
    }

    private void UpdatePos()
    {
        //Following mouse
        transform.position = new Vector3(Input.mousePosition.x + paddingX, Input.mousePosition.y + paddingY, Input.mousePosition.z);
    }

}
