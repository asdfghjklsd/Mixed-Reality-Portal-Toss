using UnityEngine;
using Unity.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreCounter : MonoBehaviour
{
    public Text addedscore;
    public float Score = 0;
    public GameObject bin;
    private BinScore FinalScore;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        FinalScore = bin.GetComponentInChildren<BinScore>();
        Score = 0;
        addedscore.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ScoreAdd()
    {
        Score += FinalScore.FinalScore;
        addedscore.text = Score.ToString();
    }


}
