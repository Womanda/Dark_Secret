using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PadPuzzle : MonoBehaviour
{
    //generell int för att följa puzzle framsteg
    public int padPuzzleProgress;
    //bool startar countdown
    public bool clockActive;
    //gömm clockan först och sätt sedan på den vid första rätta intryck
    public GameObject clock;

    //grab button script

    public ButtonDissabler[] BtnDsl;

    //-----------Timer grejer----------------
    public int Duration { get; private set; }
    private int remainingDuration;
    //UI för klockan 
    public Text text;
    //pussel start bool
    public bool puzzleActive;

    //stänger av allt vid start
    void Start()
    {
        puzzleActive = false;
        clock.SetActive(false);
        clockActive = false;
        padPuzzleProgress = 0;
    }

    //första knappen agerar som startare och eller som bara plus 1 progress
    public void initiatePuzzle()
    {
        if (!puzzleActive && !clockActive)
        {
            puzzleActive = true;
            clockActive = true;
            clock.SetActive(true);
            SetDuration(360);
            Begin();
            padPuzzleProgress++;
        }
        else
        {
            padPuzzleProgress++;
        }
    }

    public void puzzleProgress()
    {
        if (clockActive && puzzleActive)
        {
            padPuzzleProgress++;
        }
    }

    public void puzzleReset()
    {
        if (puzzleActive && clockActive)
        {
            remainingDuration -= 30;
            if (remainingDuration > 29)
            {
                UpdateUI(remainingDuration);
            }
            else
            {
                UpdateUI(0);
            }
            padPuzzleProgress = 0;
            for (int i = 0; i < BtnDsl.Length; i++)
            {
                BtnDsl[i].Resetfunctionality();
            }
        }
    }

    public PadPuzzle SetDuration(int seconds)
    {
        Duration = remainingDuration = seconds;
        return this;
    }

    //starta klockan
    public void Begin()
    {
        StartCoroutine(UpdateTimer());
    }

    //uppdaterar klockan varje sekund när klockan är 0 call timerranout
    private IEnumerator UpdateTimer()
    {
        while (remainingDuration > 0)
        {
            UpdateUI(remainingDuration);
            remainingDuration--;
            yield return new WaitForSeconds(1f);
        }
        TimerRanOut();
    }

    //Formaterar texten till ett minuter:sekunder format
    private void UpdateUI(int seconds)
    {
        text.text = string.Format("{0:D2}:{1:D2}", seconds / 60, seconds % 60);
    }

    //När tiden tagit slut naturally gör följande
    public void TimerRanOut()
    {
        Debug.Log("Timer ran out");
        text.text = "00:00";
        Duration = remainingDuration = 0;
        clockActive = false;
    }

    //om du löser puzzlet innan tiden tagit slut
    public void winConditionMet()
    {
        if (puzzleActive && padPuzzleProgress == 11)
        {
            Debug.Log("you won the padgame!");
            puzzleActive = false;
            StopAllCoroutines();
        }
    }

}
