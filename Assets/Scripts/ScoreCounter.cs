using UnityEngine;
using Unity.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public Text addedscore;
    public BinScore bin;
    public float FinalScore = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        FinalScore = 0;
        addedscore.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ScoreAdd()
    {
        FinalScore = FinalScore + bin.FinalScore;
        addedscore.text = FinalScore.ToString();
    }
}
