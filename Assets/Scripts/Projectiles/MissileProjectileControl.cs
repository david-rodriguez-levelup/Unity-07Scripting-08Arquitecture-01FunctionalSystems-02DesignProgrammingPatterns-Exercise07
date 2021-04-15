using UnityEngine;

[RequireComponent(typeof(IChaseMotionAction))]
[RequireComponent(typeof(LayerBasedNearestObjectSensor))]
public class MissileProjectileControl : BaseProjectileControl
{

    [SerializeField] private float speed = 20;
    [SerializeField] private float turnSpeed = 10;

    private IChaseMotionAction motionAction;
    private LayerBasedNearestObjectSensor nearestEnemySensor;

    private Transform target;

    protected override void Awake()
    {
        base.Awake();
        motionAction = GetComponent<IChaseMotionAction>();
        nearestEnemySensor = GetComponent<LayerBasedNearestObjectSensor>();
    }

    private void FixedUpdate()
    {
        if (target != null) 
        {
            motionAction.Chase(target, speed, turnSpeed);
        }
        else
        {
            GameObject go = nearestEnemySensor.Find();
            if (go != null)
            {
                target = go.transform;
            }
            else
            {
                motionAction.Free(speed);
            }
        }
    }

}
