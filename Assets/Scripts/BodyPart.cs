using UnityEngine;

public class BodyPart : MonoBehaviour, IBodyPart
{
    [SerializeField]
    private float damageMultiplier = 1.0f;

    private int _bulletDamage = 10;

    public float DamageMultiplier => damageMultiplier;

    public void HandleCollision(GameObject collider)
    {
        if (collider.CompareTag("Bullet"))
        {
            float damage = _bulletDamage * DamageMultiplier;
            DamageEventSystem.TriggerBodyPartHit(damage);
            //Destroy(collider); // Destroy the bullet //Disable the bullet
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        HandleCollision(collision.gameObject);
    }
}