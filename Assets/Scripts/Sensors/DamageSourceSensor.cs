using System;
using UnityEngine;

public class DamageSourceSensor : MonoBehaviour
{

    [SerializeField] float damageRatio = 1f;

    public event Action<float> OnDamageDetected;

    private void Start()
    {
        // Intentionally left empty to allow enable/disable from the Inspector.
    }

    private void OnCollisionEnter(Collision collision)
    {
        DetectDamageSource(collision.gameObject);
    }

    private void OnTriggerEnter(Collider collider)
    {
        DetectDamageSource(collider.gameObject);
    }

    private void DetectDamageSource(GameObject colliderGameObject)
    {
        if (enabled)
        {
            DamageSourceAction damageSourceAction = colliderGameObject.GetComponent<DamageSourceAction>();

            if (damageSourceAction != null
                /*&& damageSourceAction.enabled*/) // No funciona con los proyectiles en los enemigos. Su destroy pone damageSourceAction.enabled a false y no llegan a hacer daño!
            {
                OnDamageDetected?.Invoke(damageSourceAction.Damage * damageRatio);
            }
        }
    }

}
