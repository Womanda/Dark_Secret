using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttondissabler : MonoBehaviour
{
    //hämtar knappens rigidbody
    private Rigidbody rb;

    //hämtar scriptet padpPuzzle.cs
    public PadPuzzle padPzl;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void buttonPressed()
    {
        if (padPzl.puzzleActive && padPzl.clockActive)
        {
            //knappen stannar nedtryckt när man klickar tills man resettar
            rb.constraints = RigidbodyConstraints.FreezePositionY;
        }
    }


    public void Resetfunctionality()
    {
        //knappen åker upp igen så man kan klicka på den
        rb.constraints = RigidbodyConstraints.None;
    }

}
