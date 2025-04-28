using Meta.XR.MRUtilityKit;
using UnityEngine;
using System.Collections;
using GLTF.Schema;

public class Bin : MonoBehaviour
{
    public BallScore ballScore;
    public int binscore = 50;
    public int finalscore = 0;
    public ScoreManager scoremanager;
    public FindSpawnPositions spawnBin;
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
                finalscore = (other.GetComponent<BallScore>().score * Mathf.FloorToInt(other.GetComponent<BallScore>().timer)) + binscore;
                scoremanager.AddScore(finalscore);
                Debug.Log(finalscore + "added to scoremanager");
                StartCoroutine(NewSpawn());
                               
            }
        }
    }

    IEnumerator NewSpawn()
    {
        GetComponent<MeshCollider>().enabled = false;

        yield return new WaitForSeconds(2);
        GetComponent<MeshCollider>().enabled = true;
        spawnBin.StartSpawn();
    }
}
