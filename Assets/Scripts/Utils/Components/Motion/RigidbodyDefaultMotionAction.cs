using UnityEngine;
using UnityEngine.Assertions;

[RequireComponent(typeof(Rigidbody))]
public class RigidbodyDefaultMotionAction : MonoBehaviour, IDefaultMotionAction
{

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 direction, float speed)
    {
        Assert.IsTrue(Time.inFixedTimeStep);

        Vector3 deltaPosition = direction * speed * Time.fixedDeltaTime;
        _rigidbody.position += deltaPosition;
    }

    public void Rotate(Vector3 eulerRotation)
    {
        Assert.IsTrue(Time.inFixedTimeStep);

        Quaternion rotation = Quaternion.Euler(eulerRotation);
        _rigidbody.rotation = rotation;
    }

}
