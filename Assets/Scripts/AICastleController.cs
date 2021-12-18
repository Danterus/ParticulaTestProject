using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICastleController : MonoBehaviour
{
    [SerializeField] private Castle _controlledCastle;
    [SerializeField] private Castle _targetCastle;
    
    public delegate void AIActionMade();

    public AIActionMade OnActionMade;
    public void Init()
    {
        _controlledCastle.Init(_targetCastle);
    }

    public Castle GetCastle()
    {
        return _controlledCastle;
    }
    
    public void StartTurn()
    {
        ExecuteRandomAction();
    }
    
    private void ExecuteRandomAction()
    {
        OnActionMade?.Invoke();
        _controlledCastle.InvokeAction(Random.Range(0,_controlledCastle.GetActionsCount()), DiceRoller.GetD6RollResult());
    }
}
