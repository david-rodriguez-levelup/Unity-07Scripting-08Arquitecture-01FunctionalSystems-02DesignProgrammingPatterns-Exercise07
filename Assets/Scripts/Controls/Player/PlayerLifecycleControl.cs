using UnityEngine;

[RequireComponent(typeof(IHealthStateControlAll))]
[RequireComponent(typeof(DamageSourceSensor))]
[RequireComponent(typeof(HealingSourceSensor))]
[RequireComponent(typeof(DefaultSpawnAction))]
public class PlayerLifecycleControl : MonoBehaviour
{

    [SerializeField] ParticleSystem damageEffect;
    [SerializeField] ParticleSystem healingEffect;

    private IHealthStateControlAll healthStateControl;
    private DamageSourceSensor damageSourceSensor;
    private HealingSourceSensor healingSourceSensor;
    private DefaultSpawnAction explosionSpawnAction;

    private void Awake()
    {
        healthStateControl = GetComponent<IHealthStateControlAll>();
        damageSourceSensor = GetComponent<DamageSourceSensor>();
        healingSourceSensor = GetComponent<HealingSourceSensor>();
        explosionSpawnAction = GetComponent<DefaultSpawnAction>();
    }

    private void OnEnable()
    {
        damageSourceSensor.OnDamageDetected += OnDamageDetected;
        healingSourceSensor.OnHealingDetected += OnHealingDetected;
        healthStateControl.OnMinHealthAchieved += Explode;
    }

    private void OnDisable()
    {
        damageSourceSensor.OnDamageDetected -= OnDamageDetected;
        healingSourceSensor.OnHealingDetected -= OnHealingDetected;
        healthStateControl.OnMinHealthAchieved -= Explode;
    }

    private void OnDamageDetected(float amount)
    {
        // Esta capa de indirección (el controller recibe el evento del DamageSourceSensor y consume el método del HealthStateControl) 
        // nos permite lanzar aquí FX específicos del Player o realizar otras acciones propias del controlador.
        if (healthStateControl.TryDecreaseHealth(amount)) // Otra opción sería subscribirse a healthState.OnHealthDecreased.
        {
            damageEffect.Play();
        }
    }

    private void OnHealingDetected(float amount)
    {
        // Esta capa de indirección (el controller recibe el evento del HealingSourceSensor y consume el método del HealthStateControl) 
        // nos permite lanzar aquí FX específicos del Player o realizar otras acciones propias del controlador.
        if (healthStateControl.TryIncreaseHealth(amount)) // Otra opción sería subscribirse a healthState.OnHealthIncreased.
        {
            healingEffect.Play();
        }
    }

    private void Explode()
    {
        explosionSpawnAction.Spawn();
        Destroy(gameObject);
    }

}
