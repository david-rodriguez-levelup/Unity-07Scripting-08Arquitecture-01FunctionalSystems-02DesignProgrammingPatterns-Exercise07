using System;
using UnityEditor;
using UnityEngine;

public class HealthStateControl : MonoBehaviour, IHealthStateControlAll, // PlayerLifecycleControl
                                                 IHealthStateControlIncrease, // ?
                                                 IHealthStateControlDecrease, // EnemyLifecycleControl
                                                 IHealthStateControlReadOnly // LevelUIHealthControl
{

    public event Action<float> OnHealthDecreased;
    public event Action OnMinHealthAchieved;
    public event Action<float> OnHealthIncreased;
    public event Action OnMaxHealthAchieved;

    [SerializeField] float maxHealth;

    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public float GetMaxHealth() => maxHealth; // DUDA: Esto podrían ser properties pero si queremos que estén en una interfaz no es posible.
   
    public float GetCurrentHealth() => currentHealth;

    public bool TryIncreaseHealth(float amount)
    {
        if (enabled)
        {
            if (amount <= 0)
                return false;

            float previousHealth = currentHealth;

            currentHealth += amount;

            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
                OnMaxHealthAchieved?.Invoke();
            }

            if (currentHealth != previousHealth)
            {
                OnHealthIncreased?.Invoke(amount);
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            #if UNITY_EDITOR
                Debug.LogWarning($"{gameObject.name}: Can't increase health because {nameof(HealthStateControl)} component is disabled.");
            #endif
            return false;
        }
    }

    public bool TryDecreaseHealth(float amount)
    {
        if (enabled)
        {
            if (amount <= 0f)
                return false;

            float previousHealth = currentHealth;

            currentHealth -= amount;

            if (currentHealth <= 0f)
            {
                currentHealth = 0f;
                OnMinHealthAchieved?.Invoke();
            }

            if (currentHealth != previousHealth)
            {
                OnHealthDecreased?.Invoke(amount);
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            #if UNITY_EDITOR
                Debug.LogWarning($"{gameObject.name}: Can't decrease health because {nameof(HealthStateControl)} component is disabled.");
            #endif
            return false;
        }
    }

    #region Gizmos

    private void OnDrawGizmos()
    {      
        Handles.Label(transform.position, currentHealth.ToString());
    }
    
    #endregion

}
