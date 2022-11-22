using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadPuzzle : MonoBehaviour
{
    //generell int för att följa puzzle framsteg
    public int padPuzzleProgress;
    //boll startar countdown

    void Start()
    {
        padPuzzleProgress = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void puzzleProgress()
    {
        padPuzzleProgress++;
        gameObject.SetActive(false);
    }

    public void puzzleReset()
    {
        padPuzzleProgress = 0;
    }

}
