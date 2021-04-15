using System;
using UnityEngine;

public class TagBasedCollisionSensor : MonoBehaviour
{

    public event Action<Collision> OnEnter;
    public event Action<Collision> OnExit;

    [SerializeField] private string _tag;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(_tag))
        {
            OnEnter?.Invoke(collision);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag(_tag))
        {
            OnExit?.Invoke(collision);
        }
    }

}
