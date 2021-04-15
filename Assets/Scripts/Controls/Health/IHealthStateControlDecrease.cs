using System;

public interface IHealthStateControlDecrease
{

    event Action<float> OnHealthDecreased;
    event Action OnMinHealthAchieved;

    bool TryDecreaseHealth(float amount);

}
