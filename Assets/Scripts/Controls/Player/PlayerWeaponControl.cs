using UnityEngine;

[RequireComponent(typeof(ILaunchAction))]
public class PlayerWeaponControl : MonoBehaviour
{

    [SerializeField] private string fireButton = "Fire1";
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private int projectilePoolSize = 10;
    [SerializeField] private ILaunchAction launchAction;

    private ObjectPool<IProjectile> projectilePool;

    private void Awake()
    {
        launchAction = GetComponent<ILaunchAction>();
        launchAction.SetPool(projectilePool);


        projectilePool = new ObjectPool<IProjectile>();
Debug.Log($"Init pool: {projectilePool}");
        projectilePool.Init(projectilePrefab.GetComponent<BaseProjectileControl>(), projectilePoolSize);

        /*
        for (int i = 0; i < projectilePoolSize; i++)
        {
            IProjectile instance = Instantiate(projectilePrefab).GetComponent<IProjectile>();
            instance.SetPool(projectilePool); // Leer comentario de abajo!
            projectilePool.Put(instance); // Molaría que esto fuera un Add y desde dentro llamar al IPoolable.OnPoolAdd(ObjectPool<?>);
        }
        */
    }

    private void Update()
    {
        if (Input.GetButtonDown(fireButton))
        {
            TryShoot();
        }
    }

    private void TryShoot()
    {
        if (launchAction.CanLaunch())
        {
            launchAction.Launch();
        } 
    }

}
