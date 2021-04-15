using UnityEngine;

public class ScoreEmitterAction : MonoBehaviour
{

    // DILEMA: Should actions send events?
    // -----------> public event Action<int> OnScoreEmitted;
    // NOTA: Al principio el LeveUIScore se subscribía a este evento, 
    // podría parecer más rebuscado hacerlo así, pero si en el futuro existiera
    // otro componente de la UI del level (ej. un componente que muestra un texto 
    // de combo al matar a muchos players)
    // ya no necesitamos modificar LevelSpawnControl, basta con que el nuevo
    // componente se subscriba al sensor.

    [SerializeField] private int score;

    private ScoreReceiverSensor receiver;
    
    public void SetReceiver(ScoreReceiverSensor _receiver)
    {
        receiver = _receiver;
    }

    public void Emit()
    {
        receiver.Receive(score);
    }

}
