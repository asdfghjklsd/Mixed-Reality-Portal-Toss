using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Meta.XR.MRUtilityKit;
using System.Reflection.Emit;

public class DustBingeneration : MonoBehaviour
{
    public MRUKAnchor.SceneLabels spawnLabels;
    public float minEdgeDistance = 0.3f;   
    public int a = 1; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RandomSpawnDustbin();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RandomSpawnDustbin()
    {
        MRUKRoom room = MRUK.Instance.GetCurrentRoom();
        room.GenerateRandomPositionOnSurface(MRUK.SurfaceType.FACING_UP, minEdgeDistance, new LabelFilter(spawnLabels),out Vector3 pos, out Vector3 norm);
        Vector3 randomposition = Random.insideUnitSphere*a;
        randomposition.y = 0;
        transform.position = randomposition;        
    }
}
