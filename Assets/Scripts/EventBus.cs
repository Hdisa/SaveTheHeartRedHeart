using System;

public static class EventBus
{
    //Player
    public static Action IsDead;
    
    //UI
    public static Action<float> SetHealth;
    public static Action<float> UpdateHealthBar;
    
    //Collectable
    public static Action<int> OnAddHealth; // Adds health to Entity
    public static Action<int> OnAddMana; // Adds mana to Entity
}
