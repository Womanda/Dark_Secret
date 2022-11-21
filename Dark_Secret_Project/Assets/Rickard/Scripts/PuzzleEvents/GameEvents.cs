using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;

    private void Awake()
    {
        current = this;
    }

    public event Action<int,int> onActivation;


    public void Activation(int index, int steps)
    {
        onActivation?.Invoke(index, steps);
    }

}
