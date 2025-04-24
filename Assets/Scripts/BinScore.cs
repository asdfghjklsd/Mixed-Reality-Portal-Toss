using Oculus.VoiceSDK.UX;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BinScore : MonoBehaviour
{
    public float Scorebin = 0;
    public TeleportBall ball;
    private float Binpoints = 50;
    ScoreManager main;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        main = GameObject.Find("Manager").GetComponent<ScoreManager>();
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
                
                Scorebin = ball.score+Binpoints;
                Debug.Log("Ball score is not 0 " + Scorebin);
                //ball.Ballscore(Scorebin);
                main.ScoreAdd(Scorebin);
                Destroy(other.gameObject);
            }
            else
            {
                Debug.Log("Ball Score is 0 "+ Scorebin);
                Destroy(other.gameObject);
            }
            
        }
    }
}
