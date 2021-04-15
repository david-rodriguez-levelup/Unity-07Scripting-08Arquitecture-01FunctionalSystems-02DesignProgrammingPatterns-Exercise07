using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPoolable
{

    void SetPool(ObjectPool<IPoolable> pool);

    void OnPoolGet();

    void OnPoolPut();

}
