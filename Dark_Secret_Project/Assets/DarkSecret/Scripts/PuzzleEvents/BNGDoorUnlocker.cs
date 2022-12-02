using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

public class BNGDoorUnlocker : MonoBehaviour
{
    [SerializeField]
    DoorHelper doorHelper;

    public void Unlock(bool value)
    {
        doorHelper.DoorIsLocked = value;
    }
}
