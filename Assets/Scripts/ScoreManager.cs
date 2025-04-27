using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreboardtext;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreboardtext.text = "0";
    }

    // Update is called once per frame
    void Update()
    {

    }
}

