using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

public class FadeScript : MonoBehaviour
{
    public ScreenFader scrnFader;

    private bool CCStart;

    // Start is called before the first frame update
    void Start()
    {
        CCStart = false;
    }

    public void fadeFunc()
    {
        if (!CCStart)
        {
            scrnFader.DoFadeIn();
            StartCoroutine(fadeWait());
            CCStart = true;
        }
    }
    IEnumerator fadeWait()
    {
        yield return new WaitForSecondsRealtime(0.6f);
        scrnFader.DoFadeOut();
        CCStart = false;
    }
}
