using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Castle _controlledCastle;
    [SerializeField] private int _numberOfActionsPerTurn = 2;

    [SerializeField] private PlayerUIController _playerUIController;

    [SerializeField] private Castle _targetCastle;
    
    public delegate void PlayerMadeAction();

    public PlayerMadeAction OnActionMade;
    public void Init()
    {
        _controlledCastle.Init(_targetCastle);
    }

    public void StartTurn()
    {
        SetAvailableActionSelection();
    }

    private void SetAvailableActionSelection()
    {
        Dictionary<int, string> actions = _controlledCastle.GetRandomActions(_numberOfActionsPerTurn);
        
        _playerUIController.SetActions(actions, ExecuteAction);
        
    }
    
    private void ExecuteAction(int actionIndex)
    {
        OnActionMade?.Invoke();
        _controlledCastle.InvokeAction(actionIndex, DiceRoller.GetD6RollResult());
    }
}
