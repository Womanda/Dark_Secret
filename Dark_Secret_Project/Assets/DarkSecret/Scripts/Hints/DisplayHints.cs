using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DisplayHints : MonoBehaviour
{
    [SerializeField]
    GameObject mainMenu;
    [SerializeField]
    GameObject thisMenue;
    [SerializeField]
    private Hint[] hints;

    [SerializeField]
    private SceneHint[] sceneHints;
    
    

    [SerializeField]
    private TMP_Text displayText;

    [SerializeField]
    private int currentPage;

    private void Start()
    {
        currentPage = 0;
        for (int i = 0; i < sceneHints.Length; i++)
        {
            if(SceneManager.GetActiveScene().buildIndex == sceneHints[i].sceneIndex)
            {
                currentPage = sceneHints[i].pageID;
                ActivatePage(sceneHints[i].pageID);
            }
        }
        ShowHint(currentPage);
    }
    private void ShowHint(int page)
    {
        displayText.text = "";
        for (int i = 0; i < hints.Length; i++)
        {
            if(page == hints[i].hintID && hints[i].active)
            {
                hints[i].hintText += "\n";
                displayText.text += hints[i].hintText;
            }
        }
    }

    public void ActivatePage(int page)
    {
        for (int i = 0; i < hints.Length; i++)
        {
            if(page == hints[i].hintID)
            {
                hints[i].active = true;
            }
        }
    }

    public void NextPage()
    {
        bool lastPage = true;
        for (int i = 0; i < hints.Length; i++)
        {
            if (currentPage + 1 == hints[i].hintID && hints[i].active)
                lastPage = false;
           

            
        }
        if (!lastPage)
        {
            currentPage++;
            ShowHint(currentPage);
        }
        

    }
    public void PreviousPage()
    {
        if (currentPage == 0)
            BackToMain();
        if (currentPage > 0)
            currentPage--;

        ShowHint(currentPage);
    }
    
    private void BackToMain()
    {
        mainMenu.SetActive(true);
        thisMenue.SetActive(false);
    }
}
