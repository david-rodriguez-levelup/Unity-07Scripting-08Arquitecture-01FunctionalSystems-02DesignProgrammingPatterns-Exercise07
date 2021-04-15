using UnityEngine;

public interface ILaunchAction
{

    void SetPool(ObjectPool<IProjectile> pool);

    bool CanLaunch();

    void Launch();

}
