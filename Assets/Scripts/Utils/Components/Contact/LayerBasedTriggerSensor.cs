using System;
using UnityEngine;

public class LayerBasedTriggerSensor : MonoBehaviour
{

    public event Action<Collider> OnEnter;
    public event Action<Collider> OnExit;

    [SerializeField] private LayerMask layerMask;

    private void OnTriggerEnter(Collider collider)
    {
        if (ContainsLayer(collider.gameObject.layer))
        {
            OnEnter?.Invoke(collider);
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (ContainsLayer(collider.gameObject.layer))
        {
            OnExit?.Invoke(collider);
        }
    }

    private bool ContainsLayer(int layer)
    {
        return layerMask == (layerMask | (1 << layer));
    }

}
