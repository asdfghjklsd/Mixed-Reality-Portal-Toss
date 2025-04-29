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
    private ParticleSystem portalparticles;
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
        portalparticles = GetComponentInChildren<ParticleSystem>();
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
            

            if(OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
            {
                lr.enabled = true;
                lr.SetPosition(1, hit.point);
            }    
            if(OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch) != true)
            {
                lr.enabled = false;
            }            

            if(anchorhit != null && OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
            {
                Quaternion rotation = Quaternion.LookRotation(hit.normal);

                    CreateSpatialAnchor(hit.point, rotation);
            }
        }

        if(OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.RTouch))
        {
            switch(portalCount)
            {
                case 1:
                {
                    portalCount = 0;
                    Portal1.SetActive(false);
                    break;
                }
                case 2:
                {
                    portalCount = 1;
                    Portal2.SetActive(false);
                    break;
                }
                case 3:
                {
                    portalCount = 2;
                    Portal3.SetActive(false);
                    break;
                }
            }
        }
      
        
    }

    public void CreateSpatialAnchor(Vector3 hitPoint, Quaternion rotation)
    {      

        if(portalCount == 2 && portalCount < totalPortals)
        {
            Portal3.transform.position = hitPoint;
            Portal3.transform.rotation = rotation;
            portalparticles.transform.position = hitPoint;
            portalparticles.transform.rotation = rotation;
            portalparticles.Play();
            Portal3.SetActive(true);
            portalCount = 3;
        }

        if(portalCount == 1 && portalCount < totalPortals)
        {
            Portal2.transform.position = hitPoint;
            Portal2.transform.rotation = rotation;
            portalparticles.transform.position = hitPoint;
            portalparticles.transform.rotation = rotation;
            portalparticles.Play();
            Portal2.SetActive(true);
            portalCount = 2;
        }

        if(portalCount == 0 && portalCount < totalPortals)
        {
            Portal1.transform.position = hitPoint;
            Portal1.transform.rotation = rotation;
            portalparticles.transform.position = hitPoint;
            portalparticles.transform.rotation = rotation;
            portalparticles.Play();
            Portal1.SetActive(true);
            portalCount = 1;
        }

    }
}
