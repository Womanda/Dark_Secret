using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PadPuzzle : MonoBehaviour
{
    //generell int för att följa puzzle framsteg
    public int padPuzzleProgress;
    //bool startar countdown
    private bool clockActive;
    //gömm clockan först och sätt sedan på den vid första rätta intryck
    public GameObject clock;


    //Timer grejer
    public int Duration { get; private set; }
    private int remainingDuration;
    //Grab Clock 
    public Text text;

    void Start()
    {
        clock.SetActive(false);
        clockActive = false;
        padPuzzleProgress = 0;
    }

    public void puzzleProgress()
    {
        if (!clockActive)
        {
            clockActive = true;
            clock.SetActive(true);
            SetDuration(8);
            Begin();
        }
        padPuzzleProgress++;
    }

    public void puzzleReset()
    {
        padPuzzleProgress = 0;
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
    }

    //om du löser puzzlet innan tiden tagit slut
    public void winConditionMet()
    {
        Debug.Log("you won the padgame!");
        StopAllCoroutines();
    }

}
