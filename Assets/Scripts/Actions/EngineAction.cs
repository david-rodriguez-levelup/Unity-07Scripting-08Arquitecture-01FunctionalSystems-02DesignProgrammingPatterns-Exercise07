using UnityEngine;

public class EngineAction : MonoBehaviour
{

    private GameObject core;
    private GameObject flare;

    private void Awake()
    {
        core = transform.Find("[Core]").gameObject;
        flare = transform.Find("[Flare]").gameObject;       
    }

    private void OnEnable()
    {
        core.SetActive(true);
        flare.SetActive(true);
    }

    private void OnDisable()
    {
        core.SetActive(false);
        flare.SetActive(false);
    }

    public void Rest()
    {
        core.SetActive(false);
        flare.SetActive(enabled && true);
    }

    public void Ignite()
    {
        core.SetActive(enabled && true);
        flare.SetActive(enabled && true);
    }

}
