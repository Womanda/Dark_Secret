using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootZipline : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HookSpot"))
        {
            Debug.Log("Yo");
        }
    }
    public void LessGoo()
    {
        Debug.Log("You pressed trigger");
    }
}
