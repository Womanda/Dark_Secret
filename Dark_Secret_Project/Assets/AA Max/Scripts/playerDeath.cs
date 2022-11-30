using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using BNG;

public class playerDeath : MonoBehaviour
{
    public SceneInfo Sceneinfo;
    public ScreenFader scrnFade;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(FadeCo());
            scrnFade.DoFadeIn();
            /*
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.buildIndex + 1);
            */
        }
    }

    IEnumerator FadeCo()
    {
        yield return new WaitForSeconds(0.6f);
        SceneManager.LoadScene(6);
    }
}
