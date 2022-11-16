using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

public class LockXRotation : MonoBehaviour
{
    public bool IsLock;
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
            Debug.Log("Lock X Rotation now");
        }

    }
    private void Update()
    {
        //Debug.Log(IsLock);
    }

}
