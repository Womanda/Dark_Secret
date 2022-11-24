using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipOnZipline : MonoBehaviour
{
    public GameObject ZipClipper;
    public bool Attached;
    private void Start()
    {
        Attached = false;
        ZipClipper.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Clipper") && Attached)
        {
            Destroy(other.gameObject);
            Debug.Log("Clipped");
            ZipClipper.SetActive(true);
        }
    }
}
