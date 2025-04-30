using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text hiScore;
    public Text lastScore;
    public Text shots;
    private float FinalScore = 0;
    private float highScore = 0;
    private int totalShots = 0;
    private float timer = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hiScore.text = "HI. SCORE: 0";
        lastScore.text = "LAST SCORE: 0";
        shots.text = "SHOTS: 0";
    }

    // Update is called once per frame
    void Update()
    {
        shots.text = "SHOTS: " + totalShots.ToString();
    }

    public void AddScore(int score)
    {
        FinalScore = score - totalShots;

        if(totalShots == 1)
        {
            FinalScore = (FinalScore + 1) * 2;
        }

        totalShots = 0;

        if(FinalScore > highScore)
        {
            highScore = FinalScore;
        }
        UpdateScore();
    }
    public void UpdateScore()
    {
        hiScore.text = "HI. SCORE: " + highScore.ToString();
        lastScore.text = "LAST SCORE: " + FinalScore.ToString();
    }

    public void AddShot()
    {
        totalShots += 1;
    }
}

