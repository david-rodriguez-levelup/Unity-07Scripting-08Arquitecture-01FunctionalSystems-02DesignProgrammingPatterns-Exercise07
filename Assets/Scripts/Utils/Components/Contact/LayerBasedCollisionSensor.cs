using System;
using UnityEngine;

public class LayerBasedCollisionSensor : MonoBehaviour
{

    public event Action<Collision> OnEnter;
    public event Action<Collision> OnExit;

    [SerializeField] private LayerMask layerMask;

    private void OnCollisionEnter(Collision collision)
    {
        if (ContainsLayer(collision.gameObject.layer))
        {
            OnEnter?.Invoke(collision);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (ContainsLayer(collision.gameObject.layer))
        {
            OnExit?.Invoke(collision);
        }
    }

    private bool ContainsLayer(int layer)
    {
        return layerMask == (layerMask | (1 << layer));
    }

}
