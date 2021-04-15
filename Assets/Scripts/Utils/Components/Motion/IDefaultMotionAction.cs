using UnityEngine;

public interface IDefaultMotionAction
{

    void Move(Vector3 direction, float speed);

    void Rotate(Vector3 eulerRotation);

}
