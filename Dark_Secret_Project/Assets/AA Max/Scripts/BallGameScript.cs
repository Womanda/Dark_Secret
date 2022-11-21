using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGameScript : MonoBehaviour
{
    //Mr. Boll
    public GameObject Ball;
    //nummer bollen st�r p�
    private int currentNumber;
    //Antal slots (dont touch!)
    public GameObject[] Slots;
    //speed p� boll
    public float ballSpeed = 1;
    //nollpunkt
    //public Vector3 Noll = new Vector3(0,0,0);
    private bool ballMove;
    void Start()
    {
        currentNumber = 1;


        //S� att bollen startar p� r�tt plats
        UpdateBallPos();
    }
    //Positionen p� parenten till bollen �r nollpunkten 
    private void Update()
    {
        //flyttar bollen till active slot
        if(ballMove)
        {
            Ball.transform.localPosition = Vector3.MoveTowards(Ball.transform.localPosition, Slots[currentNumber].transform.localPosition, ballSpeed * Time.deltaTime);
        }
        if (Ball.transform.localPosition == Slots[currentNumber].transform.localPosition)
        {
            ballMove = false;
        }
    }

    public void moveBallRight()
    {
        if (!ballMove)
        {
            if (currentNumber == 9)
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
    }
    public void moveBallDown()
    {
        if (!ballMove)
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
            else if (currentNumber == 9)
            {
                currentNumber -= 4;
                UpdateBallPos();
            }
        }
    }
    public void moveBallLeft()
    {
        if (!ballMove)
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
    }
    public void moveBallUp()
    {
        if (!ballMove)
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
    }

    //enablar move
    void UpdateBallPos()
    {
        ballMove = true;
    }
}
