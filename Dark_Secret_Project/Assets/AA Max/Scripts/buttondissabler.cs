using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttondissabler : MonoBehaviour
{
    public BoxCollider bC;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void buttonPressed()
    {
        rb.constraints = RigidbodyConstraints.FreezePositionY;
        //bC.enabled = false;
    }

    public void Resetfunctionality()
    {
        rb.constraints = RigidbodyConstraints.None;
        bC.enabled = true;
    }

}
