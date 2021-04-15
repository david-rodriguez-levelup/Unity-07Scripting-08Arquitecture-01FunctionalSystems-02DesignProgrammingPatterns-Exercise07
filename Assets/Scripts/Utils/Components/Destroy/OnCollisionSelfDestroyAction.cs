using UnityEngine;

public class OnCollisionSelfDestroyAction : MonoBehaviour
{

    private enum Type
    {
        Enter,
        Exit
    }

    [SerializeField] private Type destroyOn = Type.Enter;
    [SerializeField] private LayerMask layerMask;

    private void OnCollisionEnter(Collision collision)
    {
        DestroyIfTypeAndLayerMatch(Type.Enter, collision.gameObject.layer);
    }

    private void OnCollisionExit(Collision collision)
    {
        DestroyIfTypeAndLayerMatch(Type.Exit, collision.gameObject.layer);
    }

    private void DestroyIfTypeAndLayerMatch(Type type, int layer)
    {
        if (destroyOn == type && layerMask == (layerMask | (1 << layer)))
        {
            Destroy(gameObject);
        }
    }

}