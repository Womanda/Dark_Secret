using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class BallGameScript : MonoBehaviour
{
    //Mr. Boll
    public GameObject Ball;
    //Get drawers rigidbody to enable drawer functionality
    public Rigidbody DrawerRB;
    //nummer bollen står på
    private int currentNumber;
    //Antal slots (dont touch!)
    public GameObject[] Slots;
    //speed på boll
    public float ballSpeed = 1;
    //nollpunkt
    //public Vector3 Noll = new Vector3(0,0,0);
    private bool ballMove;
    //pusslet av eller på
    private bool puzzleActive;
    public Animator anim;
    void Start()
    {
        puzzleActive = true;
        currentNumber = 1;

        //Så att bollen startar på rätt plats
        UpdateBallPos();
    }
    //Positionen på parenten till bollen är nollpunkten 
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
        if (!ballMove && puzzleActive)
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
            else
            {
                anim.Play("BallWobbleRight");
            }
            
        }
    }
    public void moveBallDown()
    {
        if (!ballMove && puzzleActive)
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
            else
            {
                anim.Play("BallWobbleDown");
            }
        }
    }
    public void moveBallLeft()
    {
        if (!ballMove && puzzleActive)
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
            else
            {
                anim.Play("BallWobbleLeft");
            }
        }
    }
    public void moveBallUp()
    {
        if (!ballMove && puzzleActive)
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
            else if (currentNumber == 9)
            {
                currentNumber += 4;
                UpdateBallPos();
            }
            else if (currentNumber == 4)
            {
                currentNumber += 4;
                UpdateBallPos();
                DrawerRB.constraints = RigidbodyConstraints.None;
                Debug.Log("You Win");
                puzzleActive = false;
            }
            else
            {
                anim.Play("BallWobbleUp");
            }
        }
    }

    //enablar move
    void UpdateBallPos()
    {
        ballMove = true;
    }
}
