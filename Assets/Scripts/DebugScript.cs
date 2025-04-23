using UnityEngine;

public class DebugScript : MonoBehaviour
{
    public BinScore score;
    public float FinalScore;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void scorecounter()
    {
        FinalScore += score.Scorebin;
    }
}
