using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintEvents : MonoBehaviour
{
    [SerializeField]
    private int[] listenToKeys;

    [SerializeField]
    private int[] keyIndexToPage;

    [SerializeField]
    DisplayHints dHints;

    private void OnEnable()
    {
        GameEvents.current.onActivation += ActivatePage;
    }
    private void OnDisable()
    {
        GameEvents.current.onActivation -= ActivatePage;
    }

    private void ActivatePage(int key, int step)
    {
        for (int i = 0; i < listenToKeys.Length; i++)
        {
            if(key == listenToKeys[i])
            {
                dHints.ActivatePage(keyIndexToPage[i]);
            }
        }
    }
}
