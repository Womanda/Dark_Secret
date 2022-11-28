using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;
public class KeyHole : MonoBehaviour
{
    [SerializeField]
    GameObject keyInHole;

    [SerializeField]
    Grabbable knob;

    Rigidbody rbknob;

    [SerializeField]
    PuzzleTrigger puzzleTrigger;

    private void Start()
    {
        rbknob = knob.gameObject.GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Key"))
        {
            keyInHole.SetActive(true);
            other.gameObject.SetActive(false);
            knob.enabled = true;
            rbknob.constraints = RigidbodyConstraints.None;
        }
    }

    public void UnlockDoor(float value)
    {
        if(value > 170 && value < 190)
        {
            rbknob.constraints = RigidbodyConstraints.FreezeRotation;
            knob.enabled = false;
            puzzleTrigger.TriggerEvent();
        }
    }
}
