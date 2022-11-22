using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadPuzzle : MonoBehaviour
{
    //generell int för att följa puzzle framsteg
    public int padPuzzleProgress;
    //bool startar countdown
    private bool clockActive;
    //gömm clockan först och sätt sedan på den vid första rätta intryck
    public GameObject clock;

    void Start()
    {
        clock.SetActive(false);
        clockActive = false;
        padPuzzleProgress = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void puzzleProgress()
    {
        if (!clockActive)
        {
            clockActive = true;
            clock.SetActive(true);
        }
        padPuzzleProgress++;
    }

    public void puzzleReset()
    {
        padPuzzleProgress = 0;
    }

}
