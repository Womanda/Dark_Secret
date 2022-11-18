using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Activator : MonoBehaviour
{
    [SerializeField]
    int activationKey;

    [SerializeField]
    int stepsToActivate;

    int currentStep = 0;

    public OnActivation activation;
    
    void Start()
    {
        GameEvents.current.onActivation += Atctivate;
        if(activation == null)
        {
            activation = new OnActivation();
        }
    }

    private void Atctivate(int arg1, int arg2)
    {
        if(arg1 == activationKey)
        {
            currentStep += arg2;
        }
        if(stepsToActivate == currentStep)
        {
            activation.Invoke();
        }
        
    }

    private void OnDisable()
    {
        GameEvents.current.onActivation -= Atctivate;
    }


}
[System.Serializable]
public class OnActivation : UnityEvent
{

}


