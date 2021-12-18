using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRoller : MonoBehaviour
{
    public static int GetD6RollResult()
    {
        return Random.Range(1, 7);
    }
}
