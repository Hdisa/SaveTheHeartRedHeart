using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    public void PullBullet()
    {
        EventBus.CastBullet?.Invoke();
    }

    public void Attack()
    {
        EventBus.DealDamage?.Invoke();
    }
}
