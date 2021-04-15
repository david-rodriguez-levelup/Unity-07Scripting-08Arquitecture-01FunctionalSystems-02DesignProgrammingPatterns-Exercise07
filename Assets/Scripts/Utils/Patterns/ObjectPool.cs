using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T : IPoolable
{

    public int Count => queue.Count;

    private readonly Queue<T> queue = new Queue<T>();

    public void Init<Q>(Q prefab, int numSize) where Q : MonoBehaviour, IPoolable
    {
        for (int i = 0; i < numSize; i++)
        {
            T instance = GameObject.Instantiate(prefab).GetComponent<T>();
Debug.Log($"-----------> {this}");
Debug.Log($"-----------> {this as ObjectPool<IPoolable>}");
            instance.SetPool(this as ObjectPool<IPoolable>);
            Put(instance);
        }
    }

    public T Get()
    {
        if (queue.Count > 0)
        {
            T instance = queue.Dequeue();
            instance.OnPoolGet();
            return instance;
        }
        else
        {
            throw new Exception("ObjectPool is empty.");
        }
    }

    public T TryGet()
    {
        if (queue.Count > 0)
        {
            T instance = queue.Dequeue();
            instance.OnPoolGet();
            return instance;
        }
        else
        {
            return default;
        }
    }

    public void Put(T instance)
    {
        queue.Enqueue(instance);
        instance.OnPoolPut();
    }

}