using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int score = 0;

    private void Awake()
    {
        instance = this;
    }

    public void AddPoint()
    {
        score++;
        Debug.Log("Score: " + score);
    }
}