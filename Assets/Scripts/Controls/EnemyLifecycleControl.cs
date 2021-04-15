using UnityEngine;

[RequireComponent(typeof(IHealthStateControlDecrease))]
[RequireComponent(typeof(DamageSourceSensor))]
[RequireComponent(typeof(ScoreEmitterAction))]
[RequireComponent(typeof(DefaultSpawnAction))]
public class EnemyLifecycleControl : MonoBehaviour
{

    private IHealthStateControlDecrease healthStateControl;
    private DamageSourceSensor damageSourceSensor;
    private ScoreEmitterAction scoreEmitterAction;
    private DefaultSpawnAction explosionSpawnAction;

    private void Awake()
    {
        healthStateControl = GetComponent<IHealthStateControlDecrease>();
        damageSourceSensor = GetComponent<DamageSourceSensor>();
        scoreEmitterAction = GetComponent<ScoreEmitterAction>();
        explosionSpawnAction = GetComponent<DefaultSpawnAction>();
    }

    private void OnEnable()
    {
        healthStateControl.OnMinHealthAchieved += Explode;
        damageSourceSensor.OnDamageDetected += OnDamageDetected;
    }

    private void OnDisable()
    {
        healthStateControl.OnMinHealthAchieved -= Explode;
        damageSourceSensor.OnDamageDetected -= OnDamageDetected;
    }

    private void OnDamageDetected(float amount)
    {
        // Esta capa de indirección (el controller recibe el evento del sensor y consume el método del HealthStateControl) 
        // nos permite lanzar aquí FX específicos del Enemy o realizar otras acciones propias del controlador.
        healthStateControl.TryDecreaseHealth(amount);
    }

    private void Explode()
    {
        explosionSpawnAction.Spawn();
        scoreEmitterAction.Emit();
        Destroy(gameObject);
    }

}

