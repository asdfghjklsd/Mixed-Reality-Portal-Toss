using Oculus.VoiceSDK.UX;
using UnityEngine;

public class BinScore : MonoBehaviour
{
    public float Scorebin = 0;
    public TeleportBall ball;
    private float Binpoints = 50;
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
                ScoreAdd();
                Destroy(other);
            }
            else
            {
                Destroy(other);
            }
            
        }
    }
    void OnTriggerExit(Collider other)
    {
        Debug.Log("DingleBERRY");
    }
    public void ScoreAdd()
    {
        Scorebin += ball.score + Binpoints;
    }
}
