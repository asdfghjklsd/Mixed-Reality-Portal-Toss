using UnityEngine;

public class Bin : MonoBehaviour
{
    public BallScore ballScore;
    public int binscore = 50;
    public int finalscore = 0;
    public ScoreManager scoremanager;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            if(other.GetComponent<BallScore>().score != 0)
            {
                finalscore = other.GetComponent<BallScore>().score + binscore;
                scoremanager.AddScore(finalscore);
                Debug.Log(finalscore + "added to scoremanager");
                Destroy(other.gameObject);
            }
        }
    }
}
