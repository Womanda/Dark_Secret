using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGameScript : MonoBehaviour
{
    //Mr. Boll
    public GameObject Ball;
    //nummer bollen st�r p�
    private int currentNumber;
    //l�gg till nummer
    private int AddNumber;
    //Antal slots (dont touch!)
    public GameObject[] Slots;

    void Start()
    {
        currentNumber = 1;

        //S� att bollen startar p� r�tt plats
        UpdateBallPos();
    }

    public void moveBallRight()
    {
        if(currentNumber == 9)
        {
            currentNumber += 3;
            UpdateBallPos();
        }
        else if (currentNumber == 10 || currentNumber == 13)
        {
            currentNumber += 2;
            UpdateBallPos();
        }
        else if (currentNumber == 1 || currentNumber == 3)
        {
            currentNumber += 1;
            UpdateBallPos();
        }

    }
    public void moveBallDown()
    {
        if (currentNumber == 15)
        {
            currentNumber -= 12;
            UpdateBallPos();
        }
        else if (currentNumber == 13 || currentNumber == 10)
        {
            currentNumber -= 8;
            UpdateBallPos();
        }
        else if (currentNumber ==  9)
        {
            currentNumber -= 4;
            UpdateBallPos();
        }
    }
    public void moveBallLeft()
    {
        if (currentNumber == 12)
        {
            currentNumber -= 3;
            UpdateBallPos();
        }
        else if (currentNumber == 15)
        {
            currentNumber -= 2;
            UpdateBallPos();
        }
        else if (currentNumber == 4 || currentNumber == 2 || currentNumber == 10)
        {
            currentNumber -= 1;
            UpdateBallPos();
        }
    }
    public void moveBallUp()
    {
        if (currentNumber == 3)
        {
            currentNumber += 12;
            UpdateBallPos();
        }
        else if (currentNumber == 2 || currentNumber == 5)
        {
            currentNumber += 8;
            UpdateBallPos();
        }
        else if (currentNumber == 9 || currentNumber == 4)
        {
            currentNumber += 4;
            UpdateBallPos();
        }
    }

    //parentar bollen till nummer och uppdaterar sedan bollens position till r�tt st�llen
    void UpdateBallPos()
    {
        Ball.transform.SetParent(Slots[currentNumber].transform);
        Ball.transform.localPosition = new Vector3(0, 0, 0);
    }

}
