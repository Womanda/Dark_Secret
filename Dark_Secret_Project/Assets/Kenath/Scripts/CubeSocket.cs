using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSocket : MonoBehaviour
{
    [SerializeField]
    private Cube.CubeColor cubeId;

    private void OnTriggerEnter(Collider other)
    {
        var cube = other.GetComponent<Cube>();

        if (cube != null && cube.CubeId == cubeId)
        {
            Debug.Log("The Cube was correct.");
        }

        else
        {
            Debug.Log("The Cube is on the wrong socket.");
        }

    }
}
