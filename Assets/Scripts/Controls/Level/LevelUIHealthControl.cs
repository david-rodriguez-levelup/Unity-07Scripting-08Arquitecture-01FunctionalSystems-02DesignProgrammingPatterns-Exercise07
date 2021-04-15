using UnityEngine;
using UnityEngine.UI;

public class LevelUIHealthControl : MonoBehaviour
{

    //[SerializeField] GameObject player; // Option 1.
    [SerializeField] Image healthBar;

    private IHealthStateControlReadOnly playerHealthState;

    private void Awake()
    {
        // Two options:
        // 1) From injected object in the inspector.
        //playerHealthState = player.GetComponent<IHealthStateControlReadOnly>();
        // 2) Using generics!
        NameBasedComponentFinder<IHealthStateControlReadOnly> playerHealthStateFinder = new NameBasedComponentFinder<IHealthStateControlReadOnly>("Player");
        playerHealthState = playerHealthStateFinder.TryGet();
        // 3) Extension method "FindObjectsOfInterfaceType"?
        // ???
    }

    private void OnEnable()
    {
        playerHealthState.OnHealthIncreased += IncreaseHealthBar;
        playerHealthState.OnHealthDecreased += DecreaseHealthBar;
    }

    private void OnDisable()
    {
        playerHealthState.OnHealthIncreased -= IncreaseHealthBar;
        playerHealthState.OnHealthDecreased -= DecreaseHealthBar;
    }

    private void IncreaseHealthBar(float amount)
    {
        UpdateHealthBar();
    }

    private void DecreaseHealthBar(float amount)
    {
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        float maxHealth = playerHealthState.GetMaxHealth();
        float currentHealth = playerHealthState.GetCurrentHealth();

        healthBar.fillAmount = currentHealth / maxHealth;
    }

}
