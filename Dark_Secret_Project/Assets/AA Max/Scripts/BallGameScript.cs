using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGameScript : MonoBehaviour
{
    public GameObject Ball;
    public GameObject SpotOne;

    void Start()
    {
        List<Slots> slotPos = new List<Slots>();

        slotPos.Add(new)

        Ball.transform.SetParent(SpotOne.transform);
        Ball.transform.localPosition = new Vector3(0, 0, 0);
    }

    public void moveBallRight()
    {

    }
}
