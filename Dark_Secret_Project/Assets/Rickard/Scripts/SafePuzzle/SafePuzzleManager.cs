using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafePuzzleManager : MonoBehaviour
{
    [SerializeField]
    float[] code;

    [SerializeField]
    float currentNumber;

    [SerializeField]
    float previousNumber;

    [SerializeField]
    bool clockwise = true;

    [SerializeField]
    int codeIndex = 0;

    

    PuzzleTrigger puzzleTrigger;
    void Start()
    {
        puzzleTrigger = GetComponent<PuzzleTrigger>();
    }

    public void UpdateNumber(float value)
    {
        previousNumber = currentNumber;
        currentNumber = value;
        ProgressCheck();

    }

    public void ProgressCheck()
    {

        if (currentNumber == code[codeIndex] && CheckClockwise(codeIndex))
        {

            if (codeIndex == code.Length - 1)
                finishPuzzle();
            if (codeIndex < code.Length - 1)
                codeIndex++;
            

        }
        else if (currentNumber == code[codeIndex] || Overstep(codeIndex))
        {
            codeIndex = 0;
        }
    }

    void finishPuzzle()
    {
        puzzleTrigger.TriggerEvent();
    }

    public bool AlternatingClockwise(int index)
    {
        if (index % 2 == 0)
        {
            clockwise = true;
        }
        else
            clockwise = false;
        return clockwise;
    }

    public bool CheckClockwise(int index)
    {
        if (AlternatingClockwise(index) && previousNumber < currentNumber)
        {
            return true;
        }
        else if (!AlternatingClockwise(index) && previousNumber > currentNumber)
        {
            return true;
        }
        else
            return false;
    }

    public bool Overstep(int index)
    {
        int tempIndex;
        if (index == 0)
        {
            tempIndex = 0;
        }
        else
            tempIndex = index - 1;
        if (!AlternatingClockwise(index) && currentNumber > code[tempIndex] && previousNumber == code[tempIndex])
            return true;
        else if (AlternatingClockwise(index) && currentNumber < code[tempIndex] && previousNumber == code[tempIndex])
            return true;
        else
            return false;
    }
}
