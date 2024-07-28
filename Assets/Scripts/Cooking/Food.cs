using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Food : MonoBehaviour
{

    public List<IngredientScriptable> ingredients = new List<IngredientScriptable>();

    //Gets if is holding some food
    static bool holding = false;

    bool isFollowing = false;

    bool canHold = true;

    bool ontop = false;

    Vector3 lastPosition;

    // Start is called before the first frame update
    void Start()
    {
        //Removing ingredients count from game manager
        GameManager.Instance.ingredientsNumber -= ingredients.Count;

        lastPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(isFollowing)
        {

            //Following Mouse
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            //Checking if mouse was released
            if (Input.GetMouseButtonUp(0))
            {
                if (!ontop)
                {
                
                    holding = false;
                    isFollowing = false;

                    //Returning to last position
                    transform.position = lastPosition;

                }
            }

        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        //Checking if it's a food
        if (collision.CompareTag("Client"))
        {
             ontop = true;
            //Checking if released mouse
            if (!Input.GetMouseButton(0) && isFollowing)
            {
                //Checking if client hasn't eaten yet
                if (!collision.GetComponent<Client>().eaten)
                {
                    SoundManager.instance.PlayBite();

                    //Passing ingredients
                    collision.GetComponent<Client>().GetFood(ingredients);

                    holding = false;

                    //Destroying food
                    Destroy(gameObject);
                }
                else
                {
                    holding = false;
                    isFollowing = false;

                    //Returning to last position
                    transform.position = lastPosition;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ontop = false;
    }

    private void OnDestroy()
    {
        if (holding)
        {
            holding = false;
        }
    }

    private void OnMouseOver()
    {

        //Checking if cliked ontop of food
        if(Input.GetMouseButtonDown(0))
        {
            //Checking if it's at the deliver state
            if(GameManager.Instance.currentDayState == GameManager.DayState.Deliver)
            {
                //Checking if not holding other things
                if(!holding && canHold)
                {
                    //Storing current position
                    lastPosition = transform.position;

                    isFollowing = true;
                    holding = true;
                }
            }
        }
    }
}
