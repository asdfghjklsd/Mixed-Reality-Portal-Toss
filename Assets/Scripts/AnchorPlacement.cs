using System.Collections;
using Meta.XR.MRUtilityKit;
using UnityEngine;
using UnityEngine.UIElements;

public class AnchorPlacement : MonoBehaviour
{
    public GameObject Portal1;
    public GameObject Portal2;
    public GameObject Portal3;
    public GameObject GunSpawn;
    private LineRenderer lr;
    public int totalPortals = 2;
    private bool isInitialized;
    private int portalCount = 0;


    public void Initialized() => isInitialized = true;

    void Start()
    {
        portalCount = 0;
        Portal1.SetActive(false);
        Portal2.SetActive(false);
        Portal3.SetActive(false);
        lr = GetComponent<LineRenderer>();
        lr.enabled = false;
    }
 
    void Update()
    {
        if(!isInitialized) return;  
        
        Vector3 rayOrigin = GunSpawn.transform.position;
        Vector3 rayDirection = GunSpawn.transform.rotation * Vector3.forward;

        if (MRUK.Instance?.GetCurrentRoom()?.Raycast(new Ray(rayOrigin,rayDirection), Mathf.Infinity, out RaycastHit hit, out MRUKAnchor anchorhit) == true)
        {
            lr.SetPosition(0 ,rayOrigin);
            

            if(OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.RTouch))
            {
                lr.enabled = true;
                lr.SetPosition(1, hit.point);
            }    
            if(OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.RTouch) != true)
            {
                lr.enabled = false;
            }        
            

            if(anchorhit != null && OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
            {
                Quaternion rotation = Quaternion.LookRotation(-hit.normal);

                    CreateSpatialAnchor(hit.point, rotation);
            }
        }
      
        
    }

    public void CreateSpatialAnchor(Vector3 hitPoint, Quaternion rotation)
    {      

        if(portalCount == 2 && portalCount < totalPortals)
        {
            Portal3.transform.position = hitPoint;
            Portal3.transform.rotation = rotation;
            Portal3.SetActive(true);
            portalCount = 3;
        }

        if(portalCount == 1 && portalCount < totalPortals)
        {
            Portal2.transform.position = hitPoint;
            Portal2.transform.rotation = rotation;
            Portal2.SetActive(true);
            portalCount = 2;
        }

        if(portalCount == 0 && portalCount < totalPortals)
        {
            Portal1.transform.position = hitPoint;
            Portal1.transform.rotation = rotation;
            Portal1.SetActive(true);
            portalCount = 1;
        }

    }
}
