using UnityEngine;

public class MoveTarget : MonoBehaviour  
{
    [SerializeField]
    Transform[] wayPoints;
    int currentWayPoint = 0;
    Rigidbody rigidB;
    [SerializeField]
    float moveSpeed = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
    void Movement()
    {
        if(Vector3.Distance(transform.position, wayPoints[currentWayPoint].position) < .25f)
        {
            currentWayPoint += 1;
            currentWayPoint = currentWayPoint % wayPoints.Length;
        }
        Vector3 _dir = (wayPoints[currentWayPoint].position - transform.position).normalized;
        rigidB.MovePosition(transform.position + _dir*moveSpeed*Time.deltaTime);
    }
}
