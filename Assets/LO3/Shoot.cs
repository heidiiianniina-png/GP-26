using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField]
    GameObject ballPrefab;
    [SerializeField]
    GameObject ball;
    int numberOfBalls = 10;
    bool ballSlotted = false;
    float pullAmount = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawBall();
    }

    // Update is called once per frame
    void Update()
    {
        ShootLogic();
    }
    void SpawBall()
    {
        if (numberOfBalls > 0)
        {
            ballSlotted = true;
            ball = Instantiate(ballPrefab, transform.position, transform.rotation) as GameObject;
            ball.transform.parent = transform;
        }
    }
    void ShootLogic()
    {
        if (numberOfBalls > 0)
        {
            if (pullAmount < 100)
                pullAmount = 100;
            if (Input.GetMouseButtonDown(0))
            {
                pullAmount += Time.deltaTime * pullAmount;


            }
            if(Input.GetMouseButtonUp(0))
            {
                pullAmount = 0;
            }
        }
    }
}