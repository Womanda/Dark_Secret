using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBlock : MonoBehaviour
{
    GameObject thisGameObject;
    [SerializeField]
    bool[] gate = new bool[4];

    [SerializeField]
    bool powered = false;
    // Start is called before the first frame update
    void Start()
    {
        thisGameObject = gameObject;
    }

    private void Update()
    {
        if (!powered)
            return;
    }

    public void RotateBlock()
    {
        bool pGate = false;
        Debug.Log(pGate);
        for (int i = 0; i < gate.Length; i++)
        {
            if (gate[i] && !pGate)
            {
                pGate = true;
                gate[i] = false;
                Debug.Log(pGate);
            }
            else if(!gate[i] && pGate)
            {
                pGate = false;
                gate[i] = true;
                Debug.Log(pGate);
            }
            if(i == gate.Length -1 && pGate)
            {
                pGate = false;
                gate[0] = true;
                Debug.Log(pGate);
            }
            Debug.Log(i + " is: " + gate[i]);
        }
        thisGameObject.transform.Rotate(Vector3.up * 90.0f);
    }
}
