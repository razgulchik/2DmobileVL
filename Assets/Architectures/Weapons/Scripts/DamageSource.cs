using UnityEngine;

public class DamageSource : MonoBehaviour
{
    private int _damageAmount;

    public void Init(int damageAmount) {
        _damageAmount = damageAmount;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        var healthComponent = other.GetComponent<IHealth>();

        if (healthComponent != null)
        {
            //Debug.Log(healthComponent);
            healthComponent?.TakeDamage(_damageAmount);
        }
    }
}
