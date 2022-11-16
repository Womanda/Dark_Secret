using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBlock : MonoBehaviour
{
    GameObject thisGameObject;
    [SerializeField]
    bool[] gate = new bool[4];

    bool[] powerdGate = new bool[4] { false, false, false, false };

    [SerializeField]
    bool powered = false;

    public int gridLocalX;
    public int gridLocalY;



    FuseGameManager  fuseGameManager;
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

    public void OnPush()
    {
        RotateBlock();
        fuseGameManager.UpdateBox();
    }
    public void RotateBlock()
    {
        bool pGate = false;
        
        for (int i = 0; i < gate.Length; i++)
        {
            if (gate[i] && !pGate)
            {
                pGate = true;
                gate[i] = false;
                
            }
            else if(!gate[i] && pGate)
            {
                pGate = false;
                gate[i] = true;
                
            }
            if(i == gate.Length -1 && pGate)
            {
                pGate = false;
                gate[0] = true;
                
            }
            
        }
        thisGameObject.transform.Rotate(Vector3.up * 90.0f);
    }

    public void AssigneManager(FuseGameManager fGM)
    {
        fuseGameManager = fGM;
    }

    public bool CheckStart()
    {
        if (gate[3])
            return true;
        else
            return false;
    }

    public bool CheckFinish()
    {
        if (gate[1] && powerdGate[2])
            return true;
        else
            return false;
    }

    public void CheckUp(PowerBlock pBlock)
    {
        Debug.Log("Checking up");
        if (pBlock.CheckGate(2) && gate[0] && powered)
        {
            pBlock.PowerUP(true);
            Debug.Log("Checking up, Got POWER on Gate 0" + " X = " + gridLocalX + " Y = " + gridLocalY);
        }
        else if(powered)
            pBlock.PowerUP(false);
    }
    public void CheckRight(PowerBlock pBlock)
    {
        Debug.Log("Checking Right");
        if (pBlock.CheckGate(3) && gate[1] && powered)
        {
            pBlock.PowerUP(true);
            Debug.Log("Checking Right, Got POWER on Gate 1" + " X = " + gridLocalX + " Y = " + gridLocalY);
        }
        else if(powered)
            pBlock.PowerUP(false);
    }
    public void CheckDown(PowerBlock pBlock)
    {
        Debug.Log("Checking Down");
        if (pBlock.CheckGate(0) && gate[2] && powered)
        {
            pBlock.PowerUP(true);
            Debug.Log("Checking Down, Got POWER on Gate 2" + " X = " + gridLocalX + " Y = " + gridLocalY);
        }
        else if (powered)
            pBlock.PowerUP(false);
    }
    public void CheckLeft(PowerBlock pBlock)
    {
        Debug.Log("Checking Left");
        if (pBlock.CheckGate(1) && gate[3] && powered)
        {
            pBlock.PowerUP(true);
            Debug.Log("Checking Left, Got POWER on Gate 3" + " X = " + gridLocalX + " Y = " + gridLocalY);
        }
        else if (powered)
            pBlock.PowerUP(false);
    }

    public void ResolvePoweredStatus()
    {
        int poweredGates = 0;
        for (int i = 0; i < powerdGate.Length; i++)
        {
            if (powerdGate[i])
                poweredGates++;
        }
        if (poweredGates < 2 && powered)
        {
            powered = false;
        }
        else if (poweredGates == 1 && !powered)
            powered = true;
        
    }

    public bool SnakeCheck(PowerBlock pBlock, int pathIndex)
    {
        int reverseIndex = pathIndex < 2 ? pathIndex + 2 : pathIndex - 2;
        if (gate[pathIndex] && pBlock.CheckGate(reverseIndex))
        {
            return true;
        }
        else
            return false;
    }

    public bool CheckGate(int index)
    {
        return gate[index];
    }
    public bool CheckPowered()
    {
        return powered;
    }

    public void PowerUP(bool value)
    {
        powered = value;
    }
}
