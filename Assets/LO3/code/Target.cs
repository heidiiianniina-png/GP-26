using UnityEngine;

public class target : MonoBehaviour
{
    public bool isTargetPractise;
    public float health = 10f;
    public float defaulthealth;
    private void Start()
    {
        defaulthealth = health; 
    }
    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (isTargetPractise)
        {
            health = defaulthealth;
        }
        else
        {
            Destroy (gameObject);
        }
            health = defaulthealth;
        Debug.Log("Target broken");
    }
}

 
