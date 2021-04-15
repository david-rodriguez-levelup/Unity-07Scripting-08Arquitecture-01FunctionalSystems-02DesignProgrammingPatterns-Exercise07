using UnityEngine;

public class OnTimeoutSelfDestroyAction : MonoBehaviour
{

    [SerializeField] float timeout = 5f;

    private void Start() // TODO: Debería ser en el OnEnable, no en el Start! (imagina que lo cogemos y devolvemos de un ObjectPool).
    {
        Destroy(gameObject, timeout);
    }

}
