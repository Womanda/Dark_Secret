using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public float transitionTime = 2f;
    public ScreenFader screenFader;
    
    public GameObject Door;
    public GameObject Title;
    private void ExecuteTrigger(string trigger)
    {
        if (Door != null)
        {
            var animator = Door.GetComponent<Animator>();

            if (animator != null)
            {
                animator.SetTrigger(trigger);
            }
        }

        if (Title != null)
        {
            var animator = Title.GetComponent<Animator>();

            if (animator != null)
            {
                animator.SetTrigger(trigger);
            }
        }
    }

    public void OnButtonClick()
    {
        ExecuteTrigger("TriggerOpen");
        ExecuteTrigger("TriggerTitle");
    }
    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel());
    }
    IEnumerator LoadLevel()
    {
        yield return new WaitForSeconds(transitionTime);

        StartCoroutine(LoadScene());

        screenFader.DoFadeIn();
    }


    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(0.6f);
        SceneManager.LoadScene(1);
    }
}
