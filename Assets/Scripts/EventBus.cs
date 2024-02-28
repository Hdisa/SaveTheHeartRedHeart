using System;

public static class EventBus
{
    //Player
    public static Action IsDead;
    
    //UI
    public static Action<float> SetHealth;
    public static Action<float> UpdateHealthBar;
}
