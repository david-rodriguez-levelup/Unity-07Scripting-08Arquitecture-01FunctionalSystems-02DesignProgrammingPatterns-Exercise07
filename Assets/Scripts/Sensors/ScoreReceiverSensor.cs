using System;
using UnityEngine;

public class ScoreReceiverSensor : MonoBehaviour
{

    public event Action<int> OnScoreReceived;

    public void Receive(int score)
    {
        OnScoreReceived?.Invoke(score);
    }

}
