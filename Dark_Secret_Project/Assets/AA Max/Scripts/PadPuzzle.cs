using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadPuzzle : MonoBehaviour
{
    //generell int f�r att f�lja puzzle framsteg
    public int padPuzzleProgress;
    //bool startar countdown
    private bool clockActive;
    //g�mm clockan f�rst och s�tt sedan p� den vid f�rsta r�tta intryck
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
