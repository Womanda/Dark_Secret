using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttondissabler : MonoBehaviour
{
    //h�mtar knappens rigidbody
    private Rigidbody rb;

    //h�mtar scriptet padpPuzzle.cs
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
            //knappen stannar nedtryckt n�r man klickar tills man resettar
            rb.constraints = RigidbodyConstraints.FreezePositionY;
        }
    }


    public void Resetfunctionality()
    {
        //knappen �ker upp igen s� man kan klicka p� den
        rb.constraints = RigidbodyConstraints.None;
    }

}
