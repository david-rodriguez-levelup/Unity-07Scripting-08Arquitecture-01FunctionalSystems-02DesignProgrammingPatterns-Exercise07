using UnityEngine;

public class DefaultSpawnAction : MonoBehaviour
{

    [SerializeField] GameObject defaultPrefab;

    public GameObject Spawn()
    {
        return Spawn(defaultPrefab, transform.position, Quaternion.identity);
    }

    public GameObject Spawn(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        return Instantiate(defaultPrefab, position, rotation);
    }

}
