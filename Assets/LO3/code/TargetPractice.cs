using UnityEngine;
using Unity.FPS.Game;

public class TargetPractice : MonoBehaviour
{
    Health health;

    void Start()
    {
        health = GetComponent<Health>();

        if (health != null)
        {
            health.OnDie += OnDeath;
        }
    }

    void OnDeath()
    {
        Debug.Log("Target destroyed");
        Destroy(gameObject);
    }
}