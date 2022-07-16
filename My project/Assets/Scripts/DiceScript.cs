using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceScript : MonoBehaviour
{

    public int RollTime;
    public int DiceNum;

    // Start is called before the first frame update
    void Start()
    {
        RollTime = 20;
    }

    // Update is called once per frame
    void Update()
    {
        if(RollTime > 0)
        {
            DiceRoll();
            RollTime--;
        }
    }

    // Roll the dice
    void DiceRoll()
    {
        // Picks a number between 1 and 6
        DiceNum = Random.Range(1, 7);

        if (DiceNum == 1)
        {
            Debug.Log(1);
        }

        if (DiceNum == 2)
        {
            Debug.Log(2);
        }

        if (DiceNum == 3)
        {
            Debug.Log(3);
        }

        if (DiceNum == 4)
        {
            Debug.Log(4);
        }

        if (DiceNum == 5)
        {
            Debug.Log(5);
        }

        if (DiceNum == 6)
        {
            Debug.Log(6);
        }
    }
}
