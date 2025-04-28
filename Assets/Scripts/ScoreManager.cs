using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreboardtext;
    private float FinalScore = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreboardtext.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(int score)
    {
        FinalScore += score;
        UpdateScore();
    }
    public void UpdateScore()
    {
        scoreboardtext.text = FinalScore.ToString();
    }
}

