using UnityEngine;

public interface IChaseMotionAction
{

    void Chase(Transform target, float speed, float turnSpeed);

    void Free(float speed);

}
