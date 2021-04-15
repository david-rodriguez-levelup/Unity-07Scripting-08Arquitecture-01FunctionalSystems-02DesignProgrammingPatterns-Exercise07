using System;

public interface IHealthStateControlIncrease
{

    event Action<float> OnHealthIncreased;
    event Action OnMaxHealthAchieved;

    bool TryIncreaseHealth(float amount);

}
