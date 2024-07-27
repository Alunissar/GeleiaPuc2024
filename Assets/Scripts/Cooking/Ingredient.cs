using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ingredient : MonoBehaviour
{

    public IngredientScriptable ingredient;
    public int slot;

    private GameObject pan;

    private bool inPan = false;

    [SerializeField] SpriteRenderer icon;

    // Start is called before the first frame update
    void Start()
    {
        //Updating sprite
        icon.sprite = ingredient.icon;
    }

    // Update is called once per frame
    void Update()
    {
        //Following Mouse
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //Checking if released ingredient
        if(Input.GetMouseButtonUp(0))
        {
            //Checking if ingredient is in pan
            if(inPan)
            {
                //Getting reference to cooking handler
                CookingHandler _pan = pan.GetComponent<CookingHandler>();
                //Checking if there is space in the pan
                if (_pan.recipe.Count < _pan.maxIngredients)
                {
                    //Adding ingredient to the pan
                    _pan.AddIngredient(ingredient, slot);
                }
                else
                {
                    //Returning ingredient to Inventory
                    Inventory.Instance.ReturnIngredient(slot);
                }
            }
            else
            {
                //Returning ingredient to Inventory
                Inventory.Instance.ReturnIngredient(slot);
            }
            
            //Destroying self
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Checking if colliding with pan
        if (collision.gameObject.CompareTag("Pan"))
        {
            //Checking if has pan reference
            if(pan == null)
            {
                pan = collision.gameObject;
            }

            inPan = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Checking if colliding with pan
        if (collision.gameObject.CompareTag("Pan"))
        {
            inPan = false;
        }
    }
}
