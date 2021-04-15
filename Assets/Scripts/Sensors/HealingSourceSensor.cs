using System;
using UnityEngine;

public class HealingSourceSensor : MonoBehaviour
{

    [SerializeField] float healingRatio = 1f;

    public event Action<float> OnHealingDetected;

    private void Start()
    {
        // Intentionally left empty to allow enable/disable from the Inspector.
    }

    private void OnCollisionEnter(Collision collision)
    {
        DetectHealingSource(collision.gameObject);
    }

    private void OnTriggerEnter(Collider collider)
    {
        DetectHealingSource(collider.gameObject);
    }

    private void DetectHealingSource(GameObject colliderGameObject)
    {
        if (enabled)
        {
            HealingSourceAction healingSourceAction = colliderGameObject.GetComponent<HealingSourceAction>();
            if (healingSourceAction != null
                && healingSourceAction.enabled)
            {
                OnHealingDetected?.Invoke(healingSourceAction.Healing * healingRatio);
            }
        }
    }

}
