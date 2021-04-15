using UnityEngine;

public class LayerBasedNearestObjectSensor : MonoBehaviour
{

    [SerializeField] LayerMask layers;
    [SerializeField] float radius = 10f;

    public GameObject Find()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius, layers);
        if (colliders.Length > 0)
        {
            float nearestSqrDistance = float.MaxValue;
            GameObject nearestObject = null;
            for (int i = 0; i < colliders.Length; i++)
            {
                float distance = Vector3.SqrMagnitude(colliders[i].transform.position - transform.position);
                if (distance < nearestSqrDistance)
                {
                    nearestObject = colliders[i].gameObject;
                    nearestSqrDistance = distance;
                }
            }
            return nearestObject;
        }
        else
        {
            return null;
        }       
    }

}
