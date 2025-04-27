using UnityEngine;

public class Bin : MonoBehaviour
{
    public BallScore ballScore;
    public int binscore = 50;
    public int finalscore;
    public ScoreManager scoremanager;
    void Start()
    {
        finalscore = 0;
    }

    void Update()
    {
        scoremanager.AddScore(finalscore);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            if(ballScore.score != 0)
            {
                finalscore = ballScore.score + binscore;
            }
        }
    }
}
