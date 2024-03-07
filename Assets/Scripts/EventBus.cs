using System;

public static class EventBus
{
    //Player
    public static Action IsDead;
    public static Action<int> OnTookDamage;
    
    //UI
    //TODO: Add more UI Events like keys, coins, show numbers;
    
    //Collectable
    public static Action<int> OnAddHealth; // Adds health to Entity
    public static Action<int> OnAddMana; // Adds mana to Entity
}
