using UnityEngine;

public class ThrowObject : MonoBehaviour
{
    public GameObject throwablePrefab;
    public Transform throwPoint;
    public float throwForce = 10f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left click
        {
            Throw();
        }
    }

    void Throw()
    {
        GameObject obj = Instantiate(throwablePrefab, throwPoint.position, throwPoint.rotation);
        Rigidbody rb = obj.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.AddForce(throwPoint.forward * throwForce, ForceMode.Impulse);
        }
    }
}