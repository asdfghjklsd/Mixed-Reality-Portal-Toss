using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection.Emit;
using Ionic.Zip;
using Meta.XR.MRUtilityKit;
using Unity.Collections;
using UnityEditor.iOS.Extensions.Common;
using UnityEngine;
using UnityEngine.UIElements;

public class DustbinSpawn : MonoBehaviour
{
    public GameObject SpawnPrefab;
    public float minDistanceEdge = 0.5f;
    public MRUKAnchor.SceneLabels spawnLabels;
    private Vector3 location;
    private Vector3 ObjectChecker;
    public FindSpawnPositions Spawn;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   
        StartSpawn();
        //SpawnDustbin();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnDustbin()
    {
        /*MRUKRoom room = MRUK.Instance.GetCurrentRoom();
        room.GenerateRandomPositionOnSurface(MRUK.SurfaceType.FACING_UP,minDistanceEdge,new LabelFilter(spawnLabels), out Vector3 pos, out Vector3 norm);
        Spawn.SpawnLocations(room,pos,norm);
        ObjectChecker = new Vector3(pos.x,1,pos.z);
        pos.y = 0;
        location = pos;
        Instantiate(SpawnPrefab,location,Quaternion.identity);*/
        /*MRUKRoom room = MRUK.Instance.GetCurrentRoom();
        Spawn = GetComponent<FindSpawnPositions>();
        Spawn.SpawnAmount = 1;
        Spawn.SpawnObject = SpawnPrefab;
        location = Spawn.SpawnObject.transform.position;
        Instantiate(SpawnPrefab,location,Quaternion.identity); */
        
    }
    void StartSpawn()
    {
        MRUKRoom room = MRUK.Instance.GetCurrentRoom();
        Spawn = GetComponent<FindSpawnPositions>();
        Spawn.SpawnAmount = 1;
        Spawn.SpawnObject = SpawnPrefab;
        location = Spawn.SpawnObject.transform.position;
        Instantiate(SpawnPrefab,location,Quaternion.identity);
    }
    

    

}
