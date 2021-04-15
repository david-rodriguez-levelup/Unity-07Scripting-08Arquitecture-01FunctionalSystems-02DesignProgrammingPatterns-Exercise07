using UnityEngine;

public class NameBasedComponentFinder<T>
{

    private string uniqueObjectName;

    public NameBasedComponentFinder(string _uniqueObjectName)
    {
        uniqueObjectName = _uniqueObjectName;
    }

    public T TryGet()
    {
        GameObject go = GameObject.Find(uniqueObjectName);

        if (go == null)
            throw new UnityException($"GameObject with name {uniqueObjectName} not found in the scene.");

        return go.GetComponent<T>();
    }

}
