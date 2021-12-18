using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    [SerializeField] private BattleState _currentBattleState;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private AICastleController _aiCastleController;

    public delegate void ActionTitleChange(string user, string actionName, int value);

    public static ActionTitleChange OnCastleActionMade;
    
    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _currentBattleState = BattleState.START;
        SetupBattle();
    }

    private void SetupBattle()
    {
        _playerController.Init();
        _aiCastleController.Init();

        _playerController.OnActionMade += () => { StartCoroutine(PlayerAction()); };
        _aiCastleController.OnActionMade += ChangeTurnToPlayer;
        _currentBattleState = BattleState.PLAYERTURN;
        _playerController.StartTurn();
    }

    private void OnDisable()
    {
        _playerController.OnActionMade -= () => { StartCoroutine(PlayerAction()); };
        _aiCastleController.OnActionMade += ChangeTurnToPlayer;
    }

    private void ChangeTurnToPlayer()
    {
        _currentBattleState = BattleState.PLAYERTURN;
        _playerController.StartTurn();
    }
    
    IEnumerator PlayerAction()
    {
        yield return new WaitForSeconds(1f);

        if (_aiCastleController.GetComponent<HealthController>().IsDead)
        {
            _currentBattleState = BattleState.WON;
        }
        else
        {
            _currentBattleState = BattleState.ENEMYTURN;
            _aiCastleController.StartTurn();
        }
    }
    
    
}

public enum BattleState
{
    START,
    PLAYERTURN,
    ENEMYTURN,
    WON,
    LOST
}
