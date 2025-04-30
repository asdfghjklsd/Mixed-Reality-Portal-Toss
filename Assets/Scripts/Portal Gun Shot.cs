using UnityEngine;

public class PortalGunShot : MonoBehaviour
{
    public GameObject particles;
    public AudioSource audioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
        {
            particles.GetComponent<ParticleSystem>().Play();
            audioSource.Play();
        }
    }
}
