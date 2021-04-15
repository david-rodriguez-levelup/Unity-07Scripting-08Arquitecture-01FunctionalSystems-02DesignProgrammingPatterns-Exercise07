using UnityEngine;
using UnityEngine.Assertions;

public class RigidbodyChaseMotionAction : MonoBehaviour, IChaseMotionAction
{

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Chase(Transform target, float speed, float turnSpeed)
    {
        Assert.IsTrue(Time.inFixedTimeStep);

        // TODO: Esto tiene cosas de 2D que hay que solucionar!!!

        Vector3 toTarget = target.position - _rigidbody.position;
        float angle = Mathf.Atan2(toTarget.y, toTarget.x) * Mathf.Rad2Deg - 90f;
        Quaternion quaternion = Quaternion.AngleAxis(angle, Vector3.forward);
        _rigidbody.rotation = Quaternion.Slerp(_rigidbody.rotation, quaternion, turnSpeed * Time.fixedDeltaTime);

        Vector3 deltaPosition = transform.up * speed * Time.fixedDeltaTime;
        _rigidbody.position += deltaPosition;

    }

    public void Free(float speed)
    {
        Assert.IsTrue(Time.inFixedTimeStep);

        Vector3 deltaPosition = transform.up * speed * Time.fixedDeltaTime;
        _rigidbody.position += deltaPosition;
    }

}
