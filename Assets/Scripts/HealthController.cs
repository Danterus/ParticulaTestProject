using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private int currentHealth;

    public delegate void DieAction();
    public delegate void HealthChangeAction();
    public event DieAction OnDie;
    public event HealthChangeAction OnHealthChange;

    
    
    public void Init()
    {
        currentHealth = maxHealth;
        OnHealthChange?.Invoke();
    }

    public bool IsDead => currentHealth <= 0;
    
    public void TakeDamage(int val)
    {
        currentHealth -= val;
        OnHealthChange?.Invoke();
        if (currentHealth <= 0)
        {
            if (OnDie != null) OnDie();
        }
        
    }

    public void Heal(int val)
    {
        currentHealth += val;
        
        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
            
        }
        OnHealthChange?.Invoke();
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    public int GetMaximumHealth()
    {
        return maxHealth;
    }
}
