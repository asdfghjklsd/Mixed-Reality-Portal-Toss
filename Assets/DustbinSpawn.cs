using Meta.XR.MRUtilityKit;
using UnityEngine;
using UnityEngine.UIElements;

public class DustbinSpawn : MonoBehaviour
{
    Transform location;
    public float minDistanceEdge = 0.5f;
    public MRUKAnchor.SceneLabels spawnLabels;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        location = transform.GetComponent<Transform>();
        SpawnDustbin();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnDustbin()
    {

    }
}
