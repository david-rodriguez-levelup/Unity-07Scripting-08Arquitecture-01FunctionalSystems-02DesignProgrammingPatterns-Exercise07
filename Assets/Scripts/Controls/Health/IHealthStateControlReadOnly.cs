
using System;

public interface IHealthStateControlReadOnly
{

    event Action<float> OnHealthDecreased;
    event Action OnMinHealthAchieved;
    event Action<float> OnHealthIncreased;
    event Action OnMaxHealthAchieved;

    float GetMaxHealth(); // DUDA: Esto podrían ser properties pero si queremos que estén en esta interfaz no es posible.
    
    float GetCurrentHealth();

}
