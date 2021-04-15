using UnityEngine;

public class TransformFixedMotionAction : MonoBehaviour, IFixedMotionAction
{
    [SerializeField] private Vector3 direction = Vector3.zero;
    [SerializeField] private float speed = 5f;

    private void Update()
    {
        Move();
    }

    public void Move()
    {
        Vector3 deltaPosition = direction * speed * Time.deltaTime;
        transform.position += deltaPosition;
    }

}
