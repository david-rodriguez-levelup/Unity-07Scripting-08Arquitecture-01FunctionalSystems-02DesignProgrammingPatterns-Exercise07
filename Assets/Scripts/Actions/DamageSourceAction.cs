using UnityEngine;

public class DamageSourceAction : MonoBehaviour
{

    [SerializeField] private float damage;

    public float Damage => damage;

    private void Start()
    {
        // Intentionally left empty to allow enable/disable from the Inspector.
    }

}
