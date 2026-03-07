using UnityEngine;

public class SimpleDestructible : MonoBehaviour
{
    public float health = 10f;

    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Detect FPS Sample projectiles
        if (collision.gameObject.name.Contains("Projectile"))
        {
            TakeDamage(5f);
        }
    }
}