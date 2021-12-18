using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(HealthController))]
public class Castle : MonoBehaviour
{
    [SerializeField] private List<CastleAction> availableActions;
    
    private Castle _targetEnemyCastle;
    public void Init(Castle target)
    {
        _targetEnemyCastle = target;
    }
    private void OnEnable()
    {
        var healthController = GetComponent<HealthController>();
        healthController.OnDie += Die;
        healthController.Init();
        var armorController = GetComponent<ArmorController>();
        if (armorController!= null)armorController.Init();
    }
    
    private void OnDisable()
    {
        GetComponent<HealthController>().OnDie -= Die;
    }

    public Dictionary<int, string> GetRandomActions(int number)
    {
        Dictionary<int, string> actionDictionary = new Dictionary<int, string>();
        int[] indices = new int[number];
        for (int i = 0; i < number; i++)
        {
            indices[i] = -1;
            var index = Random.Range(0, availableActions.Count);
            while (indices.Contains(index))
            {
                index = Random.Range(0, availableActions.Count);
            }
            indices[i] = index;
            actionDictionary.Add(index,availableActions[index]._name);
        }

        return actionDictionary;
    }

    public int GetActionsCount()
    {
        return availableActions.Count;
    }
    
    public void InvokeAction(int index, int val)
    {
        BattleController.OnCastleActionMade.Invoke(gameObject.name,availableActions[index]._name,val);
        availableActions[index].TriggerAction(availableActions[index].GetType() != typeof(DamageAction)?this:_targetEnemyCastle,val);
    }
    
    private void Die()
    {
        Debug.Log("Game over");
        
    }
}
