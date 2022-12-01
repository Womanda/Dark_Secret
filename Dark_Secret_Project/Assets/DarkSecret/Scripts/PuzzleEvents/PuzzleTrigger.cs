using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleTrigger : MonoBehaviour
{
    [SerializeField]
    int triggerKey;

    [SerializeField]
    int triggerPower = 1;

   public void TriggerEvent()
    {
        GameEvents.current.Activation(triggerKey, triggerPower);
    }
}
