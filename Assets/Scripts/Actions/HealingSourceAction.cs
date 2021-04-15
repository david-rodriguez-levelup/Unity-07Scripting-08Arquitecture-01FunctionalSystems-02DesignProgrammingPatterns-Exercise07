using UnityEngine;

public class HealingSourceAction : MonoBehaviour
{

    [SerializeField] private float healing;

    public float Healing => healing;

    private void Start()
    {
        // Intentionally left empty to allow enable/disable from the Inspector.
    }

}
