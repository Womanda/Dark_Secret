using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuseGameManager : MonoBehaviour
{
    [SerializeField]
    GameObject fuseBlockOne;
    [SerializeField]
    GameObject fuseBlockTwo;
    [SerializeField]
    GameObject fuseBlockThree;
    [SerializeField]
    FuseLights lightDecoy;
    [SerializeField]
    FuseLights lightFinish;

    PuzzleTrigger puzzleTrigger;


    bool finish = false;
    bool decoy = false;

    int[,] spawnDecider = new int[3, 3]
    {
        {0,1,0 },
        {2,0,0 },
        {1,2,1 }
    };

    [SerializeField]
    PowerBlock[,] powerBlocks = new PowerBlock[3, 3];

    void Start()
    {
        puzzleTrigger = GetComponent<PuzzleTrigger>();
        for (int y = 0;  y < spawnDecider.GetLength(0);  y++)
        {
            for (int x = 0; x < spawnDecider.GetLength(1); x++)
            {
                MakeAChild(spawnDecider[y, x], y, x);
            }
        }

        StartCoroutine(InitBlocks());
    }

    IEnumerator InitBlocks()
    {
        yield return new WaitForSeconds(0.1f);
        powerBlocks[2, 0].OnPush();
        yield return new WaitForSeconds(0.1f);
        powerBlocks[2, 0].OnPush();
        yield return new WaitForSeconds(0.1f);
        powerBlocks[2, 0].OnPush();
        yield return new WaitForSeconds(0.1f);
        powerBlocks[2, 0].OnPush();
    }
   
   

  

    private void MakeAChild(int index, int y, int x)
    {
        GameObject a = Instantiate(TypeSelctor(index), new Vector3(0, 0, 0), Quaternion.identity);
        a.transform.parent = gameObject.transform;
        a.transform.localRotation = Quaternion.Euler(Vector3.forward * -90);
        a.transform.localPosition = new Vector3(0, y * -0.06f, x * 0.06f);
        powerBlocks[y, x] = a.GetComponent<PowerBlock>();
        powerBlocks[y, x].AssigneManager(this);
        powerBlocks[y, x].gridLocalX = x;
        powerBlocks[y, x].gridLocalY = y;
    }

    private GameObject TypeSelctor(int index)
    {
        if (index == 0)
            return fuseBlockOne;
        if (index == 1)
            return fuseBlockTwo;
        else
            return fuseBlockThree;
    }

    public void UpdateBox()
    {
        resetLoop();
        BlockLoop();
        BlockLoop();
        //BlockLoop();
       // BlockLoop();
        if (finish)
            FinnishLoop();
        DecoyLight(decoy);
        FinishLight(finish);

        ColorLoop();
    }

    

    private void BlockLoop()
    {
        for (int y = 0; y < powerBlocks.GetLength(0); y++)
        {
            for (int x = 0; x < powerBlocks.GetLength(1); x++)
            {
                if (y != 0)
                    powerBlocks[y, x].CheckUp(powerBlocks[y - 1, x]);
                if (y != powerBlocks.GetLength(0) - 1)
                    powerBlocks[y, x].CheckDown(powerBlocks[y + 1, x]);
                if (x != 0)
                    powerBlocks[y, x].CheckLeft(powerBlocks[y, x - 1]);
                if (x != powerBlocks.GetLength(1) - 1)
                    powerBlocks[y, x].CheckRight(powerBlocks[y, x + 1]);

                powerBlocks[y, x].ResolvePoweredStatus();
                

                if (y == 2 && x == 0)
                    powerBlocks[y, x].CheckStart();

                if (y == 0 && x == powerBlocks.GetLength(1) - 1)
                    finish = powerBlocks[y, x].CheckFinish();

                if (y == powerBlocks.GetLength(0) - 1 && x == 2)
                    decoy = powerBlocks[y, x].CheckDecoy();

            }
        }
        ReverseBlockLoop();

    }
    private void ReverseBlockLoop()
    {
        for (int y = powerBlocks.GetLength(0)-1; y >= 0; y--)
        {
            for (int x = powerBlocks.GetLength(1) -1; x >= 0; x--)
            {
                if (y != 0)
                    powerBlocks[y, x].CheckUp(powerBlocks[y - 1, x]);
                if (y != powerBlocks.GetLength(0) - 1)
                    powerBlocks[y, x].CheckDown(powerBlocks[y + 1, x]);
                if (x != 0)
                    powerBlocks[y, x].CheckLeft(powerBlocks[y, x - 1]);
                if (x != powerBlocks.GetLength(1) - 1)
                    powerBlocks[y, x].CheckRight(powerBlocks[y, x + 1]);

                powerBlocks[y, x].ResolvePoweredStatus();


                if (y == 2 && x == 0)
                    powerBlocks[y, x].CheckStart();

                if (y == 0 && x == powerBlocks.GetLength(1) - 1)
                    finish = powerBlocks[y, x].CheckFinish();

                if (y == powerBlocks.GetLength(0) - 1 && x == 2)
                    decoy = powerBlocks[y, x].CheckDecoy();

            }
        }


    }
    private void resetLoop()
    {
        for (int y = 0; y < powerBlocks.GetLength(0); y++)
        {
            for (int x = 0; x < powerBlocks.GetLength(1); x++)
            {
                powerBlocks[y, x].PowerUP(false);

            }
        }


    }
    private void FinnishLoop()
    {
        for (int y = 0; y < powerBlocks.GetLength(0); y++)
        {
            for (int x = 0; x < powerBlocks.GetLength(1); x++)
            {
                powerBlocks[y, x].Finsish();

            }
        }

        puzzleTrigger.TriggerEvent();
    }

    private void ColorLoop()
    {
        for (int y = 0; y < powerBlocks.GetLength(0); y++)
        {
            for (int x = 0; x < powerBlocks.GetLength(1); x++)
            {
                powerBlocks[y, x].ResolveColors();

            }
        }


    }
    private void DecoyLight(bool value)
    {
        if (value)
            lightDecoy.LightUp();
        if (!value)
            lightDecoy.NoLight();
    }
    private void FinishLight(bool value)
    {
        if (value)
            lightFinish.LightUp();
        if (!value)
            lightFinish.NoLight();
    }
}
