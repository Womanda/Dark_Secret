using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public float transitionTime = 2f;
    
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
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }
    IEnumerator LoadLevel(int levelIndex)
    {
        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}
