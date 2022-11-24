using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Events;
using BNG;

public class ShootZipline : MonoBehaviour
{
    public GameObject Head;
    public GameObject GunGrab;
    public ClipOnZipline clip;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ZiplineHead"))
        {
            Destroy(GunGrab.GetComponent<ZiplineShoot>());
            Destroy(GunGrab.GetComponent<Grabbable>());
            Destroy(GunGrab.GetComponent<CapsuleCollider>());
            Destroy(Head.GetComponent<Animator>());
            clip.Attached = true;
            Debug.Log("HIT!");

        }
    }

}
