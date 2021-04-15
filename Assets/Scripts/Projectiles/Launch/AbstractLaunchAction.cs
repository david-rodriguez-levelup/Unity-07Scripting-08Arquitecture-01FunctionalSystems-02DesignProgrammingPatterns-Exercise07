using UnityEngine;

public abstract class AbstractLaunchAction : MonoBehaviour, ILaunchAction
{
    [SerializeField]
    protected float launchForce = 10f;

    private ObjectPool<IProjectile> pool;

    public void SetPool(ObjectPool<IProjectile> pool)
    {
        this.pool = pool;
    }

    public virtual bool CanLaunch()
    {
        return true;
    }

    protected Rigidbody TryGetInstance(Quaternion rotation)
    {
        IProjectile projectile = pool.TryGet();

        if (projectile != null)
        {
            projectile.Setup(transform.position, rotation);
            return projectile.GetRigidbody();
        }
        else
        {
            return null;
        }
    }

    public abstract void Launch();

}
