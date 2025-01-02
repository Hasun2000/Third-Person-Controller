using System;

public static class DamageEventSystem
{
    public static event Action<float> OnBodyPartHit;

    public static void TriggerBodyPartHit(float damage)
    {
        OnBodyPartHit?.Invoke(damage);
    }
}