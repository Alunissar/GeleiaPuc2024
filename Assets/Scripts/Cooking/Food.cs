using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{

    public List<IngredientScriptable> ingredients = new List<IngredientScriptable>();

    //Gets if is holding some food
    static bool holding = false;

    bool isFollowing = false;

    bool canHold = true;

    Vector3 lastPosition;

    // Start is called before the first frame update
    void Start()
    {
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
                holding = false;
                isFollowing = false;

                //Returning to last position
                transform.position = lastPosition;

            }

        }
    }

    private void OnMouseOver()
    {
        Debug.Log("a");

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
