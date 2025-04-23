using UnityEngine;

public class BinScore : MonoBehaviour
{
    public TeleportBall ball;
    public float FinalScore = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            if(ball.score != 0)
            {
                FinalScore = ball.score + 50;
            }
            else
            {
                FinalScore = 0;
            }
           
            Destroy(other, 0);
        }
    }
}
