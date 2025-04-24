using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreboardtext;
    private float Endscore = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreboardtext.text = "50";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ScoreAdd(float points)
    {
        Endscore += points;
        scoreboardtext.text = Endscore.ToString();
    }
}
