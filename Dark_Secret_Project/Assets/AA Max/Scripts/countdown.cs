using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class countdown : MonoBehaviour
{
    [SerializeField] PadPuzzle timer1;

    private void Start()
    {
        timer1.SetDuration(4).Begin();
    }

}
