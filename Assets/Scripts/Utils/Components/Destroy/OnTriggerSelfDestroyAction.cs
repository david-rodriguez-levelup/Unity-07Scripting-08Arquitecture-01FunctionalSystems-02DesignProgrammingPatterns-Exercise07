using UnityEngine;

public class OnTriggerSelfDestroyAction : MonoBehaviour
{

    private enum Type
    {
        Enter,
        Exit
    }
 
    [SerializeField] private Type destroyOn = Type.Enter;
    [SerializeField] private LayerMask layerMask;

    private void OnTriggerEnter(Collider collider)
    {
        DestroyIfTypeAndLayerMatch(Type.Enter, collider.gameObject.layer);
    }

    private void OnTriggerExit(Collider collider)
    {
        DestroyIfTypeAndLayerMatch(Type.Exit, collider.gameObject.layer);
    }

    private void DestroyIfTypeAndLayerMatch(Type type, int layer)
    {
        if (destroyOn == type && layerMask == (layerMask | (1 << layer)))
        {
            Destroy(gameObject);
        }
    }

}