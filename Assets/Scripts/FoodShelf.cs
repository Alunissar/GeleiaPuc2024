using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodShelf : MonoBehaviour
{

    [SerializeField] int rows;
    [SerializeField] int cols;

    [SerializeField] float gapX;
    [SerializeField] float gapY;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //DEBUUUUUUUUUUUG PLMDS
        Organize();
    }

    public void Organize()
    {
        //Getting the start position
        float _x = transform.position.x;
        float _y = transform.position.y;
        float _z = transform.position.z;

        int food = 0;

        //Running through all rows
        for (int i = 0; i < rows; i++)
        {
            //Running through all cols
            for (int j = 0; j < cols; j++)
            {
                food++;

                //Checking if has enough food
                if (food <= transform.childCount)
                {
                    //Moving the food to the desired position
                    transform.GetChild(food-1).transform.position = new Vector3(_x + (gapX * j), _y + (gapY * i), _z);
                }
            }
            
        }
    }

}
