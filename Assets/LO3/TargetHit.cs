using UnityEngine;

public class TargetHit : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Throwable"))
        {
            ScoreManager.instance.AddPoint();
            Debug.Log("Target hit!");
        }
    }
}