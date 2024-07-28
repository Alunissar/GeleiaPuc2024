using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : MonoBehaviour
{
    public List<FoodType> likes;
    public List<FoodType> dislikes;

    //Keeps what food has already been counted
    List<FoodType> inFood = new List<FoodType>();

    //Gets how much the client liked the food
    int taste = 0;

    private void Start()
    {
        inFood.Clear();
        taste = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetFood(List<IngredientScriptable> ingredients)
    {
        //reset taste
        taste = 0;

        //Running through all ingredients
        for (int i = 0; i < ingredients.Count; i++)
        {
            //Running through all tags
            for (int j = 0; j < ingredients[i].tags.Length; j++)
            {
                //Checking if food has already been counted
                if(!inFood.Contains(ingredients[i].tags[j]))
                {
                    //Checking if Client likes this ingredient
                    if (likes.Contains(ingredients[i].tags[j]))
                    {
                        //Adding to taste
                        taste++;
                    }

                    //Adding tag to in food list
                    inFood.Add(ingredients[i].tags[j]);

                }

                //Checking if Client dislikes this ingredient
                if (dislikes.Contains(ingredients[i].tags[j]))
                {
                    //Removing from taste
                    taste--;
                }
            }
        }

        GameManager.Instance.GetFeedback(taste);

        //Triggers dialogue according to taste
        ClientManager.Instance.DeliveryDialogue(taste);
    }

    

}
