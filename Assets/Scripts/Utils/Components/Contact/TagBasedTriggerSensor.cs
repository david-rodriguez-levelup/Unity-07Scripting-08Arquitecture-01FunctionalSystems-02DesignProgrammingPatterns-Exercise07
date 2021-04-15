using System;
using UnityEngine;

public class TagBasedTriggerSensor : MonoBehaviour
{
    public event Action<Collider> OnEnter;
    public event Action<Collider> OnExit;

    [SerializeField] private string _tag;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag(_tag))
        {
            OnEnter?.Invoke(collider);
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.CompareTag(_tag))
        {
            OnExit?.Invoke(collider);
        }
    }

}
