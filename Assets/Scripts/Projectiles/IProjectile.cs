using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IProjectile : IPoolable
{   

    void Setup(Vector3 position, Quaternion rotation);
        
    Rigidbody GetRigidbody();

}
