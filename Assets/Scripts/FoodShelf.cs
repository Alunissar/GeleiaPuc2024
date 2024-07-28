using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodShelf : MonoBehaviour
{

    int rows;
    int cols;

    float gapX;
    float gapY;

    [Header("Cooking State")]
    [SerializeField] int rowsC;
    [SerializeField] int colsC;

    [SerializeField] float gapXC;
    [SerializeField] float gapYC;

    [SerializeField] Vector3 posC;

    [Header("Deliver State")]
    [SerializeField] int rowsD;
    [SerializeField] int colsD;

    [SerializeField] float gapXD;
    [SerializeField] float gapYD;

    [SerializeField] Vector3 posD;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.changeDayState += ChangeState;

        //Initializing
        ChangeState(GameManager.Instance.currentDayState);
    }

    // Update is called once per frame
    void Update()
    {
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

    private void ChangeState(GameManager.DayState state)
    {
        switch(state)
        {
            case GameManager.DayState.Deliver:
                rows = rowsD;
                cols = colsD;

                gapX = gapXD;
                gapY = gapYD;

                transform.position = posD;

                break;

            case GameManager.DayState.Kitchen:
                rows = rowsC;
                cols = colsC;

                gapX = gapXC;
                gapY = gapYC;

                transform.position = posC;
                break;

            default:
                //Gowing to the casa do carai
                transform.position = new Vector3(-800, -1290, 0);
                break;
        }

        Organize();

    }

}
