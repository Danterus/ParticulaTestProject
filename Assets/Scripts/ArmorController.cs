using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HealthController))]
public class ArmorController : MonoBehaviour
{
    [SerializeField] private int startingArmor;
    [SerializeField] private int currentArmor;

    public delegate void ArmorChangeAction();

    public event ArmorChangeAction OnArmorChange;
    
    private HealthController _healthController;

    public void Init()
    {
        _healthController = GetComponent<HealthController>();
        currentArmor = startingArmor;
        OnArmorChange?.Invoke();
    }
    
    public void TakeArmorDamage(int val)
    {
        var leftover = val;
        if (leftover >= currentArmor)
        {
            leftover -= currentArmor;
            currentArmor = 0;
            
            _healthController.TakeDamage(leftover);
        }
        else
        {
            currentArmor -= leftover;
        }
        OnArmorChange?.Invoke();
    }

    public void GainArmor(int val)
    {
        currentArmor += val;
        OnArmorChange?.Invoke();
    }
    
    public int GetCurrentArmor()
    {
        return currentArmor;
    }
}
