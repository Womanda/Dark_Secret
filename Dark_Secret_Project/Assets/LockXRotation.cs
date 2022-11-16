using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

public class LockXRotation : MonoBehaviour
{
    private bool IsLock;
    private void Start()
    {
        IsLock = false;
    }

    public JointHelper joint;
    public void Lock()
    {
        if (!IsLock)
        {
            IsLock = true;
            IsLock = joint.LockXRotation;
            Debug.Log("Now");
        }
        else if(IsLock)
        {
            IsLock = false;
            IsLock = joint.LockXRotation;
            Debug.Log("Here-Unlock");
        }
    }
    private void Update()
    {
        Debug.Log(IsLock);
    }

}
