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

    [SerializeField]
    MeshRenderer renderer;

    [SerializeField]
    MeshRenderer[] cordRenderer;

    public int gridLocalX;
    public int gridLocalY;
    

    bool gameIsFInished = false;



    FuseGameManager  fuseGameManager;
    // Start is called before the first frame update
    void Start()
    {
        thisGameObject = gameObject;
        
    }

    public void ColorNoPower()
    {
        renderer.material.color = Color.red;
        for (int i = 0; i < cordRenderer.Length; i++)
        {
            cordRenderer[i].material.color = Color.white;
        }
    }

    public void ColorPowerOn()
    {
        renderer.material.color = Color.green;
        for (int i = 0; i < cordRenderer.Length; i++)
        {
            cordRenderer[i].material.color = Color.yellow;
        }
    }

    public void ColorFinish()
    {
        renderer.material.color = Color.blue;
        for (int i = 0; i < cordRenderer.Length; i++)
        {
            cordRenderer[i].material.color = Color.yellow;
        }
    }

    private void Update()
    {
     

    }

    public void OnPush()
    {
        if (!gameIsFInished)
        {
            RotateBlock();
            fuseGameManager.UpdateBox();
        }
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

    public void CheckStart()
    {
        if (gate[3])
            powered = true;
        else
            powered = false;
           
    }

    public bool CheckFinish()
    {
        if (gate[1] && powerdGate[2])
            return true;
        else
            return false;
    }
    public bool CheckDecoy()
    {
        if (gate[2] && powerdGate[3])
            return true;
        else
            return false;
    }

    public void CheckUp(PowerBlock pBlock)
    {
        Debug.Log("Checking up");
        if (pBlock.CheckGate(2) && gate[0] && pBlock.CheckPowered())
        {
            powerdGate[0] = true;
            Debug.Log("Checking up, Got POWER on Gate 0" + " X = " + gridLocalX + " Y = " + gridLocalY);
        }
        else if(powered)
            powerdGate[0] = false;
    }
    public void CheckRight(PowerBlock pBlock)
    {
        Debug.Log("Checking Right");
        if (pBlock.CheckGate(3) && gate[1] && pBlock.CheckPowered())
        {
            powerdGate[1] = true;
            Debug.Log("Checking Right, Got POWER on Gate 1" + " X = " + gridLocalX + " Y = " + gridLocalY);
        }
        else if(powered)
            powerdGate[1] = false;
    }
    public void CheckDown(PowerBlock pBlock)
    {
        Debug.Log("Checking Down");
        if (pBlock.CheckGate(0) && gate[2] && pBlock.CheckPowered())
        {
            powerdGate[2] = true;
            Debug.Log("Checking Down, Got POWER on Gate 2" + " X = " + gridLocalX + " Y = " + gridLocalY);
        }
        else if (powered)
            powerdGate[2] = false;
    }
    public void CheckLeft(PowerBlock pBlock)
    {
        Debug.Log("Checking Left");
        if (pBlock.CheckGate(1) && gate[3] && pBlock.CheckPowered())
        {
            powerdGate[3] = true;
            Debug.Log("Checking Left, Got POWER on Gate 3" + " X = " + gridLocalX + " Y = " + gridLocalY);
        }
        else if (powered)
            powerdGate[3] = false;
    }

    public void ResolvePoweredStatus()
    {
        int powerGate = 0;
        for (int i = 0; i < powerdGate.Length; i++)
        {
            if (powerdGate[i])
            {
                powerGate++;
            }
        }
        if (powerGate != 0)
        {
            powered = true;
        }
        else
        {
            powered = false;
        }
        
    }
    public void ResolveColors()
    {
        if (powered && !gameIsFInished)
        {
            ColorPowerOn();
        }
        if (!powered && !gameIsFInished)
        {
            ColorNoPower();
        }
        if (gameIsFInished && powered)
        {
            ColorFinish();
        }
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
        for (int i = 0; i < powerdGate.Length; i++)
        {
            powerdGate[i] = value;
        }
    }

    public void Finsish()
    {
        gameIsFInished = true;
    }
}
