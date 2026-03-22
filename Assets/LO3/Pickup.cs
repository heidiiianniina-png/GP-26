using System.Runtime.CompilerServices;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    bool isHolding = false;
    [SerializeField]
    float throwForce = 600f;
    [SerializeField]
    float maxDistance = 3f;
    float distance;

    TempParent tempParent;
    Rigidbody rb;

    Vector3 objectPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent <Rigidbody>();
        tempParent = TempParent.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (isHolding)
        {
            Hold();
        }
        else
        {
            TryPickup();
        }
    }
 private void Hold()
    {
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        // DROP
        if (Input.GetMouseButtonUp(0))
        {
            Drop();
        }

        // THROW
        if (Input.GetMouseButtonDown(1))
        {
            Throw();
        }
    
}
    private void Drop()
    {
        if(isHolding)
        {
            isHolding = false;
            objectPos = this.transform.position;
            this.transform.position = objectPos;
            this.transform.SetParent(null);
            rb.useGravity = true;
        }
    }
    private void Throw()
    {
        Drop();
        rb.AddForce(Camera.main.transform.forward * throwForce, ForceMode.Impulse);
    }
    void TryPickup()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, maxDistance))
            {
                if (hit.transform == transform)
                {
                    PickupObject();
                }
            }
        }
    }
    void PickupObject()
    {
        if (tempParent == null)
        {
            Debug.LogError("Temp Parent item not found in scene.");
            return;
        }

        isHolding = true;
        rb.useGravity = false;
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        transform.SetParent(tempParent.transform);
    }
}
