using System.Linq.Expressions;
using System.Reflection.Emit;
using Ionic.Zip;
using Meta.XR.MRUtilityKit;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class DustbinSpawn : MonoBehaviour
{
    public GameObject SpawnPrefab;
    public float minDistanceEdge = 0.5f;
    public MRUKAnchor.SceneLabels spawnLabels;
    private Vector3 location;
    private Vector3 ObjectChecker;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   
        //SpawnPrefab.SetActive(false);
        SpawnDustbin();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnDustbin()
    {
        MRUKRoom room = MRUK.Instance.GetCurrentRoom();
        room.GenerateRandomPositionOnSurface(MRUK.SurfaceType.FACING_UP,minDistanceEdge,new LabelFilter(spawnLabels), out Vector3 pos, out Vector3 norm);
        ObjectChecker = new Vector3(pos.x,1,pos.z);
        pos.y = 0;
        location = pos;
        Instantiate(SpawnPrefab,location,Quaternion.identity);
    }

    

}
