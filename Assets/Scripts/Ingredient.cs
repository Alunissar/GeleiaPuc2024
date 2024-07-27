using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{

    public IngredientScriptable ingredient;
    public int slot;

    private GameObject pan;

    private bool inPan = false;

    // Start is called before the first frame update
    void Start()
    {
        
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
                //Adding ingredient to the pan
                pan.GetComponent<CookingHandler>().AddIngredient(ingredient);
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
