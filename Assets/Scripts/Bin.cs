using UnityEngine;

public class Bin : MonoBehaviour
{
    public BallScore ballScore;
    public float binscore = 50;
    public float finalscore;
    void Start()
    {
        finalscore = 0;
    }

    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            if(ballScore.score != 0)
            {
                finalscore = binscore + ballScore.score;
            }
        }
    }
}
