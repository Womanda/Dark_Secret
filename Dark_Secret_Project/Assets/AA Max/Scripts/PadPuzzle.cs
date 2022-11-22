using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PadPuzzle : MonoBehaviour
{
    //generell int f�r att f�lja puzzle framsteg
    public int padPuzzleProgress;
    //bool startar countdown
    private bool clockActive;
    //g�mm clockan f�rst och s�tt sedan p� den vid f�rsta r�tta intryck
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

    //uppdaterar klockan varje sekund n�r klockan �r 0 call timerranout
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

    //N�r tiden tagit slut naturally g�r f�ljande
    public void TimerRanOut()
    {
        Debug.Log("Timer ran out");
        text.text = "00:00";
        Duration = remainingDuration = 0;
    }

    //om du l�ser puzzlet innan tiden tagit slut
    public void winConditionMet()
    {
        Debug.Log("you won the padgame!");
        StopAllCoroutines();
    }

}
