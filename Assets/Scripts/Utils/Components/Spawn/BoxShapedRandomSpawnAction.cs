using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class BoxShapedRandomSpawnAction : MonoBehaviour
{

    private BoxCollider boxCollider;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider>();
    }

    public GameObject Spawn(GameObject prefab)
    {
        return Spawn(prefab, Quaternion.identity);
    }

    public GameObject Spawn(GameObject prefab, Quaternion rotation)
    {
        Bounds bounds = boxCollider.bounds;
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);
        float z = Random.Range(bounds.min.z, bounds.max.z);
        Vector3 randomSpawnPoint = new Vector3(x, y, z);

        return Instantiate(prefab, randomSpawnPoint, rotation);
    }

}
